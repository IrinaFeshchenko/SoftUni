const BASE_URL = 'https://baas.kinvey.com/';
const APP_KEY = 'kid_Hk0gVoCqM';
const APP_SECRET = '57c2b140875b418999dfc539e4d6cc85';
const AUTH_HEADERS = { 'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET) };
const ITEMS_PER_PAGE = 5;

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
        showlistAdsView();
        showInfo('User registration successful.');
    }
}

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
        showlistAdsView();
        showInfo('Login successful.');
    }
}

function logoutUser() {
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/_logout',
        headers: getKinveyUserAuthHeaders(),
        success: logoutSuccess,
        error: handleAjaxError
    });
    function logoutSuccess() {
        sessionStorage.clear();
        $('#loggedInUser').text('');
        showHideMenuLinks();
        showView('viewHome');
        showInfo('Logout successful.');
    }
}

// Save authentication to session
function saveAuthInSession(userInfo) {
    let userAuth = userInfo._kmd.authtoken;
    sessionStorage.setItem('authToken', userAuth);
    let userId = userInfo._id;
    sessionStorage.setItem('userId', userId);
    let username = userInfo.username;
    sessionStorage.setItem('username', username);
    $('#loggedInUser').text('Wellcome, ' + username + '!');
}

// Get token from session
function getKinveyUserAuthHeaders() {
    return {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken')
    }
};

function listAds() {
    $.ajax({
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads',
        headers: getKinveyUserAuthHeaders(),
        success: loadAdsSuccess,
        error: handleAjaxError
    });
    function loadAdsSuccess(ads) {
        showInfo('Ads Loaded.');
        if (ads.length === 0) {
            $('#ads').text('No advertisements available.');
        }
        else {
            displayPaginationAndAds(ads.reverse());
        }
    }
}

function createAd() {
    let adData = {
        title: $('#formCreateAd input[name=title]').val(),
        description: $('#formCreateAd textarea[name=description]').val(),
        publishDate: $('#formCreateAd input[name=datePublished]').val(),
        price: $('#formCreateAd input[name=price]').val(),
        publisher: sessionStorage.getItem('username')
    };
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads',
        headers: getKinveyUserAuthHeaders(),
        contentType: 'application/json',
        data: JSON.stringify(adData),
        success: createAdSuccess,
        error: handleAjaxError
    });
    function createAdSuccess(response) {
        showlistAdsView();
        showInfo('Ad created.');
    }
}

function loadAdForEdit(ad) {
    $.ajax({
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads/' + ad._id,
        headers: getKinveyUserAuthHeaders(),
        success: loadAdForEditSuccess,
        error: handleAjaxError
    });
    function loadAdForEditSuccess(ad) {
        $('#formEditAd input[name=id]').val(ad._id);
        $('#formEditAd input[name=title]').val(ad.title);
        $('#formEditAd input[name=author]').val(ad.author);
        $('#formEditAd textarea[name=description]').val(ad.description);
        $('#formEditAd input[name=datePublished]').val(ad.publishDate);
        $('#formEditAd input[name=price]').val(ad.price);
        showView('viewEditAd');
    }
}

function editAd() {
    let adData = {
        title: $('#formEditAd input[name=title]').val(),
        description: $('#formEditAd textarea[name=description]').val(),
        publishDate: $('#formEditAd input[name=datePublished]').val(),
        price: $('#formEditAd input[name=price]').val(),
        publisher: sessionStorage.getItem('username')
    };
    $.ajax({
        method: 'PUT',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads/' + $('#formEditAd input[name=id]').val(),
        headers: getKinveyUserAuthHeaders(),
        contentType: 'application/json',
        data: JSON.stringify(adData),
        success: editAdSuccess,
        error: handleAjaxError
    });

    function editAdSuccess(response) {
        showlistAdsView();
        showInfo('Ad edited.');
    }
}

function deleteAd(ad) {
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/ads/' + ad._id,
        headers: getKinveyUserAuthHeaders(),
        success: deleteAdSuccess,
        error: handleAjaxError
    })

    function deleteAdSuccess(response) {
        showlistAdsView();
        showInfo('Ad deleted.');
    }
}

// Error handling
function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response)
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error."
    if (response.responseJSON && response.responseJSON.description)
        errorMsg = response.responseJSON.description
    showError(errorMsg)
}

// Pagination
function displayPaginationAndAds(ads) {
    let pagination = $('#pagination')
    if (pagination.data("twbs-pagination")) {
        pagination.twbsPagination('destroy')
    }

    pagination.twbsPagination({
        totalPages: Math.ceil(ads.length / ITEMS_PER_PAGE),
        visiblePages: 5,
        next: 'Next',
        prev: 'Prev',
        onPageClick: function (event, page) {
            $('#ads').empty();
            // Table headers
            let adsTable = $('<table>')
                .append($('<tr>').append('<th>Title</th><th>Description</th><th>Publisher</th><th>Date Published</th><th>Price</th><th>Actions</th>'));

            let startAd = (page - 1) * ITEMS_PER_PAGE
            let endAd = Math.min(startAd + ITEMS_PER_PAGE, ads.length);
            $(`a:contains(${page})`).addClass('active');

            for (let i = startAd; i < endAd; i++) {
                appendRow(ads[i], adsTable);
            }

            $('#ads').append(adsTable);
        }
    });

    // Attach table rows
    function appendRow(ad, adsTable) {
        let links = [];

        if (ad._acl.creator === sessionStorage['userId']) {
            let deleteLink = $('<a href="#">[Delete]</a>').click(deleteAd.bind(this, ad));
            let editLink = $('<a href="#">[Edit]</a>').click(loadAdForEdit.bind(this, ad));
            links = [deleteLink, ' ', editLink];
        }

        adsTable.append($('<tr>').append(
            $('<td>').text(ad.title),
            $('<td>').text(ad.description),
            $('<td>').text(ad.publisher),
            $('<td>').text(ad.publishDate),
            $('<td>').text(ad.price),
            $('<td>').append(links)
        ));
    }
}