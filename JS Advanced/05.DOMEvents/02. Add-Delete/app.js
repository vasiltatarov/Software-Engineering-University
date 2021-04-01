function addItem() {
    //create li
    const inputText = document.getElementById('newItemText');
    if (inputText.value.trim() == '') {
        return;
    }
    const liElement = createElement('li', inputText.value);

    //add delete button and event handler on it
    const deleteBtn = createElement('a', '[Delete]');
    deleteBtn.href = '#';
    deleteBtn.addEventListener('click', (ev) => {
        ev.target.parentNode.remove();
    })
    liElement.appendChild(deleteBtn);

    //add new li to document
    const items = document.getElementById('items');
    items.appendChild(liElement);

    //clear input
    inputText.value = '';

    function createElement(type, content) {
        const element = document.createElement(type);
        element.textContent = content;
        return element;
    }
}