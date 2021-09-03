function dayOfWeek(input) {
    let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];

    if (!days.includes(input)) {
        console.log('error');
    } else {
        console.log(days.indexOf(input) + 1);
    }
}

dayOfWeek('Monday');

dayOfWeek('Friday');

dayOfWeek('Invalid');