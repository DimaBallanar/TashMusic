

document.getElementById('registration').onclick = function () {
    const user = {
        name: document.getElementById('username').value,
        email: document.getElementById('email').value,
        phonenumber: document.getElementById('phone').value,
        password: document.getElementById('password').value,
    };
  registrationAPI(user);
};

function registrationAPI(user){
    let hxr = new XMLHttpRequest();
    hxr.open('POST', 'https://localhost:7172/api/user/');
    hxr.setRequestHeader('Content-Type', 'application/json');
    hxr.send(JSON.stringify(user));
    hxr.onload = () => console.log(hxr.response);
}
//переписать на fetch
// document.getElementById('registration').addEventListener('click', async () => {
//     const user = {
//         name: document.getElementById('username').value,
//         email: document.getElementById('email').value,
//         phonenumber: document.getElementById('phone').value,
//         password: document.getElementById('password').value,
//     }; 

// const response=await fetch(`https://localhost:7172/api/user`, {
//     method: 'POST',
//     headers:{
//         "Content-Type": "application/json"
//     },
//     body: JSON.stringify(user)
// })
// const json=await response.json();
// console.log(json) ;        
// });   



