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
    function register(username, password, repeatPassword) {
        let userData = {
            username,
            password
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
    }

    function isAuthenticated () {
        return sessionStorage.getItem('authtoken') !== null && sessionStorage.getItem('authtoken') !== 'undefined';
    }

    function getUsername() {
        return sessionStorage.getItem('username');
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
        else if(!/^[A-Za-z]{3,}$/.test(username)){
            notify.showError(text.invalidUsername);
            valid = false;
        }
        else if(!/^[A-Za-z0-9]{6,}$/.test(password)){
            notify.showError(text.invalidPassword);
            valid = false;
        }

        return valid;
    }

    return {
        login,
        register,
        logout,
        saveSession,
        isAuthenticated,
        getUsername,
        validateCredentialsInput
    }
})()