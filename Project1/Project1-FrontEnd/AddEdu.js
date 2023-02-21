async function addEducation() {
    const handleeducation = document.getElementById("addEducation");

    handleeducation.addEventListener("submit", event => {
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let degree1 = document.getElementById("degree").value;
    let university1 = document.getElementById("university").value;
    let start1 = document.getElementById("start").value;
    let end1 = document.getElementById("end").value;
    let grade1 = document.getElementById("grade").value;


    await fetch("https://localhost:7026/api/Education/AddEducation?" + new URLSearchParams({
        email: email
    }),
        {
            method: "POST",
            body: JSON.stringify({

                "userId": 0,
                "degree": degree1,
                "university": university1,
                "startyear": start1,
                "endyear": end1,
                "grade": grade1,
                "edId": 0

            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })
        .then((response) => console.log(response))
        alert("Added Education Details")
        window.location.href = "view.html"
}