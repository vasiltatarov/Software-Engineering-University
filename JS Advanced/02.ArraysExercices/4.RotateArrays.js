function solve(input, rotation) {
    for (let i = 0; i < rotation % input.length; i++) {
        input.unshift(input.pop());
    }

    return input.join(' ');
}

console.log(solve(['1', 
'2', 
'3', 
'4'], 
2
));

console.log(solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
));