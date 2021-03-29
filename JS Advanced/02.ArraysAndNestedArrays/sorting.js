let arr = [5, 2, 4, 324, 34, 1, 12, 123, 8];
console.log(arr);

//slice
console.log(arr.slice(1, 5));
console.log(arr.slice(1, -3));

arr.sort((a, b) => a - b);

console.log(arr);

//---------------

let names = ['vasko', 'nasko', 'sali', 'donika'];
// a-z
names.sort((a, b) => a.localeCompare(b));
//z-a
names.sort((a, b) => !a.localeCompare(b));

console.log(names);