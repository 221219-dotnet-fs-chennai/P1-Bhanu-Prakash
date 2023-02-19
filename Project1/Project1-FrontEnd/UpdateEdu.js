async function modifyEducation(){
    const handleUpdate = document.getElementById("modifyEducation");

    handleUpdate.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

      let degree1 = document.getElementById("degreeold").value;
      let degree2 = document.getElementById("degreenew").value;

    let university1 = document.getElementById("university").value;
    let start1 = document.getElementById("start").value;
    let end1 = document.getElementById("end").value;
    let grade1 = document.getElementById("grade").value;

    await fetch("https://localhost:7026/api/Education/Update?" + new URLSearchParams({
        email : email,
        degree : degree1,
    }),{
        method : "PUT",
        body : JSON.stringify({
            "degree": degree2,
            "university": university1,
            "startyear": start1,
            "endyear": end1,
            "grade": grade1
        }),
        headers:{
            "Content-type" : "application/json; charset=UTF-8",
        },
    })
    alert("Updated Successfully!")

}