class Person {
    constructor(firstName, lastName, age, email) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Email = email;
    }

    toString() {
        return `${this.FirstName} ${this.LastName} (age: ${this.Age}, email: ${this.Email})`;
    }
}

function objArray() {
    let arr = [];

    arr.push(new Person('Anna', 'Simpson', 22, 'anna@yahoo.com'));
    arr.push(new Person('SoftUni'));
    arr.push(new Person('Stephan', 'Johnson', 25));
    arr.push(new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com'));

    return arr;
}

let persons = objArray();

console.log(persons);
persons.forEach(person => console.log(person));