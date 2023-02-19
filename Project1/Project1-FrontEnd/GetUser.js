
    const signinform = document.getElementById("showUserDetail");


    var email = localStorage.getItem("email");
    email = email.replace(/['‘’"“”]/g, '')
    console.log(email);


    fetch(`https://localhost:7026/api/User/FetchUserDetail?email=${email}`,
    {
        method: "GET",
        headers: {
            "Context-type": "application.json; charset=UTF-8",
        },
    })
    .then((response) =>response.json())
    .then(element => {
        const parentDiv = document.createElement('div')
                parentDiv.className = "container"

                const div = document.createElement('div')
                div.className = "card"

                div.appendChild(document.createElement('hr'))



                const user_id = document.createElement('p')
                user_id.textContent = "User-Id :- " + element.id
                user_id.className = "card_user_user_id"

                const first_name = document.createElement('p')
                first_name.textContent = "First-Name :- "+ element.firstname
                first_name.className = "card_user_first_name"

                const last_name = document.createElement('p')
                last_name.textContent = "Last-Name :- "+ element.lastname
                last_name.className = "card_user_last_name"

                const gender = document.createElement('p')
                gender.textContent = "Gender :- " + element.gender
                gender.className = "card_user_gender"

                const email = document.createElement('p')
                email.textContent = "Email :- "+ element.email
                email.className = "card_user_email"

                const age = document.createElement('p')
                age.textContent = "Age :- " + element.age
                age.className = "card_user_age"



                div.appendChild(user_id)
                div.appendChild(first_name)
                div.appendChild(last_name)
                div.appendChild(gender)
                div.appendChild(email)
                div.appendChild(age)

        


                signinform.appendChild(div)
    })
