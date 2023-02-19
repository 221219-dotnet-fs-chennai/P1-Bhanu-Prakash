async function addUser() {
    const handleeducation = document.getElementById("addUser");

    handleeducation.addEventListener("submit", event => {
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let fname1 = document.getElementById("FName").value;
    let lname1 = document.getElementById("LName").value;
    let email1 = document.getElementById("Email").value;
    let pswd1 = document.getElementById("Pswd").value;
    let gender1 = document.getElementById("gender").value;
    let age1 = document.getElementById("age").value;


    await fetch("https://localhost:7026/api/User/AddTrainer?" + new URLSearchParams({
        email: email
    }),
        {
            method: "POST",
            body: JSON.stringify({

                "id": 0,
                "firstname": fname1,
                "lastname": lname1,
                "email": email1,
                "password":pswd1,
                "gender": gender1,
                "age": age1

            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })
        .then((response) => console.log(response))
        alert("added User Details!")
    //window.location.href = "view.html"
}