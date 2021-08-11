﻿let intervalId;

poll = (orderId) => {
    fetch(`/Coffee/${orderId}`)
        .then(response => {
                if (response.status === 200) {
                    response.json().then(j => {
                        document.getElementById("status").innerHTML = j.update;
                        if (j.finished) {
                            clearInterval(intervalId);
                        }
                    });
                }
            }
        );
};

document.getElementById("submit").addEventListener("click", e => {
    e.preventDefault();
    const product = document.getElementById("product").value;
    const size = document.getElementById("size").value;
    fetch("/Coffee",
        {
            method: "POST",
            body: { product, size }
        })
        .then(response => response.text())
        .then(id => {
            document.getElementById("status").innerHTML = `Starting coffee #${id}`;
            intervalId = setInterval(poll, 1500, id);
        });
});
