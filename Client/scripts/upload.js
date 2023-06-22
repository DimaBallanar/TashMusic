// document.querySelector('button').addEventListener('click', () => {
//     let xhr = new XMLHttpRequest();
//     xhr.open('GET', 'https://localhost:7196/WeatherForecast');
//     xhr.send();
//     xhr.onload = () => {
//         const array=JSON.parse(xhr.response);
//         const weatherClass=document.querySelector('.weather');
// for(let i=0;i<array.length;i++){
//     let obj=document.createElement('span');
//     obj.textContent=JSON.stringify(array[i]);
//     weatherClass.appendChild(obj);
// }
//     };
// });


document.querySelector('button').addEventListener('click', async() => {
    const response=await fetch('https://localhost:7196/WeatherForecast', {
        method: 'GET'
    })
    const json=await response.json();
    // console.log(json);
    const weatherClass=document.querySelector('.weather');
    for(let i=0;i<json.length;i++){
        let obj=document.createElement('span');
        obj.textContent=JSON.stringify(json[i]);
        weatherClass.appendChild(obj);
    }
        
});