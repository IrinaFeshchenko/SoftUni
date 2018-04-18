
const app = Sammy('#container', function () {
    this.use('Handlebars', 'hbs');

    // GET home
    this.get('#/index.html', function (ctx) { 
        if (auth.isAuthenticated()){
            ctx.redirect('/#/posts');
        }
        else{
            ctx.loadPartials({
                header: '/templates/common/header.hbs',
                footer: '/templates/common/footer.hbs',
                registerForm: '/templates/home/registerForm.hbs',
                loginForm: '/templates/home/loginForm.hbs'
            }).then(function () {
                this.partial('/templates/home/welcome.hbs');
            }); 
        }   
    });   

    // GET index, redirect to home
    this.get('index.html', function (ctx) {
        ctx.redirect('/#/index.html');
    });

    // GET home, redirect to home
    this.get('#/home', function (ctx) {
        ctx.redirect('/#/index.html');
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
                ctx.redirect('/#/posts');
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
            auth.saveSession(userInfo)
            notify.showInfo(text.loggedIn);
            ctx.redirect('/#/posts');
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
            ctx.redirect('#/index.html');
        }
    });

    // GET Posts
    this.get('#/posts', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();

        service.listAllPosts()
            .then(listAllPostsSuccess)
            .catch(notify.handleError);

        function listAllPostsSuccess(posts) {
            ctx.posts = posts;
            ctx.posts.forEach((p,i) => {
                p.isAuthor = posts[i].author === auth.getUsername();
                p.date = calcTime(p._kmd.ect);
            });
            ctx.loadPartials ({
                header: '/templates/common/header.hbs',
                footer: '/templates/common/footer.hbs',
                navigation: '/templates/common/navigation.hbs',
                postForm: '/templates/posts/list/postForm.hbs',
                listPostsForm: '/templates/posts/list/listPostsForm.hbs'
            }).then(function () {
                this.partial('/templates/posts/list/listPostsPage.hbs');
            });
        }
    });

    // GET Create post
    this.get('#/posts/create', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();

        ctx.loadPartials ({
            header: '/templates/common/header.hbs',
            footer: '/templates/common/footer.hbs',
            navigation: '/templates/common/navigation.hbs',
            createPostForm: '/templates/posts/create/createPostForm.hbs'
        }).then(function () {
            this.partial('/templates/posts/create/createPostPage.hbs');
        });
    });

    // POST Create post
    this.post('#/posts/create', function (ctx) {
        let author = auth.getUsername();
        let title = ctx.params.title;
        let description = ctx.params.comment;
        let url = ctx.params.url;
        let imageUrl = ctx.params.imageUrl;

        if(validatePostInput(url,title)) {
            service.createPost(author,title,description,url,imageUrl)
            .then(createPostSuccess)
            .catch(auth.handleError);

            function createPostSuccess (postInfo) {
                notify.showInfo(text.postCreated);
                ctx.redirect('/#/posts');
            }
        }
    });

    function validatePostInput (url, title){
        let valid = true;
        if(url === ''){
            notify.showError(text.emptyUrl);
            valid = false;
        }
        else if (title === ''){
            notify.showError(text.emptyTitle);
            valid = false;
        }
        else if (!/^http/.test(url)){
            notify.showError(text.urlShouldStartWith);
            valid = false;
        }
        return valid;
    }

    // GET Edit post
    this.get('#/posts/edit/:id', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();
        ctx.postId = ctx.params.id;

        service.getPostDetails(ctx.postId)
            .then(loadPostDetailsSuccess)
            .catch(notify.handleError);

        function loadPostDetailsSuccess(postInfo) {
            ctx.url = postInfo.url;
            ctx.description = postInfo.description;
            ctx.title = postInfo.title;
            ctx.imageUrl = postInfo.imageUrl;

            ctx.loadPartials ({
                header: '/templates/common/header.hbs',
                footer: '/templates/common/footer.hbs',
                navigation: '/templates/common/navigation.hbs',
                editPostForm: '/templates/posts/edit/editPostForm.hbs'
            }).then(function () {
                this.partial('/templates/posts/edit/editPostPage.hbs');
            })
        }
    });

    // POST Edit post
    this.post('#/posts/edit/:id', function(ctx) {
        let author = auth.getUsername();
        let title = ctx.params.title;
        let description = ctx.params.description;
        let url = ctx.params.url;
        let imageUrl = ctx.params.imageUrl;
        let postId = ctx.params.id;

        if(validatePostInput(url,title)) {
            service.editPost(postId,author,title,description,url,imageUrl)
            .then(editSuccess)
            .catch(auth.handleError);

            function editSuccess () {
                notify.showInfo( text.postEdited.replace('{0}', title));
                ctx.redirect('/#/posts');
            };
        }
    });

    // GET delete post
    this.get('#/posts/delete/:id', function(ctx) {
        let postId = ctx.params.id;

        service.deletePost(postId)
            .then(deleteSuccess)
            .catch(auth.handleError);

        function deleteSuccess () {
            notify.showInfo(text.postDeleted);
            ctx.redirect('/#/posts');
        };
    });

    // GET myposts
    this.get('#/posts/myposts', function(ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();

        service.getMyPosts(ctx.username)
            .then(getSuccess)
            .catch(notify.handleError);

        function getSuccess(posts) {
            ctx.posts = posts;
            ctx.posts.forEach((p,i) => {
                p.isAuthor = posts[i].author === auth.getUsername();
                p.date = calcTime(p._kmd.ect);
            });
            ctx.loadPartials ({
                header: '/templates/common/header.hbs',
                footer: '/templates/common/footer.hbs',
                navigation: '/templates/common/navigation.hbs',
                mypostsForm: '/templates/posts/myposts/mypostsForm.hbs',
                mypostsPost: '/templates/posts/myposts/mypostsPost.hbs'
            }).then(function () {
                this.partial('/templates/posts/myposts/mypostsPage.hbs');
            });
        }
    });

    // GET Post details
    this.get('#/posts/details/:id', function (ctx) {
        ctx.loggedIn = auth.isAuthenticated();
        ctx.username = auth.getUsername();     
        ctx.postId = ctx.params.id;
        
        service.getPostDetails(ctx.postId)
            .then(getPostDetailsSuccess)
            .catch(notify.handleError);

        function getPostDetailsSuccess(postDetails) {
            ctx._id = postDetails._id;
            ctx.url = postDetails.url;
            ctx.description = postDetails.description;
            ctx.title = postDetails.title;
            ctx.imageUrl = postDetails.imageUrl;
            ctx.date = calcTime(postDetails._kmd.ect);
            ctx.isAuthor = postDetails.author === auth.getUsername();

            service.getPostComments(ctx._id)
                .then(getCommentsSuccess)
                .catch(notify.handleError)

            function getCommentsSuccess(comments) {
                comments.forEach((p,i) => {
                    p.isAuthor = comments[i].author === auth.getUsername();
                    p.date = calcTime(p._kmd.ect);
                });
                ctx.comments = comments;

                ctx.loadPartials ({
                    header: '/templates/common/header.hbs',
                    footer: '/templates/common/footer.hbs',
                    navigation: '/templates/common/navigation.hbs',
                    postDetailsForm: '/templates/posts/details/postDetailsForm.hbs',
                    commentForm: '/templates/posts/details/commentForm.hbs'
                }).then(function () {
                    this.partial('/templates/posts/details/postDetailsPage.hbs');
                })
            }
        }
    });

    // POST Create comment
    this.post('#/comments/create/:id', function (ctx) {
        let author = auth.getUsername();
        let postId = ctx.params.id;
        let content = ctx.params.content;

        service.getPostDetails(postId)
            .then(foundPostSuccess)
            .catch(notify.handleError);

        function foundPostSuccess () {
            service.createComment(postId,content,author)
                .then(createCommentSuccess)
                .catch(notify.handleError);

            function createCommentSuccess () {
                notify.showInfo(text.commentCreated);
                ctx.redirect(`/#/posts/details/${postId}`);
            }
        }
    });

    // GET delete comment
    this.get('#/comments/delete/:postId/:commentId', function(ctx) {
        let postId = ctx.params.postId;
        let commentId = ctx.params.commentId;

        service.deleteComment(commentId)
            .then(deleteSuccess)
            .catch(auth.handleError);

        function deleteSuccess () {
            notify.showInfo(text.commentDeleted);
            ctx.redirect(`/#/posts/details/${postId}`);
        };
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