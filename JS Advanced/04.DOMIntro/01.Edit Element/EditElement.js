function editElement(ref, match, replacer) {
    let content = ref.textContent;
    let regex = new RegExp(match, 'g');
    let newContent = content.replace(regex, replacer);
    ref.textContent = newContent;
}