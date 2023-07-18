const inputFile = document.getElementById('custom-file');
const filesEditor = document.querySelector('.files-editors');
const send = document.getElementById('send-files');

let fileNames = [];
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
            fileNames.push(file.name)
            const inputSongName = document.createElement('input');
            inputSongName.value = file.name;
            inputSongName.addEventListener('change', (event) => {
                fileNames[i] = event.target.value;
            });
            blockSongName.appendChild(labelSongName);
            blockSongName.appendChild(inputSongName);
            filesEditor.appendChild(blockSongName);
        }
    },
    false
);

send.addEventListener('click', () => {

    const formData = new FormData();
    const files = inputFile.files;
    for (let i = 0; i < files.length; i++) {
        formData.append('file', files[i]);
    }
    formData.append('data', fileNames);

    const response = fetch('https://localhost:7172/api/Product/', {
        method: 'POST',

        body: formData,
    });
    if (response.ok) {

    }
});