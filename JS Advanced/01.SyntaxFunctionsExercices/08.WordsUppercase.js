function wordsUppercase(text) {
    var arr = text.replace(/[^a-zA-Z ]/g, ' ')
    .toUpperCase()
    .split(' ')
    .filter(function(n){ return n.length > 0});

    return arr.join(', ');
}

console.log(wordsUppercase('Hi, how are you?'));
console.log(wordsUppercase('hello'));
console.log(wordsUppercase('Functions in JS can be nested, i.e. hold other functions'));