function solve(tickets, criterion) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    
    function splitLine(line) { return line.split('|') };

    function convertToTicket([destination, price, status]) {
        return new Ticket(destination, Number(price), status);
    }

    const sortByCriterion = {
        'destination': (a, b) => a.destination.localeCompare(b.destination),
        'price': (a, b) => a.price - b.price,
        'status': (a, b) => a.status.localeCompare(b.status),
    };

    return tickets
        .map(splitLine)
        .map(convertToTicket)
        .sort(sortByCriterion[criterion]);
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'));

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));