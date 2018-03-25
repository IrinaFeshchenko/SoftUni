$(function attachEvents() {
    $('#btnLoad').click(loadContacts);
    $('#btnCreate').click(createContact);
    const baseUrl = 'https://phonebook-nakov.firebaseio.com/phonebook';

    function createContact() {    
        let contact = {
            person: $('#person').val(),
            phone: $('#phone').val()
        };
        $('#person').val('');
        $('#phone').val('');

        let createRequest = {
            method: 'POST',
            url: baseUrl + '.json',
            data: JSON.stringify(contact),
        }
        $.ajax(createRequest)
            .then(loadContacts)
            .catch(displayError);
    }

    function loadContacts() {
        $('#phonebook').empty();
        $.get(baseUrl + '.json')
            .then(displayContacts)
            .catch(displayError);
    }

    function displayContacts(contacts) {
        let keys = Object.keys(contacts);

        for (let key of keys) {
            let contact = contacts[key];
            if (contact.person) {
                let li = $('<li>');
                li.text(contact.person + ':' + contact.phone);
                li.appendTo($('#phonebook'));
                li.append(' ');
                li.append(
                    $('<button>Delete</button>').click(function () {
                        deleteContact(key);
                    })
                );
            }
        }
    }

    function displayError() {
        $('#phonebook').append('<li>Error</li>');
    }

    function deleteContact(key) {
        let delRequest = {
            method: "DELETE",
            url: baseUrl + '/' + key + ".json"
        };
        $.ajax(delRequest)
            .then(loadContacts)
            .catch(displayError);
    }
});