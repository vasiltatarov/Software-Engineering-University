function names(arr) {
    return arr.sort((a, b) => a.localeCompare(b))
        .map((el, i) => {
            return `${i + 1}.${el}`;
        })
        .join('\n');
}

console.log(names(["John", "Bob", "Christina", "Ema"]));