async function modifyEducation(){
    const handleUpdate = document.getElementById("modifyEducation");

    handleUpdate.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

      let skill1 = document.getElementById("oldskill").value;
      let skill2 = document.getElementById("newskill").value;  
        let prof1 = document.getElementById("prof").value;


    await fetch("https://localhost:7026/api/Skill/Update?" + new URLSearchParams({
        email : email,
        oldskill : skill1,
    }),{
        method : "PUT",
        body : JSON.stringify({
            "skill": skill2,
            "proficiency": prof1
        }),
        headers:{
            "Content-type" : "application/json; charset=UTF-8",
        },
    })
    alert("Updated Successfully!")

}