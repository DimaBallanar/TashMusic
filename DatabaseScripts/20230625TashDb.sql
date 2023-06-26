create database if not exists TashMusic;
use TashMusic;

create table if not exists Users (
 Id int primary key auto_increment,
    User_Name varchar(30) not null,
    Email varchar(50) unique,
    Phone_Number varchar(15) unique,
    User_Pwd int,
    User_PlayList int,
    foreign key(User_Pwd) references Passwords(id),
    foreign key(User_Playlist) references Playlist(id)    
    );
    
    create table if not exists Passwords(
    id int primary key auto_increment,
    pwd varchar(255)   
    );
    
create table if not exists Songs(
 Id int  primary key auto_increment,
    Song_Name varchar(100) not null,
    Singer_Name varchar(100) not null,
    File_Path varchar(250) unique,  
    Genre_Id int,
    foreign key(Genre_Id) references Genre_of_Music(id)
    );

create table if not exists Genre_of_Music(
 Id int primary key auto_increment,
    Name varchar(50) not null   
    );

create table if not exists PlayList(
 Id int primary key auto_increment,
    Name varchar(100) not null,
    User_Id int  
    );
    

