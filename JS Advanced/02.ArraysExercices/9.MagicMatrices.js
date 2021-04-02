function magicMatrix(matrix) {
    const set = new Set();

    for (let i = 0; i < matrix.length; i++) {
        //current row sum
        set.add(arraySum(matrix[i]));
        //column sums of current row
        set.add(arraySum(matrix.map(x => x[i])));

        if (set.size > 1) {
            return false;
        }
    }

    function arraySum(arr) {
        return arr.reduce((acc, curr) => acc += curr);
    }

    return true;
}

console.log(magicMatrix([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   ));
console.log(magicMatrix([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   ));
console.log(magicMatrix([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
   ));