$(document).ready(function attachEvents() {
    const appId = 'kid_rJhtH9S9f';
    const serviceUrl = 'https://baas.kinvey.com/appdata/' + appId;
    const kinveyUsername = 'peter';
    const kinveyPass = 'p';
    const base64auth = btoa(kinveyUsername + ':' + kinveyPass);
    const authHeaders = { 'Authorization': 'Basic ' + base64auth };

    $('#btnLoadPosts').click(btnLoadPostsClicked);
    $('#btnViewPost').click(viewPostsClicked);

    function btnLoadPostsClicked() {
        let getPostsRequest = {
            method: "GET",
            url: serviceUrl + '/posts',
            headers: authHeaders,
        };

        $.ajax(getPostsRequest)
            .then(showPostsInDropDown)
            .catch(showError);

        function showPostsInDropDown(posts) {
            for (let post of posts) {
                let option = $('<option>');
                option.text(post.title);
                option.val(post._id);
                $('#posts').append(option);
            }
        }
    }

    function showError(error) {
        let errDiv = $('<div>').text('Error: ' + error.status + ' (' + error.statusText + ')');
        $(document.body).prepend(errDiv);
        setTimeout(function () {
            errDiv.fadeOut(function () { errDiv.remove() });
        }, 2000);
    }

    function viewPostsClicked() {
        let selectedPostId = $('#posts').val();

        let postRequest = $.ajax({
            method: "GET",
            url: serviceUrl + '/posts/' + selectedPostId,
            headers: authHeaders,
        });

        let commentsRequest = $.ajax({
            method: "GET",
            url: serviceUrl + `/comments/?query={"post_id":"${selectedPostId}"}`,
            headers: authHeaders,
        });

        Promise.all([postRequest,commentsRequest])
            .then(showPostAndComments)
            .catch(showError);

        function showPostAndComments([post, comments]) {
            $('#post-title').text(post.title);
            $('#post-body').text(post.body);

            $('#post-comments').empty();
            for(comment of comments) {
                $('<li>').text(comment.text).appendTo($('#post-comments'));
            }          
        }
    }
});