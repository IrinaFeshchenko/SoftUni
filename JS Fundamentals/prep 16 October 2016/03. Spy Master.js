function solution(rows){
    let key = rows[0];
    let rgx = new RegExp(`(^| )(${key}\\s+)([A-Z!%$#]{8,})( |\\.|,|$)`,'gi')

    let result = [];
    for(let i = 1; i<rows.length; i++){
        let row = rows[i];
        let match;
        let current;

        while (match = rgx.exec(row)){          
            let encodedWord = match[3];

            if(encodedWord === encodedWord.toUpperCase()){
                let decodedWord = decode(encodedWord);
                let decodedMatch = match[1] + match[2] + decodedWord + match[4];
                row = row.replace(match[0], decodedMatch);
            }
        }
        
        console.log(row);
    }

    function decode(encodedWord){
    return encodedWord.replace(/!/g,1)
                    .replace(/%/g,2)
                    .replace(/#/g,3)
                    .replace(/\$/g,4)
                    .toLowerCase();
    }
};

solution(['secret',
    'Random text with secrets EVERYWHERE',
    'secret HEREHERE and one secret OVERTHEREANDEVERYWHERE',
    'secret SECRETTIME, and secret KINDATHERE.',
    'secret ONELINER',
    'and maybe secret FALSESE or secret TRUESECRET or secret ENDONCOMA,',
    'here are three secrets one secret OVERHERE, one secret OVERTHERE and one secret DISSAPPOINT]']
);
