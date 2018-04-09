'use strict'

let remote = (() => {
    // Ajax Request Constants
    const BASE_URL = 'https://baas.kinvey.com/';
    const APP_KEY = 'kid_ryknRqwsM';
    const APP_SECRET = '40a0f5111a3c4ff6be4a8d2d0bb40fd6';
 
    function makeAuthentication(auth) {
        if (auth === 'basic') {
            return `Basic ${btoa(APP_KEY+ ":" + APP_SECRET)}`;
        }else{
            return `Kinvey ${sessionStorage.getItem('authToken')}`;
        }
    }

    // request method (GET, POST, PUT)
    // kinvey module (user/appdata)
    // url endpoint (login, _logout, etc...)
    // authentication (basic(for register and login), kinvey)
    function makeRequest(method, module, endpoint, authentication){
        return {
            url: `${BASE_URL}${module}/${APP_KEY}/${endpoint}`,
            method: method,
            contentType: 'application/json',
            headers: {
                Authorization: makeAuthentication(authentication)
            }
        }
    }

    function get (module, endpoint, authentication){
        return $.ajax(makeRequest('GET', module, endpoint, authentication));
    }

    function post (module, endpoint, authentication, data){
        let request = makeRequest('POST', module, endpoint, authentication);
        request.data = JSON.stringify(data);
        return $.ajax(request);
    }

    function update ( module, endpoint, authentication, data){
        let request = makeRequest('PUT', module, endpoint, authentication);
        request.data = JSON.stringify(data);
        return $.ajax(request);
    }

    function remove (module, endpoint, authentication){
        return $.ajax(makeRequest('DELETE', module, endpoint, authentication));
    }

    return {
        get,
        post,
        update,
        remove,
    }
})();