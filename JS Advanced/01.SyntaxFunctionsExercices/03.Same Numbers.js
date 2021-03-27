function sameNumbers(number) {
    let numbersStr = number.toString();
    let isSame = true;
    let sum = 0;

    for (let i = 0; i < numbersStr.length; i++) {
        let next = numbersStr[i + 1];
        if (numbersStr[i] !== numbersStr[i + 1] && next != undefined) {
            isSame = false;
        }
        sum += Number(numbersStr[i]);
    }

    return `${isSame}\n${sum}`;
}

console.log(sameNumbers(2222222));
console.log(sameNumbers(1234));