function greatestCommonDivisor(a, b) {
    while (b != 0) {
        let temp = b;
        b = a % b;
        a = temp;
    }

    return a;
}

console.log(greatestCommonDivisor(15, 5));
console.log(greatestCommonDivisor(2154, 458));