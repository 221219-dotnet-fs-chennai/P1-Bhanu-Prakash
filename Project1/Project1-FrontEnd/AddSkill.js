async function addSkill() {
    const handleeducation = document.getElementById("addSkill");

    handleeducation.addEventListener("submit", event => {
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let skill1 = document.getElementById("skill").value;
    let prof1 = document.getElementById("prof").value;

    await fetch("https://localhost:7026/api/Skill/AddSkills?" + new URLSearchParams({
        email: email
    }),
        {
            method: "POST",
            body: JSON.stringify({

                "skill": skill1,
                "proficiency": prof1
                
              }),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })
        .then((response) => console.log(response))
        alert("Skills Added Successfull!")
    //window.location.href = "view.html"
}