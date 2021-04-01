function validate() {
    document.getElementById('email').addEventListener('change', change);
}

function change(ev) {
    const email = ev.target.value;
    const isValid = validateEmail(email);

    if (isValid) {
        ev.target.className = '';
    } else {
        ev.target.className = 'error';
    }
}

function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}