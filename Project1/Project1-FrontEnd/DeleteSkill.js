async function deleteEducation(){
    const handledelete = document.getElementById("deleteEducation");

    handledelete.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let skill1 = document.getElementById("skill").value;

    await fetch ("https://localhost:7026/api/Skill/Delete?" + new URLSearchParams({
        email : email,
        name : skill1
    }),{
        method : "DELETE",
        headers :{
            "Content-type": "application/json; charset=UTF-8",
        },
    })
    .then((response) =>{
        if(response.status == 200){
            alert("Deleted Successfully!");
            window.location.href = "view.html";
        }
        else{
            alert("Degree is not present");
            window.location.href = "DeleteEdu.html";
        }
    })
    .then((response)=> console.log(response))
}