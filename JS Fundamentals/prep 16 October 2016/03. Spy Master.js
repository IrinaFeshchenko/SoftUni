function solution(rows){
    let key = rows[0];
    let rgx = new RegExp(`(^|\\s)(${key}\\s+)([A-Z!%$#]{8,})([\\s|.|,|$])`,'gi')

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
                    .replace(/\$/g,4);
    }
};

solution(['specialKey',
'In this text the specialKey HELLOWORLD! is correct, but',
'the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while',
'SpeCIaLkeY   SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!']
);
