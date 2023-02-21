async function addSignUp()
{
    addUser();
    // addSkill();
    // addExperience();
    // addEducation();
    // addContact();
}

//-------------------------User Details----------------
async function addUser() {
    const handleeducation = document.getElementById("add_btn");

    handleeducation.addEventListener("submit", event => {
        event.preventDefault();
    });

    let email = localStorage.getItem('email')
    let password = localStorage.getItem('password')
    email = email.replace(/['‘’"“”]/g, '')
    console.log(email);

    let fname1 = document.getElementById("FName").value;
    let lname1 = document.getElementById("LName").value;
    let email1 = email;
    let pswd1 = password;
    let gender1 = document.getElementById("gender").value;
    let age1 = document.getElementById("age").value;


    await fetch("https://localhost:7026/api/User/AddTrainer?",
        {
            method: "POST",
            body: JSON.stringify({

                "id": 0,
                "firstname": fname1,
                "lastname": lname1,
                "email": email1,
                "password":pswd1,
                "gender": gender1,
                "age": age1

            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        })
        .then((response) => response.json())
        //.then((data)=>console.log(data))
        // .then((data)=>{
        //     localStorage.setItem("email", data.email)
        //     localStorage.setItem("password", data.password)
        // })
        alert("added User Details!")
        window.location.href = "view.html"
}

// //------------------------Skills----------------------

// async function addSkill() {
//     const handleeducation = document.getElementById("add_btn");

//     handleeducation.addEventListener("submit", event => {
//         event.preventDefault();
//     });

//     let email = localStorage.getItem('email')
//     email = email.replace(/['‘’"“”]/g, '')

//     let skill1 = document.getElementById("skill").value;
//     let prof1 = document.getElementById("prof").value;

//     await fetch("https://localhost:7026/api/Skill/AddSkills?" + new URLSearchParams({
//         email: email
//     }),
//         {
//             method: "POST",
//             body: JSON.stringify({

//                 "skill": skill1,
//                 "proficiency": prof1
                
//               }),
//             headers: {
//                 "Content-type": "application/json; charset=UTF-8",
//             },
//         })
//         .then((response) => console.log(response))
//         alert("Skills Added Successfully!")
//     //window.location.href = "view.html"
// }

// //------------------------------Education--------------------

// async function addEducation() {
//     const handleeducation = document.getElementById("add_btn");

//     handleeducation.addEventListener("submit", event => {
//         event.preventDefault();
//     });

//     let email = localStorage.getItem('email')
//     email = email.replace(/['‘’"“”]/g, '')

//     let degree1 = document.getElementById("degree").value;
//     let university1 = document.getElementById("university").value;
//     let start1 = document.getElementById("start").value;
//     let end1 = document.getElementById("end").value;
//     let grade1 = document.getElementById("grade").value;


//     await fetch("https://localhost:7026/api/Education/AddEducation?" + new URLSearchParams({
//         email: email
//     }),
//         {
//             method: "POST",
//             body: JSON.stringify({

//                 "userId": 0,
//                 "degree": degree1,
//                 "university": university1,
//                 "startyear": start1,
//                 "endyear": end1,
//                 "grade": grade1,
//                 "edId": 0

//             }),
//             headers: {
//                 "Content-type": "application/json; charset=UTF-8",
//             },
//         })
//         .then((response) => console.log(response))
//         alert("Added Education Details")
//     //window.location.href = "view.html"
// }

// //-------------------------------------Experience-----------------

// async function addExperience() {
//     const handleeducation = document.getElementById("add_btn");

//     handleeducation.addEventListener("submit", event => {
//         event.preventDefault();
//     });

//     let email = localStorage.getItem('email')
//     email = email.replace(/['‘’"“”]/g, '')

//     let prev1 = document.getElementById("prev").value;
//     let tech1 = document.getElementById("tech").value;
//     let years1 = document.getElementById("years").value;


//     await fetch("https://localhost:7026/api/Company/AddCompany?" + new URLSearchParams({
//         email: email
//     }),
//         {
//             method: "POST",
//             body: JSON.stringify({

//                 "previousCompany": prev1,
//                 "technology": tech1,
//                 "experienceyear": years1

//             }),
//             headers: {
//                 "Content-type": "application/json; charset=UTF-8",
//             },
//         })
//         .then((response) => console.log(response))
//         alert("Added Experience Details");
//     //window.location.href = "view.html"
// }

// //-------------------------------contact------------------------

// async function addContact() {
//     const handleeducation = document.getElementById("add_btn");

//     handleeducation.addEventListener("submit", event => {
//         event.preventDefault();
//     });

//     let email = localStorage.getItem('email')
//     email = email.replace(/['‘’"“”]/g, '')

//     let phone1 = document.getElementById("phone").value;
//     let city1 = document.getElementById("city").value;
//     let state1 = document.getElementById("state").value;
//     let zipcode1 = document.getElementById("zipcode").value;


//     await fetch("https://localhost:7026/api/Contact/AddContact?" + new URLSearchParams({
//         email: email
//     }),
//         {
//             method: "POST",
//             body: JSON.stringify({

//                 "phone": phone1,
//                 "city": city1,
//                 "state": state1,
//                 "zipcode": zipcode1

//             }),
//             headers: {
//                 "Content-type": "application/json; charset=UTF-8",
//             },
//         })
//         .then((response) => console.log(response))
//         alert("Added Contact Details");
//     window.location.href = "view.html"
// }