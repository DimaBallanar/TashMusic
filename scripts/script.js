const spotifyButton = document.querySelector(".spotify");
let checkColor = true;
spotifyButton.addEventListener("click", function () {
    const backgroundColor = document.querySelector("body");
    if (checkColor) {
        backgroundColor.style.background = "#E5E5E5";
        checkColor = false;
    }
    else {
        backgroundColor.style.background = "#454545";
        checkColor = true;
    }
});

const likeUnlikeButton = document.querySelector(".like");
let checkLike = true;
likeUnlikeButton.addEventListener("click", function () {
    if (checkLike) {
        const like = "./buttons/like.svg";
        likeUnlikeButton.style.backgroundImage = `url(${like})`;
        likeUnlikeButton.css
        checkLike = false;
    }
    else {
        const unlike = "./buttons/unlike.svg";
        likeUnlikeButton.style.backgroundImage = `url(${unlike})`;
        checkLike = true;
    }
});

const playButton = document.querySelector(".stop");
let checkPlay = true;
const playButImage = "./buttons/play.svg";
const pauseButImage = "./buttons/pause.svg";
playButton.addEventListener("click", function () {
    if (checkPlay) {
        playButton.style.backgroundImage = `url(${pauseButImage})`;
        audio.play();
        changeNameSinger(playlist);
        checkPlay = false;
    }
    else {
        playButton.style.backgroundImage = `url(${playButImage})`;
        audio.pause();
        checkPlay = true;
    }
})
const songName = document.querySelector(".track-name");
const singerName = document.querySelector(".singer");
const envelope=document.querySelector(".envelope");
function changeNameSinger(song) {
    songName.textContent = song[i].name;
    singerName.textContent = song[i].singer;
    envelope.style.backgroundImage=`url(${song[i].path})`;
}

const nextSong=document.querySelector(".forward");
const backSong=document.querySelector(".back");

nextSong.addEventListener("click", function(){
    i++;
    if(i==playlist.length){
        i=0;
        audio.src=playlist[i].path;
        audio.play();
        changeNameSinger(playlist);
    }
    else{
        audio.src=playlist[i].path;
        audio.play();
        changeNameSinger(playlist);
    }
});

backSong.addEventListener("click", function(){
    i--;
    if(i<0){
        i=playlist.length-1;
        audio.src=playlist[i].path;
        audio.play();
        changeNameSinger(playlist);
    }
    else{
        audio.src=playlist[i].path;
        audio.play();
        changeNameSinger(playlist);
    }
});

