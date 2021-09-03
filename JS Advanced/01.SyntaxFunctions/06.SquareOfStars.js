function rectangle(n = 5) {
    for (let i = 1; i <= n; i++) {
        let line = '* ';
        console.log(line.repeat(n));
    }
}

rectangle(1);

rectangle(2);

rectangle();