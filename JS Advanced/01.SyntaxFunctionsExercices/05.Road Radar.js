function roadRadar(speedAsStr, area) {
    let speed = Number(speedAsStr);

    function findSpeed(speed, area) {
        let limit;

        function findZone(speed, limit) {
            if (speed <= limit) {
                return `Driving ${speed} km/h in a ${limit} zone`;
            } else {
                let difference = speed - limit;
                let status;
                if (difference <= 20) {
                    status = 'speeding';
                } else if (difference <= 40) {
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }

                return `The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`;
            }
        }

        if (area == 'residential') {
            limit = 20;
            return findZone(speed, limit);
        } else if (area == 'city') {
            limit = 50;
            return findZone(speed, limit);
        } else if (area == 'interstate') {
            limit = 90;
            return findZone(speed, limit);
        } else if (area == 'motorway') {
            limit = 130;
            return findZone(speed, limit);
        }
    }

    return findSpeed(speed, area);
}

console.log(roadRadar(40, 'city'));
console.log(roadRadar(21, 'residential'));
console.log(roadRadar(120, 'interstate'));
console.log(roadRadar(200, 'motorway'));