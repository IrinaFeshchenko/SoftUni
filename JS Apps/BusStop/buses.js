function getInfo() {

    let key = $('#stopId').val();
    const baseUrl = 'https://judgetests.firebaseio.com/businfo/';

    let infoRequest = {
        url: baseUrl + key + '.json',
        method: 'GET'
    }

    $.ajax(infoRequest)
        .then(showInfo)
        .catch(showError);

    function showInfo(info) {
        let name = info['name'];
        let buses = Object.keys(info['buses']);
        $('#stopName').text(name);
        for (let bus of buses) {
            let time = info['buses'][bus];
            let li = $('<li>');
            li.appendTo($('#buses'));
            li.append(`Bus ${bus} arrives in ${time} minutes`);
        }
    }

    function showError() {
        $('#stopName').text('Error');
    }
};