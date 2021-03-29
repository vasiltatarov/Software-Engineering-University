function diagonalSum(matrix) {
    let mainDiagonal = 0;
    let secondDiagonal = 0;

    for (let i = 0; i < matrix.length; i++) {
        mainDiagonal += matrix[i][i];
        secondDiagonal += matrix[i][matrix.length - i - 1];
    }

    return `${mainDiagonal} ${secondDiagonal}`;
}

console.log(diagonalSum([
    [20, 40],
    [10, 60]]
));

console.log(diagonalSum([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
));