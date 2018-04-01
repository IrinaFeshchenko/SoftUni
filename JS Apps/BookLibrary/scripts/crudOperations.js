const BASE_URL = 'https://baas.kinvey.com/';
const APP_KEY = 'kid_H1rqLNC5z';
const APP_SECRET = '80fbbe537a3d4fc7bce845069a0d3154';
const AUTH_HEADERS = { 'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET) };
const BOOKS_PER_PAGE = 5;

function loginUser() {
    let userData = {
        username: $('#formLogin input[name=username]').val(),
        password: $('#formLogin input[name=passwd]').val()
    };
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/login',
        headers: AUTH_HEADERS,
        data: JSON.stringify(userData),
        contentType: 'application/json',
        success: loginSuccess,
        error: handleAjaxError
    });

    function loginSuccess(userInfo) {
        saveAuthInSession(userInfo);
        showHideMenuLinks();
        listBooks();
        showInfo('Login successful.');
    }
}

function registerUser() {
    let userData = {
        username: $('#formRegister input[name=username]').val(),
        password: $('#formRegister input[name=passwd]').val()
    };

    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/',
        headers: AUTH_HEADERS,
        data: JSON.stringify(userData),
        contentType: 'application/json',
        success: registerUserSuccess,
        error: handleAjaxError
    });

    function registerUserSuccess(userInfo) {
        saveAuthInSession(userInfo);
        showHideMenuLinks();
        listBooks();
        showInfo('User registration successful.');
    }
}

function getKinveyUserAuthHeaders() {
    return {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    }
 };

function listBooks() {
    $('#books').empty();
    showView('viewBooks');

    $.ajax({
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
        headers: getKinveyUserAuthHeaders(),
        success: loadBooksSuccess,
        error: handleAjaxError
    });

    function loadBooksSuccess(books) {
        showInfo('Books Loaded.');
        if (books.length === 0) {
            $('#books').text('No books in the libratry.');
        }
        else {
            displayPaginationAndBooks(books.reverse());
        }  
    }
}

function createBook() {
    let bookData = {
        title: $('#formCreateBook input[name=title]').val(),
        author: $('#formCreateBook input[name=author]').val(),
        description: $('#formCreateBook textarea[name=description]').val()
    };

    $.ajax({
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
        headers: getKinveyUserAuthHeaders(),
        contentType: 'application/json',
        data: JSON.stringify(bookData),
        success: createBookSuccess,
        error: handleAjaxError
    });

    function createBookSuccess(response) {
        listBooks();
        showInfo('Book created.');
    }
}

function deleteBook(book) {
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + book._id,
        headers: getKinveyUserAuthHeaders(),
        success: deleteBookSuccess,
        error: handleAjaxError
    })

    function deleteBookSuccess(response) {
        listBooks();
        showInfo('Book deleted.');
    }
}

function loadBookForEdit(book) {
    $.ajax({
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + book._id,
        headers: getKinveyUserAuthHeaders(),
        success: loadBookForEditSuccess,
        error: handleAjaxError
    });

    function loadBookForEditSuccess(book) {
        $('#formEditBook input[name=id]').val(book._id);
        $('#formEditBook input[name=title]').val(book.title);
        $('#formEditBook input[name=author]').val(book.author);
        $('#formEditBook textarea[name=description]').val(book.description);
        showView('viewEditBook');
    }
}

function editBook() {
    let bookData = {
        title: $('#formEditBook input[name=title]').val(),
        author: $('#formEditBook input[name=author]').val(),
        description: $('#formEditBook textarea[name=description]').val()
    };

    $.ajax({
        method: 'PUT',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + $('#formEditBook input[name=id]').val(),
        headers: getKinveyUserAuthHeaders(),
        contentType: 'application/json',
        data: JSON.stringify(bookData),
        success: editBookSuccess,
        error: handleAjaxError
    });

    function editBookSuccess(response) {
        listBooks();
        showInfo('Book edited.');
    }
}

function saveAuthInSession(userInfo) {
    let userAuth = userInfo._kmd.authtoken;
    sessionStorage.setItem('authToken', userAuth);
    let userId = userInfo._id;
    sessionStorage.setItem('userId', userId);
    let username = userInfo.username;
    sessionStorage.setItem('username', username);
    $('#loggedInUser').text('Wellcome, ' + username + '!');
}

function logoutUser() {
    sessionStorage.clear();
    $('#loggedInUser').text('');
    showHideMenuLinks();
    showView('viewHome');
    showInfo('Logout successful.');
}

function signInUser(res, message) {
    // TODO
}

function displayPaginationAndBooks(books) {
    let pagination = $('#pagination-demo')
    if(pagination.data("twbs-pagination")){
        pagination.twbsPagination('destroy')
    }
    pagination.twbsPagination({
        totalPages: Math.ceil(books.length / BOOKS_PER_PAGE),
        visiblePages: 5,
        next: 'Next',
        prev: 'Prev',
        onPageClick: function (event, page) {
            $('#books').empty();
            let booksTable = $('<table>')
                .append($('<tr>').append('<th>Title</th><th>Author</th><th>Description</th><th>Actions</th>'));
            let startBook = (page - 1) * BOOKS_PER_PAGE
            let endBook = Math.min(startBook + BOOKS_PER_PAGE, books.length)
            $(`a:contains(${page})`).addClass('active')
            for (let i = startBook; i < endBook; i++) {
                appendBookRow(books[i], booksTable);
            }
            $('#books').append(booksTable);
        }
    });

    function appendBookRow(book, booksTable) {
        let links = [];

        if (book._acl.creator === sessionStorage['userId']) {
            let deleteLink = $('<a href="#">[Delete]</a>').click(deleteBook.bind(this, book));
            let editLink = $('<a href="#">[Edit]</a>').click(loadBookForEdit.bind(this, book));
            links = [deleteLink, ' ', editLink];
        }

        booksTable.append($('<tr>').append(
            $('<td>').text(book.title),
            $('<td>').text(book.author),
            $('<td>').text(book.description),
            $('<td>').append(links)
        ));
    }
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response)
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error."
    if (response.responseJSON && response.responseJSON.description)
        errorMsg = response.responseJSON.description
    showError(errorMsg)
}