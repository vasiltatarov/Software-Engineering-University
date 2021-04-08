class List {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(value) {
        this.list.push(value);
        this.size++;
        this.sort();
    }

    get(index) {
        this.validateIndex(index);
        return this.list[index];
    }

    remove(index) {
        this.validateIndex(index);
        this.list.splice(index, 1);
        this.size--;
        this.sort();
    }

    //Helper methods
    sort() {
        this.list.sort((a, b) => a - b);
    }

    validateIndex(index) {
        if (index < 0 || index >= this.list.length) {
            throw new Error('Invalid index!');
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));

console.log(list.size);