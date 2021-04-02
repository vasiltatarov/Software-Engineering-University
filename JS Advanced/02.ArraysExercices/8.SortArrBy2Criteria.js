function sort(arr) {
    arr.sort((a, b) => sortWords(a, b));

    function sortWords(a, b) {
        let result = a.length - b.length;
        if (result == 0) {
            result = a.localeCompare(b);
        }
        return result;
    }

    return arr.join('\n');
}

console.log(sort(['alpha', 
'beta', 
'gamma']
));

console.log(sort(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
));

console.log(sort(['test', 
'Deny', 
'omen', 
'Default']
));