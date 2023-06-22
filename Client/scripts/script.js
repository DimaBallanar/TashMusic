// import * as myModule from './playlist.service.js';

const spotifyBtn = document.querySelector('.spotify');
const songNameDiv = document.querySelector('.track-name');
const singerNameDiv = document.querySelector('.singer');
const envelopeImg = document.querySelector('.envelope');
const nextSongBtn = document.querySelector('.forward');
const backSongBtn = document.querySelector('.back');
const playBtn = document.querySelector('.stop');
const likeBtn = document.querySelector('.like');
const songAudio = document.createElement('audio');
const time = document.querySelector(`.time`);
const line = document.querySelector(`.line`);

const htmlObj = {
    spotifyBtn,
    songNameDiv,
    singerNameDiv,
    envelopeImg,
    nextSongBtn,
    backSongBtn,
    playBtn,
    likeBtn,
    songAudio,
    line
};
const player = new Player(getAllMusic(), htmlObj);

player.applySong(player.playListSongs[player.songIndex]);

likeBtn.addEventListener('click', function () {
    const song = player.playListSongs[player.songIndex];
    song.like = !song.like;
    player.applyLikeSong(song);
});

playBtn.addEventListener('click', function () {
    player.checkPlay = !player.checkPlay;
    const buttonType = player.checkPlay ? './buttons/pause.svg' : './buttons/play.svg';
    playBtn.style.backgroundImage = `url(${buttonType})`;  
    if (player.checkPlay) {
        songAudio.play();

    }
    else {
        songAudio.pause();
    }
});

nextSongBtn.addEventListener('click', function () {
    player.changeSong(player.nextSong());
});

backSongBtn.addEventListener('click', function () {
    player.changeSong(player.backSong());
});

let checkColor = true;
spotifyBtn.addEventListener('click', function () {
    const backgroundColor = document.querySelector('body');
    const playerGround = document.querySelector('.player');
    if (checkColor) {
        backgroundColor.style.background = '#E5E5E5';
        playerGround.style.background = '#454545';
        checkColor = false;
    }
    else {
        backgroundColor.style.background = '#454545';
        playerGround.style.background = '#FFFEF8';
        checkColor = true;
    }
});

// function WatchTime() {   
//     // const selectInterval=songAudio;
//     const minutes = (songAudio.currentTime < 10) ? '0' + songAudio.currentTime : songAudio.currentTime;
//     const seconds = (songAudio.currentTime < 10) ? '0' + songAudio.currentTime : songAudio.currentTime;
//     time.innerHTML = minutes + ':' + seconds;
// };
let updateProgress = (e) => {
    const {
        duration,
        currentTime
    } = e.target
    const progressParcent = (currentTime / duration) * 100
    line.style.width = `${progressParcent}%`;
}
songAudio.addEventListener(`timeupdate`, updateProgress);
songAudio.addEventListener("timeupdate", function () {
    let track_time = songAudio.currentTime;
    let start = "0";
    let minuts = Math.floor(track_time / 60);
    let seconds = Math.floor(track_time - minuts * 60);
    seconds < 10 ? seconds = "0" + seconds : null;
    minuts > 10 ? start = "" : null;
    time.innerHTML = start + minuts + ":" + seconds;
});
    