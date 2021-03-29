function biggestElement(matrix) {
    let result = -100000;

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            let curr = matrix[i][j];
            if (curr > result) {
                result = curr;
            }
        }
    }

    return result;
}

console.log(biggestElement([
    [20, 50, 10],
    [8, 33, 145]]
));

console.log(biggestElement([
    [3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
));