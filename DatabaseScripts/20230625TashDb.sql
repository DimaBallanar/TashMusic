create database if not exists TashMusic;
use TashMusic;

create table if not exists Users (
 Id int primary key auto_increment,
    Name varchar(30) not null,
    Email varchar(50) unique,
    Number varchar(15) unique,
    password varchar(255)      
    );    
 
    
create table if not exists Songs(
 Id int  primary key auto_increment,
    Name varchar(100) not null,
    FilePath varchar(250) unique, 
    GenreId int,
    foreign key(Genre_Id) references GenreofMusic(id)
    );

create table if not exists GenreofMusic(
 Id int primary key auto_increment,
    `Type` varchar(50) not null   
    );

create table if not exists PlayList(
 Id int primary key auto_increment,   
 name varchar(100) not null,
 Userid int,
 state int default 0, 
 foreign key(User_id) references Users(Id)    
    );
    
    create table if not exists PlayListSongs(
    id int primary key auto_increment,
    Songid int not null,
    Playlistid int not null,
    LikeS boolean default 0,
    foreign key(Songid) references Songs(Id),
    foreign key(Playlistid) references Playlist(Id)
    );
    
    
    


