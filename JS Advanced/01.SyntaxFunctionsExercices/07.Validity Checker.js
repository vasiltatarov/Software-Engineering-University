//d=√((x_2-x_1)²+(y_2-y_1)²) 
function validityChecker(x1, y1, x2, y2) {

    function getResult(x1, y1, x2, y2) {
        const a = Math.pow((x2 - x1), 2);
        const b = Math.pow((y2 - y1), 2);
        const distance = Math.sqrt(a + b);
        
        return (distance === Math.round(distance)) ? 'valid' : 'invalid';
    }

    return `{${x1}, ${y1}} to {0, 0} is ${getResult(x1, y1, 0, 0)}` + '\n' +
    `{${x2}, ${y2}} to {0, 0} is ${getResult(x2, y2, 0, 0)}` + '\n' +
    `{${x1}, ${y1}} to {${x2}, ${y2}} is ${getResult(x1, y1, x2, y2)}`;
}

console.log(validityChecker(3, 0, 0, 4));
console.log(validityChecker(2, 1, 1, 1));