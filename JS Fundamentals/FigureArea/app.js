'use strict';

function FigureArea([top,right,bottom,left]) {
    let fig1 = top * Math.abs(right -left);
    let fig2 = left * bottom;
    let area = fig1 + fig2;
    console.log(area);
}

FigureArea(['13', '2', '5', '8']);
let n = 'abcde';
console.log(n[0,1,2]);
console.log(typeof(n));