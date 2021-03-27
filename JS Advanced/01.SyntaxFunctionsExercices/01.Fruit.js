function needMoney(fruit, weightInGrams, pricePerKilogram) {
    let neededMoney = weightInGrams / 1000 * pricePerKilogram
    let weightInKilogram = weightInGrams / 1000;
    return `I need $${neededMoney.toFixed(2)} to buy ${weightInKilogram.toFixed(2)} kilograms ${fruit}.`;
}

console.log(needMoney('orange', 2500, 1.80));