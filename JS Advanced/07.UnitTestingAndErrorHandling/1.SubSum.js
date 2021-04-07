function subSum(arr, start, end) {
    if (!Array.isArray(arr)) {
        return NaN;
    }
    return arr.slice(start < 0 ? 0 : start, end + 1)
            .reduce((acc, curr) => acc + Number(curr), 0);
}

console.log(subSum([10, 20, 30, 40, 50, 60], 3, 300));
console.log(subSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(subSum([10, 'twenty', 30, 40], 0, 2));
console.log(subSum([], 1, 2));
console.log(subSum('text', 0, 2));