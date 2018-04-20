let service = (() => {
    function listAllChirps (subs) {
        subs = JSON.stringify(subs);
        let query = `chirps?query={"author":{"$in": ${subs}}}&sort={"_kmd.ect": 1}`;
        return requester.get('appdata', query , 'kinvey');
    };

    function createChirp (author, text) {
        let data = {
            author, text
        };

        return requester.post('appdata', 'chirps', 'kinvey', data);
    }

    function deleteChirp (chirpId) {
        return requester.remove('appdata', 'chirps/'+ chirpId, 'kinvey');
    }

    function getUserChirps (username) {
        return requester.get('appdata', `chirps?query={"author":"${username}"}&sort={"_kmd.ect": 1}`, 'kinvey');
    }

    // (count the returned chirps)
    function countUserChirps (username) {
        return requester.get('appdata', `chirps?query={"author":"${username}"}`, 'kinvey');
    }

    // (count the subscribers of the user)
    function countFollowing (username) {
        return requester.get('user', `?query={"username":"${username}"}`, 'kinvey');
    }

    function getUserByName (username) {
        return requester.get('user', `?query={"username":"${username}"}`, 'kinvey');
    }

    function getUserById (userId) {
        return requester.get('user', `?query={"_id":"${userId}"}`, 'kinvey');
    }

    // (count the returned users)
    function countFollowers (username) {
        return requester.get('user', `?query={"subscriptions":"${username}"}`, 'kinvey');
    }

    // [Discover page] (remove the currently logged user)
    function getAllUsers () {
        return requester.get('user', ``, 'kinvey');
    }

    function followUnfollow (userId, subscriptions) {

        return getUserById(userId)
            .then(userFound)
            .catch(notify.handleError);

        function userFound(){
            let data = {
                subscriptions
            };
            return requester.update('user', userId, 'kinvey', data);
        }      
    }

    return {
        listAllChirps,
        createChirp,
        deleteChirp,
        countUserChirps,
        countFollowing,
        getUserById,
        countFollowers,
        getUserChirps,
        getUserById,
        getAllUsers,
        followUnfollow,
        getUserByName
    }
})()