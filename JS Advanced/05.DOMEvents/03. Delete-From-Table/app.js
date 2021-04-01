function deleteByEmail() {
    let inputEmail = document.querySelector('input[name="email"]').value;
    let rows = Array.from(document.querySelectorAll('tbody tr'));
    let result = document.getElementById('result');
    
    let matches = rows.filter(r => r.children[1].textContent == inputEmail.trim());
    if (matches.length != 0) {
        matches.forEach(r => r.remove());
        result.textContent = 'Deleted.';
    } else {
        result.textContent = 'Not found.';
    }
}