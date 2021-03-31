function extractText() {
    let liElements = [...document.getElementsByTagName('li')];
    let elementsText = liElements.map(x => x.textContent);
    console.log(elementsText)

    document.getElementById('result').value = elementsText.join('\n');
}