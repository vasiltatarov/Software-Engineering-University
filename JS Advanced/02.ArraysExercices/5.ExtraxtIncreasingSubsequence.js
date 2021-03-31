function solve(arr) {
    return arr.reduce(function (result, currNum) {
        if (currNum >= result[result.length - 1] || result.length === 0) {
            result.push(currNum);
        }
        return result;
    }, []);
}

console.log(solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
));

console.log(solve([1, 
    2, 
    3,
    4]    
));

console.log(solve([20, 
    3, 
    2, 
    15,
    6, 
    1] 
));