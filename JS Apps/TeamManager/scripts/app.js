
const app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs');

    // GET home
    this.get('#/index.html', function (ctx) { 
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();

        ctx.hasTeam = (sessionStorage.getItem('teamId') !== null) &&
                      (sessionStorage.getItem('teamId') !== "undefined");  

        ctx.loadPartials({
            header: '/templates/common/header.hbs',
            footer: '/templates/common/footer.hbs',
        }).then(function () {
            this.partial('/templates/home/home.hbs');
        });     
    });   

    // GET index, redirect to home
    this.get('index.html', function (ctx) {
        ctx.redirect('#/index.html');
    });

    // GET home, redirect to home
    this.get('#/home', function (ctx) {
        ctx.redirect('#/index.html');
    });

    // GET about
    this.get('#/about', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();  
        ctx.loadPartials({
            header: '/templates/common/header.hbs',
            footer: '/templates/common/footer.hbs',
        }).then(function () {
            this.partial('/templates/about/about.hbs');
        });   
    });

    // GET Login
    this.get('#/login', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated;
        ctx.username = auth.getUsername;
        ctx.loadPartials({
            header: '/templates/common/header.hbs',
            footer: '/templates/common/footer.hbs',
            loginForm: '/templates/login/loginForm.hbs'
        }).then(function () {
            this.partial('/templates/login/loginPage.hbs');
        }); 
    });

    // POST Login
    this.post('#/login', function (ctx) {
        let username = ctx.params.username;
        let password = ctx.params.password;

        auth.login(username, password)
                .then(loginSuccess)
                .catch(auth.handleError);

        function loginSuccess(userInfo) {
            auth.saveSession(userInfo)
            auth.showInfo(text.loggedIn);
            ctx.redirect('#/index.html');
        }        
    });

    // GET register
    this.get('#/register', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();   
        ctx.loadPartials({
            header: '/templates/common/header.hbs',
            footer: '/templates/common/footer.hbs',
            registerForm: '/templates/register/registerForm.hbs'
        }).then(function () {
            this.partial('/templates/register/registerPage.hbs');
        });   
    });

    // POST Register
    this.post('#/register', function (ctx) {
        let username = ctx.params.username;
        let password = ctx.params.password;
        let confirmPass = ctx.params.repeatPassword;
        if (confirmPass !== password) {
            auth.showError(text.passNotMatch);
        }
        else{
            auth.register(username, password)
                .then(registerSuccess)
                .catch(auth.handleError); 

            function registerSuccess(userInfo) {
                auth.saveSession(userInfo);
                auth.showInfo(text.registered);
                ctx.redirect('#/index.html');
            }
        }
    });

    // GET Logout
    this.get('#/logout', function (ctx) {
        auth.logout()
            .then(logoutSuccess)
            .catch(auth.handleError);

        function logoutSuccess() {
            sessionStorage.clear();
            auth.showInfo(text.loggedOut)
            ctx.redirect('#/index.html');
        }
    });

    // GET Catalog
    this.get('#/catalog', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();

        teamsService.loadTeams()
            .then(loadTeamsSuccess);

        function loadTeamsSuccess(teams) {
            ctx.hasNoTeam = (sessionStorage.getItem('teamId') === null) ||
                            (sessionStorage.getItem('teamId') === "undefined");

            ctx.teams = teams;
    
            ctx.loadPartials ({
                header: '/templates/common/header.hbs',
                footer: '/templates/common/footer.hbs',
                team: '/templates/catalog/team.hbs',
            }).then(function () {
                this.partial('/templates/catalog/teamCatalog.hbs');
            });
        }
    })

    // GET Catalog details
    this.get('#/catalog/:id', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();     
        ctx.teamId = ctx.params.id.substr(1);
        
        teamsService.loadTeamDetails(ctx.teamId)
            .then(loadTeamDetailsSuccess)
            .catch(auth.handleError);

        function loadTeamDetailsSuccess(teamDetails) {
            ctx.name = teamDetails.name;
            ctx.members = "";
            ctx.comment = teamDetails.comment;     
            ctx.isAuthor = teamDetails._acl.creator === sessionStorage.getItem('userId');
            ctx.isOnTeam = teamDetails._id === sessionStorage.getItem('teamId');

            ctx.loadPartials ({
                header: '/templates/common/header.hbs',
                footer: '/templates/common/footer.hbs',
                teamMember: '/templates/catalog/teamMember.hbs',
                teamControls: '/templates/catalog/teamControls.hbs'
            }).then(function () {
                this.partial('/templates/catalog/details.hbs');
            })
        }
    });

    // GET Create team
    this.get('#/create', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();
        ctx.loadPartials ({
            header: '/templates/common/header.hbs',
            footer: '/templates/common/footer.hbs',
            createForm: '/templates/create/createForm.hbs'
        }).then(function () {
            this.partial('/templates/create/createPage.hbs');
        });
    });

    // POST Create team
    this.post('#/create', function (ctx) {
        let name = ctx.params.name;
        let comment = ctx.params.comment;

        teamsService.createTeam(name, comment)
            .then(createTeamSuccess)
            .catch(auth.handleError);

        function createTeamSuccess (teamInfo) {
            teamsService.joinTeam(teamInfo._id)
                .then(function (userInfo) {
                    auth.saveSession(userInfo);
                    auth.showInfo(text.teamCreated);
                    ctx.redirect('#/catalog');
                })
                .catch(auth.handleError);
        }
    });

    // GET Join team
    this.get('#/join/:id', function (ctx) {
        let teamId = ctx.params.id.substr(1);
        console.log(teamId);

        teamsService.joinTeam(teamId)
            .then(joinTeamSuccess)
            .catch(auth.handleError);

        function joinTeamSuccess(userInfo) {
            auth.saveSession(userInfo);
            auth.showInfo(text.teamJoined);
            ctx.redirect('#/catalog');
        };
    });

    // GET Leave team
    this.get('#/leave', function(ctx) {
        teamsService.leaveTeam()
            .then(leaveTeamSuccess)
            .catch(auth.handleError);

        function leaveTeamSuccess(userInfo){
            auth.saveSession(userInfo);
            auth.showInfo(text.teamLeft);
            ctx.redirect('#/catalog');
        }
    });

    // GET Edit team
    this.get('#/edit/:id', function (ctx) {
        ctx.teamId = ctx.params.id.substr(1);
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();

        teamsService.loadTeamDetails(ctx.teamId)
            .then(loadTeamDetailsSuccess)
            .catch();

        function loadTeamDetailsSuccess(teamInfo) {
            ctx.name = teamInfo.name;
            ctx.comment = teamInfo.comment;

            ctx.loadPartials ({
                header: '/templates/common/header.hbs',
                footer: '/templates/common/footer.hbs',
                editForm: '/templates/edit/editForm.hbs'
            }).then(function () {
                this.partial('/templates/edit/editPage.hbs');
            })
        }
    });

    this.post('#/edit/:id', function(ctx) {
        let teamId = ctx.params.id.substr(1);
        let name = ctx.params.name;
        let comment = ctx.params.comment;

        teamsService.edit(teamId, name, comment)
            .then(editSuccess)
            .catch(auth.handleError);

        function editSuccess (teamInfo) {
            auth.showInfo(text.teamEdited);
            ctx.redirect('#/catalog');
        }
    });
});

$(() => {
    app.run();
});