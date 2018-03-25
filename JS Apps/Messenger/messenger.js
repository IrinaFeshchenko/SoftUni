$(function attachEvents() {
    const baseUrl = 'https://phonebook-194ba.firebaseio.com/messenger';
    $('#submit').click(sendMessage);
    $('#refresh').click(refresh);

    function sendMessage() {
        let name = $('#author').val();
        let message = $('#content').val();

        let data = {
            author: name,
            content: message,
            timestamp: Date.now()
        };
        
        let request = {
            url: baseUrl + '.json',
            method: 'POST',
            data: JSON.stringify(data)
        };

        $.ajax(request)
            .then(getAllPosts)
            .catch(showError);
    }

    function getAllPosts() {
        $.get(baseUrl + '.json')
            .then(showAllPosts)
            .catch(showError);
    }

    function showAllPosts(posts) {
        let textarea = $('#messages');
        let messages = '';
        for (let key in posts) {
            let post = posts[key];

            let author = post['author'];
            let content = post['content'];

            messages += author + ': ' + content + '\n'
            textarea.text(messages);
        }
    }

    function showError() {
        alert('Error');
    }

    function refresh() {
        getAllPosts();
    }
});