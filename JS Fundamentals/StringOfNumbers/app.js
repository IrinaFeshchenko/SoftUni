'use strict';

function StringOfNumbers([n]) {

    let num = Number(n);
    let result="";
    for (let i = 1; i <= num; i++) {
        result = result + i;
    }
    console.log(result);
}

StringOfNumbers(['11']);