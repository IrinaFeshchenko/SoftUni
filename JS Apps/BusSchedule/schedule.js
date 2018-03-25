function solve() {
    let next = 'depot';
    let name = '';
    let baseUrl = 'https://judgetests.firebaseio.com/schedule/';

    function depart() {
        $('#depart').prop("disabled", true);
        $('#arrive').prop("disabled", false);

        $.get(baseUrl + next + '.json')
            .then(showInfo)
            .catch(showError);
    }

    function arrive() {
        $('#depart').prop("disabled", false);
        $('#arrive').prop("disabled", true);
        $('#info span').text('Arriving at ' + name);
    }

    function showInfo(data) {
        name = data['name'];
        next = data['next'];
        $('#info span').text('Next stop ' + name);
    }

    function showError() {
        $('#depart').prop("disabled", true);
        $('#arrive').prop("disabled", true);
        $('#info span').text('Error');
    }

    return {
        depart,
        arrive
    };
}

let result = solve();