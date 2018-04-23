function solution(arr){
    nums = arr.map(Number);
    let biggestProduct = Number.MIN_SAFE_INTEGER; 

    for (let i = 0; i < nums.length; i++) {
        let current = nums[i];

        if(current >= 0 && current < 10 ) {

            let currentResult = 1;
            let to = Math.min(i+current, nums.length -1)
            for (let j = i+1; j <= to; j++) {
                let numberToMultiply = nums[j];
                currentResult *= numberToMultiply;
            }

            if (currentResult > biggestProduct ){
                biggestProduct = currentResult;
            }
        }
    }
    console.log(biggestProduct);
};

solution(['100', '200', '2', '3', '2', '3', '2', '1', '1' ]);