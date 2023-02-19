function modifyUser(){
    let email = localStorage.getItem('email')
    email = email.replace(/['‘’"“”]/g, '')

    let flag = false;
    if(email != null){
        flag= true
    }
    if(flag == true){
        handleUpdate();
    }
    }
    function handleUpdate(){
        let email = localStorage.getItem('email')
        email = email.replace(/['‘’"“”]/g, '')
        
        let fname1 = document.getElementById("FName").value;
        let lname1 = document.getElementById("LName").value;
        let pswd1 = document.getElementById("Pswd").value;
        let gender1 = document.getElementById("gender").value;
        let age1 = document.getElementById("age").value;

        fetch("https://localhost:7026/api/User/Update?" + new URLSearchParams({
            email : email
        }),{
            method : "PUT",
            body : JSON.stringify(
                {
                    "id": 0,
                    "firstname": fname1,
                    "lastname": lname1,
                    "email": email,
                    "password":pswd1,
                    "gender": gender1,
                    "age": age1
                  }),
        headers:{
            "Content-type": "application/json; charset=UTF-8",
        },
        })
        alert("Updated Successfully!")
        // .then((response) => console.log(response))
        // if(response.status === 200){
        //     alert("updated!")
        //     window.location.href = "view.html"
        // }else{
        //     alert("something went wrong")
        // }
}