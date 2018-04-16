'use strict'

const app = Sammy ('#main', function() {
    this.use('Handlebars', 'hbs');

    // Get index
    this.get('#/index.html', function (ctx) {
        ctx.isAuthenticated = authService.isAuthenticated;      
    
        ctx.loadPartials({
            header: './templates/common/header.hbs',
            navigation: './templates/common/navigation.hbs',
            authNavigation: './templates/common/authNavigation.hbs',
            footer: './templates/common/footer.hbs',
            contactPage: './templates/contacts/contactPage.hbs',
            contact: '/templates/contacts/contact.hbs',
            contactDetails: '/templates/contacts/contactDetails.hbs',
            contactsList: '/templates/contacts/contactsList.hbs',
            loginForm: './templates/forms/loginForm.hbs'
        }).then(function () {
            this.partial('./templates/home.hbs');
        });     
    });

    // Redirect to home page
    this.get('index.html', function (ctx) {
        ctx.redirect('/#/index.html');
    });

    // GET Upload
    this.get('#/upload', (ctx) =>
    {
        $.ajax('/data.json')
            .then(loadDataSuccess)
            .catch(console.error);           
    
        function loadDataSuccess(contacts) {
            //console.log(contacts);
            let data = crudService.getContacts();
            console.log(data);
            for(let contact of contacts)  {
                crudService.createContacts(contact)
                .then(console.log('done'))
                .catch(console.log('error uploading'));
            }         
        }

        ctx.redirect('#/index.html');
    });

    // GET register
    this.get('#/register', (ctx) =>
    {
        ctx.loadPartials({
            header: './templates/common/header.hbs',
            navigation: './templates/common/navigation.hbs',
            footer: './templates/common/footer.hbs',
        }).then(function () {
            this.partial('./templates/forms/registerForm.hbs');
        });
    });

    // POST register
    this.post('#/register', (ctx) => {
        let username = ctx.params.username;
        let password = ctx.params.password;
        let repeatPass = ctx.params.repeatPass;

        if (password !== repeatPass){
            alert('Password do not match');
        }else {
            authService.registerUser(username,password)
                .then(registerSuccess)
                .catch(handleAjaxError)
        }      
            
        function registerSuccess(userInfo) {
            authService.saveAuthInSession(userInfo);
            ctx.redirect('#/index.html');
            console.log('User registration successful.');
        }
    })

    // POST login
    this.post('#/login', (ctx) => {
        let username = ctx.params.username;
        let password = ctx.params.password;

        authService.loginUser(username,password)
            .then(loginSuccess)
            .catch(console.error);

        function loginSuccess(userInfo) {
            authService.saveAuthInSession(userInfo);
            ctx.redirect('#/index.html');
            cinsole.log('Login successful.');
        }
    })

    // GET Logout
    this.get('#/logout', (ctx) => {

        authService.logoutUser()
            .then(logoutSuccess)
            .catch(console.log('error'));

        function logoutSuccess() {
            sessionStorage.clear();
            ctx.redirect('#/index.html');
            console.log('Logout successful.');
        }
    });

    // Error handling
    function handleAjaxError(response) {
        let errorMsg = JSON.stringify(response)
        if (response.readyState === 0)
            errorMsg = "Cannot connect due to network error."
        if (response.responseJSON && response.responseJSON.description)
            errorMsg = response.responseJSON.description
        showError(errorMsg)
    }

});

$(() => {
    app.run();
});