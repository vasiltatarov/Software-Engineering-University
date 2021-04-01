function addItem() {
    const inputText = document.getElementById('newItemText');

    const liElement = document.createElement('LI');
    liElement.textContent = inputText.value;

    document.getElementById('items').appendChild(liElement);
    inputText.value = '';
}