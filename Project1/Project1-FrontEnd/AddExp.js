async function addExperience() {
    const handleeducation = document.getElementById("addExperience");

    handleeducation.addEventListener("submit", event => {
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let prev1 = document.getElementById("prev").value;
    let tech1 = document.getElementById("tech").value;
    let years1 = document.getElementById("years").value;


    await fetch("https://localhost:7026/api/Company/AddCompany?" + new URLSearchParams({
        email: email
    }),
        {
            method: "POST",
            body: JSON.stringify({

                "previousCompany": prev1,
                "technology": tech1,
                "experienceyear": years1

            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })
        .then((response) => console.log(response))
        alert("Added Experience Details");
        window.location.href = "view.html"
}