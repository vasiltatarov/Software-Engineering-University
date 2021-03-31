function extract(content) {
    let text = document.getElementById(content).textContent;

    let result = [];
    
    const regex = /\((.+?)\)/gm;
    let match = regex.exec(text);
    while (match != null) {
        result.push(match[1]);
        match = regex.exec(text);
    }

    document.getElementById('result').textContent = result.join('; ');
    return result.join('; ');
}