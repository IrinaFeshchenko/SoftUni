function solution(input){
    let list = new Map;
    let subs = new Map;

    for (const command of input) {

        if(command.indexOf('-') === -1) {
            if(!list.has(command)){
                list.set(command,[]);
                subs.set(command,0);
            }          
        }else{
            [first,second] = command.split('-');

            if (list.has(first) && 
                list.has(second) &&
                first !== second &&
                list.get(second).indexOf(first) === -1){

                list.get(second).push(first);
                let count = subs.get(first);
                subs.set(first, count +1);
            }
        }
    }

    let winner = Array.from(list).sort((a,b)=> {
        let result = b[1].length - a[1].length

        if (result === 0) {
            return subs.get(b[0]) - subs.get(a[0]);
        }else{
            return result
        }
    })[0];

    console.log(winner[0]);

    let i = 1;
    for (const sub of winner[1]) {

        console.log(i+'. '+sub);
        i++
    }
};

solution(['A',
    'B',
    'C',
    'D',
    'A-B',
    'B-A',
    'C-A',
    'D-A',
    ]);