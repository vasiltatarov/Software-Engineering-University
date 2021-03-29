function evenPosition(inputArr) {
    let evenPositionNumbers = [];

    for (let i = 0; i < inputArr.length; i += 2) {
        evenPositionNumbers.push(inputArr[i]);
    }

    return evenPositionNumbers.join(' ');
}

console.log(evenPosition(['20', '30', '40', '50', '60']));
console.log(evenPosition(['5', '10']));