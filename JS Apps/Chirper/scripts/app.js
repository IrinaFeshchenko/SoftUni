
const app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs');

    // GET index
    this.get('#/index', function (ctx) { 
        ctx.loggedIn = auth.isAuthenticated();

        if (ctx.loggedIn){
            ctx.redirect('/#/home');
        }
        else{
            ctx.redirect('/#/register');
        }   
    });   

    // GET index.html, redirect to home
    this.get('index.html', function (ctx) {
        ctx.redirect('/#/index');
    });

    // GET home, redirect to home
    this.get('#/home', function (ctx) {
        displayChirps('home',ctx, auth.getUsername());
    });

    function displayChirps(page,ctx, username){
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = username;
        ctx.isMyChirp = username === auth.getUsername();

        let promises = [service.countUserChirps(ctx.username),service.countFollowing(ctx.username),service.countFollowers(ctx.username)];
        Promise.all(promises)
            .then(promisSuccess)
            .catch(notify.handleError);

        function promisSuccess([chirps,following,followers]){
            let subscriptions = following[0].subscriptions;
            ctx.chirpsCount = chirps.length;
            ctx.followingCount = subscriptions.length;
            ctx.followersCount = followers.length;

            if(page === 'me'){
                service.getUserChirps(ctx.username)
                .then(loadChirpsSuccess)
                .catch(notify.handleError);
            }else{
                service.listAllChirps(subscriptions)
                .then(loadChirpsSuccess)
                .catch(notify.handleError);
            }           

            function loadChirpsSuccess(chirps) {

                chirps.forEach((p,i) => {
                    p.date = calcTime(p._kmd.ect);
                    p.isAuthor = p.author === auth.getUsername();
                });
                ctx.chirps = chirps;

                ctx.loadPartials ({
                    header: '/templates/common/header.hbs',
                    footer: '/templates/common/footer.hbs',
                    chirpForm: '/templates/home/chirpForm.hbs',
                    chirper: '/templates/home/chirper.hbs'
                }).then(function () {
                    this.partial('/templates/home/homePage.hbs');
                });
            }
        }  
    }

    // GET register
    this.get('#/register', function (ctx) { 
        ctx.loggedIn = auth.isAuthenticated();

        ctx.loadPartials({
            header: '/templates/common/header.hbs',
            footer: '/templates/common/footer.hbs',
        }).then(function () {
            this.partial('/templates/auth/register.hbs');
        }); 
    });  

    
    // GET login
    this.get('#/login', function (ctx) { 
        ctx.loggedIn = auth.isAuthenticated();

        ctx.loadPartials({
            header: '/templates/common/header.hbs',
            footer: '/templates/common/footer.hbs',
        }).then(function () {
            this.partial('/templates/auth/login.hbs');
        }); 
    });  

    // POST Register
    this.post('#/register', function (ctx) {
        let username = ctx.params.username;
        let password = ctx.params.password;
        let repeatPass = ctx.params.repeatPass;

        if(auth.validateCredentialsInput(username, password, repeatPass)){
            auth.register(username, password)
                .then(registerSuccess)
                .catch(notify.handleError); 

            function registerSuccess(userInfo) {
                auth.saveSession(userInfo);
                notify.showInfo(text.registered);
                ctx.redirect('/#/home');
            }
        }
    });

    // POST Login
    this.post('#/login', function (ctx) {
        let username = ctx.params.username;
        let password = ctx.params.password;

        auth.login(username, password)
                .then(loginSuccess)
                .catch(notify.handleError);

        function loginSuccess(userInfo) {
            if(sessionStorage.getItem('subscribers') === 'undefined'){
                userInfo.subscribers = [];
            }
            auth.saveSession(userInfo)
            notify.showInfo(text.loggedIn);
            ctx.redirect('/#/home');
        }        
    });

    // GET Logout
    this.get('#/logout', function (ctx) {
        auth.logout()
            .then(logoutSuccess)
            .catch(notify.handleError);

        function logoutSuccess() {
            sessionStorage.clear();
            notify.showInfo(text.loggedOut)
            ctx.redirect('#/index');
        }
    });

    // POST Create chirp
    this.post('#/chirps/create', function (ctx) {
        let author = auth.getUsername();
        let chirpText = ctx.params.text;

        if(validateChirpInput(chirpText)) {
            service.createChirp(author,chirpText)
            .then(createChirpSuccess)
            .catch(auth.handleError);

            function createChirpSuccess (postInfo) {
                notify.showInfo(text.chirpPublished);
                ctx.redirect('/#/me');
            }
        }
    });

    function validateChirpInput (chirpText){
        let valid = true;

        if(chirpText ===''){
            notify.showError(text.emptyText);
            valid = false;
        }
        else if (chirpText.length > 150){
            notify.showError(text.textTooLong);
            valid = false;
        }
        return valid;
    }

    // GET home, redirect to home
    this.get('#/me', function (ctx) {
        displayChirps('me',ctx, auth.getUsername());
    });

    // GET delete chirp
    this.get('#/chirps/delete/:id', function(ctx) {
        let chirpId = ctx.params.id;

        service.deleteChirp(chirpId)
            .then(deleteSuccess)
            .catch(auth.handleError);

        function deleteSuccess () {
            notify.showInfo(text.chirpDeleted);
            ctx.redirect('/#/me');
        };
    });

    // GET user profile
    this.get('#/userprofile/:name', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.profileName = ctx.params.name;
        ctx.isFollowing = auth.getSubscribers().includes(ctx.profileName);

        let promises = [service.countUserChirps(ctx.profileName),service.countFollowing(ctx.profileName),service.countFollowers(ctx.profileName)];
        Promise.all(promises)
            .then(promisSuccess)
            .catch(notify.handleError);

        function promisSuccess([chirps,subscribers,users]){
            subscribers = subscribers.filter(x=>x.username !== ctx.profileName);
            ctx.chirpsCount = chirps.length;
            ctx.followingCount = subscribers.length;
            ctx.followersCount = users.length;
            
            service.getUserChirps(ctx.profileName)
                .then(loadChirpsSuccess)
                .catch(notify.handleError);        

            function loadChirpsSuccess(chirps) {

                chirps.forEach((p,i) => {
                    p.date = calcTime(p._kmd.ect);
                });
                ctx.chirps = chirps;

                ctx.loadPartials ({
                    header: '/templates/common/header.hbs',
                    footer: '/templates/common/footer.hbs',
                    chirpForm: '/templates/profile/chirpsForm.hbs',
                }).then(function () {
                    this.partial('/templates/profile/profilePage.hbs');
                });
             }
        }  
    });

    // GET discover
    this.get('#/discover', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();

        service.getAllUsers()
            .then(getUsersSuccess)
            .catch(notify.handleError);

        function getUsersSuccess(users){
            ctx.users = users.filter(x=>x.username !== ctx.username);
            ctx.users.map(user => user.followersCount = (users.filter(u=>u.subscriptions.includes(user.username))).length);

            ctx.loadPartials ({
                header: '/templates/common/header.hbs',
                footer: '/templates/common/footer.hbs',
                userBox: '/templates/discover/userBoxForm.hbs',
            }).then(function () {
                this.partial('/templates/discover/discoverPage.hbs');
            });
        }  
    });

    // GET user follow
    this.get('#/follow/:name', function(ctx){
        let usernameToFollow = ctx.params.name;
        auth.addSubscriber(usernameToFollow);
        let subscribers = auth.getSubscribers();
        service.followUnfollow(auth.getUserId(), subscribers)  
            .then(followSuccess)
            .catch(notify.handleError);
        
        function followSuccess() {
            notify.showInfo(text.follow.replace('{username}',usernameToFollow));
            ctx.redirect(`/#/userprofile/${usernameToFollow}`);
        }
    });

    // GET user unfollow
    this.get('#/unfollow/:name', function(ctx){
        let usernameToUnFollow = ctx.params.name;
        auth.removeSubscriber(usernameToUnFollow);
        let subscribers = auth.getSubscribers();
        service.followUnfollow(auth.getUserId(), subscribers)  
            .then(unfollowSuccess)
            .catch(notify.handleError);
        
        function unfollowSuccess() {
            notify.showInfo(text.unfollow.replace('{username}',usernameToUnFollow));
            ctx.redirect(`/#/userprofile/${usernameToUnFollow}`);
        }
    });

    function calcTime(dateIsoFormat) {
        let diff = new Date - (new Date(dateIsoFormat));
        diff = Math.floor(diff / 60000);
        if (diff < 1) return 'less than a minute';
        if (diff < 60) return diff + ' minute' + pluralize(diff);
        diff = Math.floor(diff / 60);
        if (diff < 24) return diff + ' hour' + pluralize(diff);
        diff = Math.floor(diff / 24);
        if (diff < 30) return diff + ' day' + pluralize(diff);
        diff = Math.floor(diff / 30);
        if (diff < 12) return diff + ' month' + pluralize(diff);
        diff = Math.floor(diff / 12);
        return diff + ' year' + pluralize(diff);
        function pluralize(value) {
            if (value !== 1) return 's';
            else return '';
        }
    } 
});

$(() => {
    Handlebars.registerHelper('inc', function(number)
    {
        return number + 1;
    }); 
    
    app.run();
});