async function modifyEducation(){
    const handleUpdate = document.getElementById("modifyEducation");

    handleUpdate.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

      let prev1 = document.getElementById("prev").value;
      let newprev1 = document.getElementById("newprev").value;
      let tech1 = document.getElementById("tech").value;
      let years1 = document.getElementById("years").value;

    await fetch("https://localhost:7026/api/Company/Update?" + new URLSearchParams({
        email : email,
        prev : prev1,
    }),{
        method : "PUT",
        body : JSON.stringify({
            "previousCompany": newprev1,
            "technology": tech1,
            "experienceyear": years1
        }),
        headers:{
            "Content-type" : "application/json; charset=UTF-8",
        },
    })
    alert("Updated Successfully!")

}