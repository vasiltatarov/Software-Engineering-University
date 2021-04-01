function attachGradientEvents() {
    document.getElementById('gradient').addEventListener('mousemove', onMove);
    const output = document.getElementById('result');

    function onMove(ev) {
        const percent = Math.floor(ev.offsetX / ev.target.clientWidth * 100);
        output.textContent = `${percent}%`;
    }
}