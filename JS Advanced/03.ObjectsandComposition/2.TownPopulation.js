function townPopulation(input) {
    let result = {};

    for (let args of input) {
        let splitedInput = args.split(' <-> ');
        let name = splitedInput[0];
        let population = Number(splitedInput[1]);

        if (result[name] == undefined) {
            result[name] = 0;
        }
        result[name] += population;
    }
    
    for (let townArg in result) {
        console.log(`${townArg} : ${result[townArg]}`);
    }
}

console.log(townPopulation(
    [
        'Sofia <-> 1200000',
        'Montana <-> 20000',
        'New York <-> 10000000',
        'Washington <-> 2345000',
        'Las Vegas <-> 1000000'
    ]));

console.log(townPopulation(
    [
        'Istanbul <-> 100000',
        'Honk Kong <-> 2100004',
        'Jerusalem <-> 2352344',
        'Mexico City <-> 23401925',
        'Istanbul <-> 1000'
    ]));