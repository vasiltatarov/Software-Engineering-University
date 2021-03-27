function numberOperations(numberStr, ...params) {
    let number = Number(numberStr);

    for (let i = 0; i < params.length; i++) {
        switch (params[i]) {
            case 'chop':
                number /= 2;
                console.log(number);
                break;
            case 'dice':
                number = Math.sqrt(number);
                console.log(number);
            break;
            case 'spice':
                number += 1;
                console.log(number);
            break;
            case 'bake':
                number *= 3;
                console.log(number);
            break;
            case 'fillet':
                number *= 0.80;
                console.log(number.toFixed(1));
            break;
        }
    }
}

console.log(numberOperations('32', 'chop', 'chop', 'chop', 'chop', 'chop'));
console.log(numberOperations('9', 'dice', 'spice', 'chop', 'bake', 'fillet'));