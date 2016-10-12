'use strict';
function LetterOccurrencesInString(input) {
    let str = input[0];
    let letter = input[1];

    let count = 0;
    for(let i of str) {
        if (i == letter) {
            count++;
        }
    }
    console.log(count);
}

LetterOccurrencesInString(['hello', 'l'])