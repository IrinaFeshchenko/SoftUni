'use strict'

let authService = (() => {
    // Register: username, password
    function registerUser(username, password) {
        return remote.post('user','', 'basic', {username, password});          
    }
    
    // Login: username, password
    function loginUser(username, password) {
        return remote.post('user','login', 'basic', {username, password})
    }

    // Logout
    function logoutUser() {
        return remote.post('user','_logout', 'kinvey');
    }
    
    // Save authentication to session
    function saveAuthInSession(userInfo) {
        sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
        sessionStorage.setItem('userId', userInfo._id);
        sessionStorage.setItem('username', userInfo.username);
    }

    function isAuthenticated () {
        return sessionStorage.getItem('authToken') !== null;
    }

    return {
        registerUser,
        loginUser,
        logoutUser,
        isAuthenticated,
        saveAuthInSession,
    }
})();