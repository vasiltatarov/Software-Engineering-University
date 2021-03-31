function sort(numbers) {
    numbers.sort((a, b) => a - b);
    let result = [];

    while (numbers.length != 0) {
        let min = numbers.shift();
        let max = numbers.pop();

        if (min != undefined) {
            result.push(min);
        }
        if (max != undefined) {
            result.push(max);
        }
    }

    return result;
}

console.log(sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));