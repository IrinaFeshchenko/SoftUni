function showView(viewName) {
    $('main > section').hide() // Hide all views
    $('#' + viewName).show() // Show the selected view only
}

async function showHideMenuLinks() {
    let authToken = sessionStorage.getItem('authToken');
    let headers = window.headers.unauthHeaders;
    if(authToken) {
        headers = window.headers.authHeaders;
    }

    let source = await $.get('/BuySell_2/templates/header-template.hbs');
    let compiled = Handlebars.compile(source);
    let template = compiled({headers});
    if ($('#menu').length)
        $('#menu').html(template);
    else
        $('#app').append(template);

    attachEventsToHeaders();
}

function showInfo(message) {
    let infoBox = $('#infoBox')
    infoBox.text(message)
    infoBox.show()
    setTimeout(function () {
        $('#infoBox').fadeOut()
    }, 3000)
}

function showError(errorMsg) {
    let errorBox = $('#errorBox')
    errorBox.text("Error: " + errorMsg)
    errorBox.show()
}

function showHomeView() {
    showView('viewHome')
}

function showLoginView() {
    $('#formLogin').trigger('reset')
    showView('viewLogin')
}

function showRegisterView() {
    $('#formRegister').trigger('reset')
    showView('viewRegister')
}

function showCreateAdView() {
    $('#formCreateAd').trigger('reset')
    showView('viewCreateAd')
}

function showlistAdsView() {
    $('#ads').empty();
    showView('viewAds');
    listAds();
}