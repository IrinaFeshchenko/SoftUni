function solution (arr) {

    let numbers = [];

    for (let i = 0; i < arr.length; i++) {
        let current = arr[i];
        if (typeof current === 'number'){
            numbers.push(current);
        }else{
            if(numbers.length > 1){
                let num2 = numbers.pop();
                let num1 = numbers.pop();

                switch(current){
                    case '+': numbers.push(num1 + num2); break;
                    case '-': numbers.push(num1 - num2); break;
                    case '*': numbers.push(num1 * num2); break;
                    case '/': numbers.push(num1 / num2); break;
                    default: break;
                }
            }else{
                console.log('Error: not enough operands!');
                return;
            }
        }
    }
    numbers.length > 1 ? console.log('Error: too many operands!') : console.log(numbers[0]);
}

solution([5, 3, 4, '*', '-']);