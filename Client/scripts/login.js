let login=new Object();
document.getElementById('logining').onclick=function(){
 login.NickName=document.getElementById('emailForLogin').value;
 login.Password=document.getElementById('passForLogin').value;

 let hxr=new XMLHttpRequest();
 hxr.open('POST','https://localhost:7172/api/Account/Login');
 hxr.setRequestHeader('Content-Type', 'application/json');
    hxr.send(JSON.stringify(login));
    hxr.onload=()=>console.log(hxr.response);
}