$(document).ready(()=> {
    $('#btnLoadTowns').on('click',showTowns);

    function showTowns(){
        let data = $('#towns').val()
            .split(',')
            .map(t => ({name: t.trim()}))
            .filter(t => t.name != '');

        townTemplate(data);     
    };

    async function townTemplate(data){
        let file = await $.get('town-template.hbs');
        let template = Handlebars.compile(file);
        let ctx = {data:data};
        let html = template(ctx);
        $('#root').append(html);
    }  
});