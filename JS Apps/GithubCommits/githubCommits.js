function loadCommits() { 
    let username = $('#username').val();
    let repo = $('#repo').val();
    let url = 'https://api.github.com/repos/' + username + '/' + repo + '/commits';

    $('#commits').empty();

    $.get(url)
        .then(showCommits)
        .catch(showError);

    function showCommits(data) {
        for (let commit of data) {
            $('#commits')
                .append($('<li>')
                .text(commit.commit.author.name + ': ' + commit.commit.message));
        }
    }

    function showError(err) {
        $('#commits').append($('<li>')
                .text('Error: '+ err.status + ' (' + err.statusText + ')'));
    }
};