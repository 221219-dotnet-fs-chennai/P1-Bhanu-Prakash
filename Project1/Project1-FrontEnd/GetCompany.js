
const signinform = document.getElementById("showUserDetail");


var email = localStorage.getItem("email");
email = email.replace(/['‘’"“”]/g, '')
console.log(email);


fetch(`https://localhost:7026/api/Company/FetchCompanyDetails?email=${email}`,
{
    method: "GET",
    headers: {
        "Context-type": "application.json; charset=UTF-8",
    },
})
.then((response) =>response.json())
.then(element => {

    element.forEach(item => {
        const parentDiv = document.createElement('div')
            parentDiv.className = "container"

            const div = document.createElement('div')
            div.className = "card"

            div.appendChild(document.createElement('hr'))


            

            const prev = document.createElement('p')
            prev.textContent = "Previous Company :- "+ item.previousCompany
            prev.className = "card_user_first_name"

            const tech = document.createElement('p')
            tech.textContent = "Technology :- "+ item.technology
            tech.className = "card_user_last_name"

            const expyr = document.createElement('p')
            expyr.textContent = "Experience in years :- "+ item.experienceyear
            expyr.className = "card_user_first_name"

            
            div.appendChild(prev)
            div.appendChild(tech)
            div.appendChild(expyr)


            signinform.appendChild(div)
    });
    
    })
