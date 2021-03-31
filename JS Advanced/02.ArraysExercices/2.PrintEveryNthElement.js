function solve(input) {
    let step = Number(input.pop());
    let result = [];
    input.forEach((num, i) => {
        if (i % step == 0) {
            result.push(num);
        }
    });

    return result.join('\n');
}

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20', 
'2']
));

console.log(solve(['dsa',
'asd', 
'test', 
'tset', 
'2']
));