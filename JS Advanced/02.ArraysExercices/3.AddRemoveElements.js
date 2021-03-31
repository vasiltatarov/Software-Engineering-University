function solve(commands) {
    let result = [];
    let i = 1;

    commands.forEach((command) => {
        if (command == 'add') {
            result.push(i);
        } else if (command == 'remove') {
            result.pop();
        }
        i++;
    });

    return result.length == 0 ? 'Empty' : result.join('\n');
}

console.log(solve(['add', 
'add', 
'add', 
'add']
));

console.log(solve(['add', 
'add', 
'remove', 
'add', 
'add']
));

console.log(solve(['remove', 
'remove', 
'remove']
));