async function searchSkill() {
    const signinform = document.getElementById("searchSk");

    let skill1 = document.getElementById("skill").value;


    fetch(`https://localhost:7026/api/User/Filter-Skill?skill=${skill1}`,
        {
            method: "GET",
            headers: {
                "Context-type": "application.json; charset=UTF-8",
            },
        })
        .then((response) => response.json())
        .then(element => {

            element.forEach(item => {
                const parentDiv = document.createElement('div')
                parentDiv.className = "container"

                const div = document.createElement('div')
                div.className = "card"

                div.appendChild(document.createElement('hr'))




                const first_name = document.createElement('p')
                first_name.textContent = "First-Name :- " + item.firstname
                first_name.className = "card_user_first_name"

                const last_name = document.createElement('p')
                last_name.textContent = "Last-Name :- " + item.lastname
                last_name.className = "card_user_last_name"


                const skill = document.createElement('p')
                skill.textContent = "Skill-Name :- " + item.skill
                skill.className = "card_user_first_name"

                const proficiency = document.createElement('p')
                proficiency.textContent = "Proficiency :- " + item.proficiency
                proficiency.className = "card_user_last_name"

                const prev = document.createElement('p')
                prev.textContent = "Company :- " + item.previousCompany
                prev.className = "card_user_first_name"

                const tech = document.createElement('p')
                tech.textContent = "Technology :- " + item.technology
                tech.className = "card_user_last_name"

                const degree = document.createElement('p')
                degree.textContent = "Degree :- " + item.higherEducation
                degree.className = "card_user_first_name"


                const phone = document.createElement('p')
                phone.textContent = "Phone :- " + item.phone
                phone.className = "card_user_first_name"

                const city = document.createElement('p')
                city.textContent = "City :- " + item.city
                city.className = "card_user_last_name"

                div.appendChild(first_name)
                div.appendChild(last_name)
                div.appendChild(skill)
                div.appendChild(proficiency)
                div.appendChild(prev)
                div.appendChild(tech)
                div.appendChild(degree)
                div.appendChild(phone)
                div.appendChild(city)


                signinform.appendChild(div)
            });

        })

}

async function searchAge() {
    const signinform = document.getElementById("searchAge1");

    let age1 = document.getElementById("age").value;


    fetch(`https://localhost:7026/api/User/Filter-Age?age=${age1}`,
        {
            method: "GET",
            headers: {
                "Context-type": "application.json; charset=UTF-8",
            },
        })
        .then((response) => response.json())
        .then(element => {

            element.forEach(item => {
                const parentDiv = document.createElement('div')
                parentDiv.className = "container"

                const div = document.createElement('div')
                div.className = "card"

                div.appendChild(document.createElement('hr'))

                const first_name = document.createElement('p')
                first_name.textContent = "First-Name :- " + item.firstname
                first_name.className = "card_user_first_name"

                const last_name = document.createElement('p')
                last_name.textContent = "Last-Name :- " + item.lastname
                last_name.className = "card_user_last_name"

                const gender = document.createElement('p')
                gender.textContent = "Gender :- " + item.gender
                gender.className = "card_user_gender"

                const email = document.createElement('p')
                email.textContent = "Email :- " + item.email
                email.className = "card_user_email"

                const age = document.createElement('p')
                age.textContent = "Age :- " + item.age
                age.className = "card_user_age"


                const skill = document.createElement('p')
                skill.textContent = "Skill-Name :- " + item.skill
                skill.className = "card_user_first_name"

                const prev = document.createElement('p')
                prev.textContent = "Company :- " + item.previousCompany
                prev.className = "card_user_first_name"

                const degree = document.createElement('p')
                degree.textContent = "Degree :- " + item.higherEducation
                degree.className = "card_user_first_name"


                const phone = document.createElement('p')
                phone.textContent = "Phone :- " + item.phone
                phone.className = "card_user_first_name"

                const city = document.createElement('p')
                city.textContent = "City :- " + item.city
                city.className = "card_user_last_name"

                const state = document.createElement('p')
                state.textContent = "State :- " + item.state
                state.className = "card_user_first_name"

                const zipcode = document.createElement('p')
                zipcode.textContent = "zipcode :- " + item.zipcode
                zipcode.className = "card_user_last_name"


                div.appendChild(first_name)
                div.appendChild(last_name)
                div.appendChild(email)
                div.appendChild(gender)
                div.appendChild(age)

                div.appendChild(skill)
                div.appendChild(prev)
                div.appendChild(degree)
                div.appendChild(phone)
                div.appendChild(city)
                div.appendChild(state)
                div.appendChild(zipcode)



                signinform.appendChild(div)
            });

        })

}