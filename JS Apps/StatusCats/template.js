$(() => {
    
    renderCatTemplate();
    async function renderCatTemplate() {

        let source = await $.get('./cat-template.hbs');
        let compiled = Handlebars.compile(source);
        let template = compiled({cats: window.cats});
        $('#allCats').append(template);

        $('.btn,.btn-primary').on('click',(ev) => {
            let targetBtn = $(ev.target);
            let divInfo = targetBtn.next();
            let btnText = targetBtn.text();

            if(btnText.includes('Show')){
                divInfo.show();
                targetBtn.text('Hide status code');
            }
            else{
                divInfo.hide();
                targetBtn.text('Show status code');
            }
            
        })
    }
})
