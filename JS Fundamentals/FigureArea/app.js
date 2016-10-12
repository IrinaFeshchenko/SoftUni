'use strict';

function FigureArea([w,h,W,H]) {
    let fig1 = w * h;
    let fig2 = W * H;
    let overlap = Math.min(w,W) * Math.min(h,H);
    let area = fig1 + fig2 - overlap;
    console.log(area);
}

FigureArea(['2', '4', '5', '3']);
let n = 'abcde';
console.log(n[0,1,2]);
console.log(typeof(n));