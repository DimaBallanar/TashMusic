let playlist=[
    {
        name: 'DaDaDa',
        singer: 'INSTASAMKA',
        path: './music/INSTASAMKA - DADADA.mp3',
        envelope:'./images/1010328.jpg'
    },
    {
        name: 'За Деньги Да',
        singer: 'INSTASAMKA',
        path: './music/INSTASAMKA - ЗА ДЕНЬГИ ДА.mp3',
        envelope:'./images/3053642.jpg'
    },
    {
        name: 'Раз-Два-Три',
        singer: 'Гербер',
        path: './music/Гербер - Раз, Два, Три.mp3',
        envelope:'./images/4366601.jpg'
    },
    {
        name: 'Бархатные Тяги',
        singer: 'Кефтэме',
        path: './music/Кефтэме - Бархатные тяги.mp3',
        envelope:'./images/7869681.jpg'
    },
    {
        name: 'Биба и Боба',
        singer: 'ДимаСнэп',
        path: './music/СахарСоСтеклом, Дима Снэп - Биба и Боба.mp3',
        envelope:'./images/9661273.jpg'
    }
];

const audio=document.createElement('audio');
let i=0;
audio.src=playlist[i].path;