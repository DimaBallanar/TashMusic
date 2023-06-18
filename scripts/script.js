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

const htmlObj = {
    spotifyBtn,
    songNameDiv,
    singerNameDiv,
    envelopeImg,
    nextSongBtn,
    backSongBtn,
    playBtn,
    likeBtn,
    songAudio
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