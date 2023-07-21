const inputFile = document.getElementById('custom-file');
const filesEditor = document.querySelector('.files-editors');
const send = document.getElementById('send-files');


let result = new Object();
let fileNames = [];
let genreNames = [];
inputFile.addEventListener(
    'change',
    (event) => {
        filesEditor.innerHTML = '';
        const files = event.target.files;
        for (let i = 0; i < files.length; i++) {
            const file = files[i];
            const blockSongName = document.createElement('div');
            const labelSongName = document.createElement('label');
            labelSongName.textContent = 'Name';
            const blockGenre = document.createElement('div');
            const labelGenre = document.createElement('label');
            const inputGenre = document.createElement('input', { is: "generation" });         
            labelGenre.textContent = 'Жанр';
            fileNames.push(file.name)
            const inputSongName = document.createElement('input');
            inputSongName.value = file.name;
            inputSongName.addEventListener('change', (event) => {
                fileNames[i] = event.target.value;
            });
            inputGenre.addEventListener('change', (event) => {
                genreNames[i]=event.target.value;                 
            });    
            genreNames.push(genreNames[i])     ; 
            blockSongName.appendChild(labelSongName);
            blockSongName.appendChild(inputSongName);
            filesEditor.appendChild(blockSongName);

            blockGenre.appendChild(labelGenre);
            blockGenre.appendChild(inputGenre);
            filesEditor.appendChild(blockGenre);

        }
    },
    false
);

send.addEventListener('click', () => {

    const files = inputFile.files;

    for (let i = 0; i < files.length; i++) {
        const formData = {
           id:i,
            filePath:"D:\\TestJS\\TashMusic\\Music",
            genre:genreNames[i],
            name:files[i].name,
        };
pushingMusic(formData);
    }
});

function pushingMusic(fil){
    let hxr = new XMLHttpRequest();
    hxr.open('POST', 'https://localhost:7172/api/Product/');
    hxr.setRequestHeader('Content-Type', 'application/json');
    hxr.send(JSON.stringify(fil));
    // hxr.onload = () => console.log(hxr.response);    
};





// send.addEventListener('click', () => {

//     const formData = new FormData();
//     const files = inputFile.files;
//     const genreNames=inputFile.genreNames;
//     for (let i = 0; i < files.length; i++) {
//         formData.append('file', files[i]);
//     }
//     formData.append('data', fileNames);

//     const response = fetch('https://localhost:7172/api/Product/', {
//         method: 'POST',

//         body: formData,
//     });
//     if (response.ok) {

//     }
// });