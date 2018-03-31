function attachEvents() {
    const baseUrl = 'https://baas.kinvey.com/appdata/kid_Hy27Qxicf/biggestCatches/';
    const user = 'guest';
    const pass = 'guest';
    const base64auth = btoa(user + ':' + pass);
    const authorisationHeader = { 'Authorization': 'Basic ' + base64auth};

    loadAllCatches();
    $('.load').click(loadAllCatches);
    $('.add').click(createNewCatch);

    function request(method, endpoint, requestData) {
        let d = JSON.stringify(requestData);
        return $.ajax({
            method: method,
            url: baseUrl + endpoint,
            headers: authorisationHeader,
            data: JSON.stringify(requestData),
            contentType: 'application/json; charset=utf-8'
        });
    }
    
    function createNewCatch() {
        let data = createDataJson($('#addForm'));

        request('POST', '', data)
            .then(loadAllCatches)
            .catch(handleError);
    }

    function loadAllCatches() {
        console.log('loadAllCatches');
        request('GET','')
            .then(displayAllCatches)
            .catch(handleError);
    }

    function displayAllCatches(data) {
        let catches = $('#catches')
        catches.empty();
        for (el of data) {
            catches.append(
                $(`<div class="catch" data-id="${el._id}">`)
                .append($('<label>').text('Angler'))
                .append($(`<input type="text" class="angler" value="${el.angler}"/>`))
                .append($('<label>').text('Weight'))
                .append($(`<input type="number" class="weight" value="${el.weight}"/>`))
                .append($('<label>').text('Species'))
                .append($(`<input type="text" class="species" value="${el.species}"/>`))
                .append($('<label>').text('Location'))
                .append($(`<input type="text" class="location" value="${el.location}"/>`))
                .append($('<label>').text('Bait'))
                .append($(`<input type="text" class="bait" value="${el.bait}"/>`))
                .append($('<label>').text('Capture Time'))
                .append($(`<input type="number" class="captureTime" value="${el.captureTime}"/>`))
                .append($('<button class="update">Update</button>').click(updateCatch))
                .append($('<button class="delete">Delete</button>').click(deleteCatch))
            );
        }
    }

    function updateCatch() {
        let catchEl = $(this).parent();
        let dataObj = createDataJson(catchEl);
        let id = catchEl.attr('data-id');
        console.log('updateCatch');
        request('PUT', id, dataObj)
            .then(loadAllCatches)
            .catch(handleError);
        
    }

    function deleteCatch() {
        let id = $(this).parent().attr('data-id');

        request('DELETE', id)
            .then(loadAllCatches)
            .catch(handleError);
    }

    function createDataJson(el) {
        return {
            angler: el.find('.angler').val(),
            weight: +el.find('.weight').val(),
            species: el.find('.species').val(),
            location: el.find('.location').val(),
            bait: el.find('.bait').val(),
            captureTime: +el.find('.captureTime').val(),
        }
    }

    function handleError(err) {
        console.log('handleError');
        alert(`ERROR: ${err.statusText}`);
    }
}