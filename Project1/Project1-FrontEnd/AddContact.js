async function addContact() {
    const handleeducation = document.getElementById("addContact");

    handleeducation.addEventListener("submit", event => {
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let phone1 = document.getElementById("phone").value;
    let city1 = document.getElementById("city").value;
    let state1 = document.getElementById("state").value;
    let zipcode1 = document.getElementById("zipcode").value;


    await fetch("https://localhost:7026/api/Contact/AddContact?" + new URLSearchParams({
        email: email
    }),
        {
            method: "POST",
            body: JSON.stringify({

                "userId": 0,
                "phone": phone1,
                "city": city1,
                "state": state1,
                "zipcode": zipcode1,
                "contactId": 0

            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })
        .then((response) => console.log(response))
        alert("Added Contact Details");
        window.location.href = "view.html"
}