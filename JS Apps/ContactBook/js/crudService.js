'use strict'

let crudService = (() => {
    const module = 'appdata';
    const endpoint = 'contacts';
    const authentication = 'Kinvey'

    // Create data in kinvey
    function createContacts(data) {
        return remote.post(module, endpoint, authentication, data);       
    }

    function getContacts() {
        return remote.get(module, endpoint, authentication);
    }

    return {
        createContacts,
        getContacts
    }
})();