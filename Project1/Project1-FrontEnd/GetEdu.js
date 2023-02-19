
const signinform = document.getElementById("showUserDetail");


var email = localStorage.getItem("email");
email = email.replace(/['‘’"“”]/g, '')
console.log(email);


fetch(`https://localhost:7026/api/Education/FetchEducationDetails?email=${email}`,
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


            

            const degree = document.createElement('p')
            degree.textContent = "Degree :- "+ item.degree
            degree.className = "card_user_first_name"

            const grade = document.createElement('p')
            grade.textContent = "Grade :- "+ item.grade
            grade.className = "card_user_last_name"

            const startyear = document.createElement('p')
            startyear.textContent = "Start-Year :- "+ item.startyear
            startyear.className = "card_user_first_name"

            const university = document.createElement('p')
            university.textContent = "University :- "+ item.university
            university.className = "card_user_last_name"

            const endyear = document.createElement('p')
            endyear.textContent = "End-Year :- "+ item.endyear
            endyear.className = "card_user_first_name"


            div.appendChild(degree)
            div.appendChild(university)
            div.appendChild(startyear)
            div.appendChild(endyear)
            div.appendChild(grade)




            signinform.appendChild(div)
    });
    
    })
