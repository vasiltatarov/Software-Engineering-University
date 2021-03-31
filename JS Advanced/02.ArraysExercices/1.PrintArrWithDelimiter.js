function printArr(input) {
    let delimiter = input.pop();
    console.log(input.join(delimiter));
}

printArr(
    [
        'One',
        'Two',
        'Three',
        'Four',
        'Five',
        '-'
    ]);

printArr(
    [
        'How about no?',
        'I',
        'will',
        'not',
        'do',
        'it!',
        '_'
    ]);