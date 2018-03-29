$(document).ready(function attachEvents() {
    let locationsUrl = 'https://judgetests.firebaseio.com/locations.json';
    let curWeatherUrl = 'https://judgetests.firebaseio.com/forecast/today/';
    let threeDayForecastUrl = 'https://judgetests.firebaseio.com/forecast/upcoming/';
    $('#location').val('London');
    $('#submit').click(getForecast);

    function getForecast() {

        $.get(locationsUrl).then(getForecast).catch(showError);

        function getForecast(locations) {
            let selectedLocation = $('#location').val();
            let locationCode = locations.filter(loc => loc.name === selectedLocation).map(loc => loc.code);
            if (!locationCode) {
                showError('locationCode not found.');
            }

            let curWeatherReq = $.get(curWeatherUrl + locationCode + '.json');
            let threeDayForecastReq = $.get(threeDayForecastUrl + locationCode + '.json');
            Promise.all([curWeatherReq, threeDayForecastReq]).then(showForecast).catch(showError);
        };
    };

    function showForecast([curWeather, threeDayForecast]) {
        $('#forecast').css('display','block');

        let weatherSimbols = {
            'Sunny': '&#x2600;', // ☀
            'Partly sunny': '&#x26C5;', // ⛅
            'Overcast': '&#x2601;', // ☁
            'Rain': '&#x2614;', // ☂
            'Degrees': '&#176;'   // °
        }

        displayCurrent(curWeather);
        displayUpcoming(threeDayForecast);

        function displayCurrent(curWeather) {
            let current = $('#current');
            current.empty();
            current.append($('<div class="label">Current conditions</div>'));
            current.append($(`<span class="condition symbol">${weatherSimbols[curWeather.forecast.condition]}</span>"`));
            current.append($('<span class="condition">')
                .append(`<span class="forecast-data">${curWeather.name}</span>`)
                .append(`<span class="forecast-data">${curWeather.forecast.low}${weatherSimbols['Degrees']}/${curWeather.forecast.high}${weatherSimbols['Degrees']}</span>`)
                .append(`<span class="forecast-data">${curWeather.forecast.condition}</span>`));

        }

        function displayUpcoming(threeDayForecast) {
            let upcoming = $('#upcoming');
            upcoming.empty();
            upcoming.append($('<div class="label">Three-day forecast</div>'));

            for (day of threeDayForecast.forecast) {
                upcoming.append($('<span class="upcoming"></span>')
                    .append($(`<span class="symbol">${weatherSimbols[day.condition]}</span>`))
                    .append(`<span class="forecast-data">${day.low}${weatherSimbols['Degrees']}/${day.high}${weatherSimbols['Degrees']}</span>`)
                    .append(`<span class="forecast-data">${day.condition}</span>`));  
            }
        }
    }

    function showError(error) {
        if (error.status) {
            console.log(`Error: ${error.status} ${error.statusText}`);
        }
        else {
            console.log(error);
        }
    }
});