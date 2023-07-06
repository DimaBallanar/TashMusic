let user = new Object();

document.getElementById('registration').onclick = function () {
    user.name = document.getElementById('username').value;
    user.email = document.getElementById('email').value;
    user.phonenumber = document.getElementById('phone').value;
    user.password = document.getElementById('password').value;

    let hxr = new XMLHttpRequest();
    hxr.open('POST', 'https://localhost:7172/api/user/');
    hxr.setRequestHeader('Content-Type', 'application/json');
    hxr.send(JSON.stringify(user));
    hxr.onload=()=>console.log(hxr.response);
};



