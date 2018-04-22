function solution (str) {
    let match = /^<message((?:\s+[a-z]+="[A-Za-z0-9 .]+")+)>((?:.|\n)+)<\/message>$/.exec(str);
    if (match !== null){
        let attributes = match[1];
        let to = /\bto="([A-Za-z0-9 .]+)"/.exec(attributes)
        let from = /\bfrom="([A-Za-z0-9 .]+)"/.exec(attributes);
        let message = match[2];
        if(to !== null && from !== null) {
            let p = message.split('\n').map(x=>`<p>${x}</p>`).join('\n\t');
            let result = `
<article>
    <div>From: <span class="sender">${from[1]}</span></div>
    <div>To: <span class="recipient">${to[1]}</span></div>
    <div>
        ${p}
    </div>
</article>`;
          console.log(result);
        }else {
            console.log('Missing attributes')
        }
    }else{
        console.log('Invalid message format');
    }
}

solution(`<message to="Bob" from="Alice" timestamp="1497254092">Hey man, what's up?</message>`);