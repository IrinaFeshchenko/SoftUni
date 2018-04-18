let service = (() => {
    function listAllPosts () {
        return requester.get('appdata', 'posts?query={}&sort={"_kmd.ect": -1}', 'kinvey');
    }

    function createPost (author, title, description, url, imageUrl) {
        let postData = {
            author, title, description, url, imageUrl
        };

        return requester.post('appdata', 'posts', 'kinvey', postData);
    }

    function editPost (postId, author, title, description, url, imageUrl) {
        let postData = {
            author, title, description, url, imageUrl
        };

        return getPostDetails(postId)
            .then(postFound)
            .catch(notify.handleError);

        function postFound(){
            return requester.update('appdata', 'posts/' + postId, 'kinvey', postData);
        }      
    }

    function deletePost (postId) {
        return requester.remove('appdata', 'posts/'+ postId, 'kinvey');
    }

    function getMyPosts (username) {
        return requester.get('appdata', `posts?query={"author":"${username}"}&sort={"_kmd.ect": -1}`, 'kinvey');
    }

    function getPostDetails(postId) {
        return requester.get('appdata', 'posts/'+ postId, 'kinvey');
    }

    function getPostComments (postId) {
        return requester.get('appdata', `comments?query={"postId":"${postId}"}&sort={"_kmd.ect": -1}`, 'kinvey');
    }

    function createComment (postId, content, author) {
        let commentData = {
            postId, content, author
        };

        return requester.post('appdata', 'comments', 'kinvey', commentData);
    }

    function deleteComment (commentId) {
        return requester.remove('appdata', 'comments/'+ commentId, 'kinvey');
    }

    return {
        listAllPosts,
        createPost,
        editPost,
        deletePost,
        getMyPosts,
        getPostDetails,
        getPostComments,
        createComment,
        deleteComment
    }
})()