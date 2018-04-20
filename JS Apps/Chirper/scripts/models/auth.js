let auth = (() => {

    // user/login
    function login(username, password) {
        let userData = {
            username,
            password
        };

        return requester.post('user', 'login', 'basic', userData);
    }

    // user/register
    function register(username, password) {
        let userData = {
            username,
            password,
            "subscriptions": []
        };

        return requester.post('user', '', 'basic', userData);
    }

    // user/logout
    function logout() {
        let logoutData = {
            authtoken: sessionStorage.getItem('authtoken')
        };

        return requester.post('user', '_logout', 'kinvey', logoutData);
    }

    function saveSession(userInfo) {
        let userAuth = userInfo._kmd.authtoken;
        sessionStorage.setItem('authtoken', userAuth);
        let userId = userInfo._id;
        sessionStorage.setItem('userId', userId);
        let username = userInfo.username;
        sessionStorage.setItem('username', username);
        let subscriptions = JSON.stringify(userInfo.subscriptions);
        sessionStorage.setItem('subscribers', subscriptions);
    }

    function isAuthenticated () {
        return sessionStorage.getItem('authtoken') !== null && sessionStorage.getItem('authtoken') !== 'undefined';
    }

    function getUsername() {
        return sessionStorage.getItem('username');
    }

    function getUserId() {
        return sessionStorage.getItem('userId');
    }

    function validateCredentialsInput(username, password, repeatPass){
        let valid = true;

        if (username === ''){
            notify.showError(text.emptyUsername);
            valid = false;
        }
        else if(password === ''){
            notify.showError(text.emptyPassword);
            valid = false;
        }
        else if (repeatPass !== password) {
            notify.showError(text.passNotMatch);
            valid = false;
        }
        else if(username.length < 5){
            notify.showError(text.invalidUsername);
            valid = false;
        }

        return valid;
    }

    function getSubscribers () {
        if (sessionStorage.getItem('subscribers') === 'undefined'){
            let str = JSON.stringify([]);
            sessionStorage.setItem('subscribers', str);
        }
        let subs = sessionStorage.getItem('subscribers');
        return JSON.parse(subs);
    }

    function addSubscriber (subscriber) {
        let subscribers = getSubscribers();

        if (!subscribers.includes(subscriber)){
            subscribers.push(subscriber);
            subscribers = JSON.stringify(subscribers);
            sessionStorage.setItem('subscribers', subscribers);
        }
    }

    function removeSubscriber (subscriber) {
        let subscribers = getSubscribers();
        subscribers = subscribers.filter( x => x != subscriber);
        subscribers = JSON.stringify(subscribers);
        sessionStorage.setItem('subscribers', subscribers);
    }

    return {
        login,
        register,
        logout,
        saveSession,
        isAuthenticated,
        getUsername,
        getUserId,
        validateCredentialsInput,
        addSubscriber,
        removeSubscriber,
        getSubscribers
    }
})()