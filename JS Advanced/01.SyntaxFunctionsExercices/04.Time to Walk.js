function walkTime(steps, footLength, speedKmh) {
    let speedSeconds = speedKmh * 1000 / 3600;
    let distance = steps * footLength;
    let restTimeSeconds = Math.floor(distance / 500) * 60;
    let timeSeconds = distance / speedSeconds + restTimeSeconds;

    let hours = Math.floor(timeSeconds / 3600).toFixed(0).padStart(2, '0');
    let minutes = Math.floor((timeSeconds - hours * 3600) / 60).toFixed(0).padStart(2, '0');
    let seconds = (timeSeconds - hours * 60 * 60 - minutes * 60).toFixed(0).padStart(2, '0');

    return `${hours}:${minutes}:${seconds}`;
}

console.log(walkTime(4000, 0.60, 5));
console.log(walkTime(2564, 0.70, 5.5));