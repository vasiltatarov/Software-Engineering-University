function aggregateElements(arr) {
    const sum = arr.reduce((a, b) => a + b, 0);

    let inverseValuesSum = 0;

    for (let i = 0; i < arr.length; i++) {
        inverseValuesSum += 1 / arr[i];
    }

    const arrConcat = arr.join('');

    console.log(sum);
    console.log(inverseValuesSum);
    console.log(arrConcat);
}

aggregateElements([1, 2, 3]);

aggregateElements([2, 4, 8, 16]);