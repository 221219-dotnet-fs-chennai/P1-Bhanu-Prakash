async function deleteEducation(){
    const handledelete = document.getElementById("deleteEducation");

    handledelete.addEventListener("submit" , event =>{
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')


    await fetch ("https://localhost:7026/api/Contact/Delete?" + new URLSearchParams({
        email : email,
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
            alert("Contact Details is not present");
            window.location.href = "DeleteContact.html";
        }
    })
    .then((response)=> console.log(response))
}