function solution(input){
    let temLen = Number(input[0]);

    let temp = [];
    for (let i = 1; i < temLen+1; i++) {
        temp.push(input[i].split(' '));
    }

    let arr = [];
    for (let i = temLen+1; i < input.length; i++) {
        arr.push(input[i].split(' '));
    }

    let result = [];
    for (let i = 0; i < arr.length; i++) {
        let row = [];
        for(let j = 0; j<arr[i].length; j++){
            let tempRow = i % temLen;
            let tempCol = j % temp[tempRow].length
            let cell = Number(arr[i][j]) + Number(temp[tempRow][tempCol]);
            row.push(cell);
        }
        result.push(row);
    }

    let stone = ' ABCDEFGHIJKLMNOPQRSTUVWXYZ'.split('');

    let text = [];
    for (let i = 0; i < result.length; i++) {
        for(let j = 0; j<result[i].length; j++){
            let curNumber = result[i][j];
            let leter = stone[curNumber % stone.length];
            text.push(leter);
        }
    }
    console.log(text.join(''));
};


solution([ '2',
  '59 36',
  '82 52',
  '4 18 25 19 8',
  '4 2 8 2 18',
  '23 14 22 0 22',
  '2 17 13 19 20',
  '0 9 0 22 22' ]
);