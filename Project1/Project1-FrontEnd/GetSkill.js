
const signinform = document.getElementById("showUserDetail");


var email = localStorage.getItem("email");
email = email.replace(/['‘’"“”]/g, '')
console.log(email);


fetch(`https://localhost:7026/api/Skill/FetchSkillsDetails?email=${email}`,
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


            

            const skill = document.createElement('p')
            skill.textContent = "Skill-Name :- "+ item.skill
            skill.className = "card_user_first_name"

            const proficiency = document.createElement('p')
            proficiency.textContent = "Proficiency :- "+ item.proficiency
            proficiency.className = "card_user_last_name"



            div.appendChild(skill)
            div.appendChild(proficiency)


            signinform.appendChild(div)
    });
    
    })
