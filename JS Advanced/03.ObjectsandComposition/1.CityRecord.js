function cityObj(name, population, treasury) {
    const city = {
        name: name,
        population: population,
        treasury: treasury,
    };
    return city;
}

console.log(cityObj('Chakalo', 7000, 15000));