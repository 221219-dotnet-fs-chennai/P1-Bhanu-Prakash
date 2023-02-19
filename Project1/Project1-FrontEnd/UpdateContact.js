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
        
        let phone1 = document.getElementById("phone").value;
        let city1 = document.getElementById("city").value;
        let state1 = document.getElementById("state").value;
        let zipcode1 = document.getElementById("zipcode").value;

        fetch("https://localhost:7026/api/Contact/Update?" + new URLSearchParams({
            email : email
        }),{
            method : "PUT",
            body : JSON.stringify(
                {
                    "phone": phone1,
                    "city": city1,
                    "state": state1,
                    "zipcode": zipcode1
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