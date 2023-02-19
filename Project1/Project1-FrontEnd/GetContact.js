
const signinform = document.getElementById("showUserDetail");


var email = localStorage.getItem("email");
email = email.replace(/['‘’"“”]/g, '')
console.log(email);


fetch(`https://localhost:7026/api/Contact/FetchContactDetails?email=${email}`,
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

            

            const phone = document.createElement('p')
            phone.textContent = "Phone :- "+ item.phone
            phone.className = "card_user_first_name"

            const city = document.createElement('p')
            city.textContent = "City :- "+ item.city
            city.className = "card_user_last_name"

            const state = document.createElement('p')
            state.textContent = "State :- "+ item.state
            state.className = "card_user_first_name"

            const zipcode = document.createElement('p')
            zipcode.textContent = "zipcode :- "+ item.zipcode
            zipcode.className = "card_user_last_name"

            
            div.appendChild(phone)
            div.appendChild(city)
            div.appendChild(state)
            div.appendChild(zipcode)


            signinform.appendChild(div)
    });
    
    })
