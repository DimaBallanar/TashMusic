let login = new Object();
// document.getElementById('logining').onclick = function () {
//     login.NickName = document.getElementById('emailForLogin').value;
//     login.Password = document.getElementById('passForLogin').value;

//     let hxr = new XMLHttpRequest();
//     hxr.open('POST', 'https://localhost:7172/api/Account/Login');
//     hxr.setRequestHeader('Content-Type', 'application/json');
//     hxr.send(JSON.stringify(login));
//     // hxr.onload=()=>console.log(hxr.response);
//     hxr.onload = () => {
//         const user = JSON.parse(hxr.response);       
//         if (user.accessToken != null) {
//             window.location.href = 'D:/TestJS/TashMusic/Client/index.html';

//         }
//         else{
//             window.location.href='D:/TestJS/TashMusic/Client/login.html'
//         }
//     };   
// }

document.getElementById('logining').addEventListener('click', async () => {
    login.NickName = document.getElementById('emailForLogin').value;
    login.Password = document.getElementById('passForLogin').value;

const response=await fetch(`https://localhost:7172/api/Account/Login`, {
    method: 'POST',
    headers:{
        "Content-Type": "application/json"
    },
    body: JSON.stringify(login)
})
const json=await response.json();
console.log(json.accessToken) ;  
if (json.accessToken != null) {
                window.location.href = 'D:/TestJS/TashMusic/Client/index.html';
    
            }
            else{
                window.location.href='D:/TestJS/TashMusic/Client/login.html'
            }      
});   
    

