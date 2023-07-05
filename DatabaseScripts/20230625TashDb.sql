create database if not exists TashMusic;
use TashMusic;

create table if not exists Users (
 Id int primary key auto_increment,
    Name varchar(30) not null,
    Email varchar(50) unique,
    Number varchar(15) unique,
    pwd varchar(255)      
    );    
 
    
create table if not exists Songs(
 Id int  primary key auto_increment,
    Name varchar(100) not null,
    Name varchar(100) not null,
    File_Path varchar(250) unique, 
    Liked boolean default '0',
    Genre_Id int,
    foreign key(Genre_Id) references Genre_of_Music(id)
    );

create table if not exists Genre_of_Music(
 Id int primary key auto_increment,
    Genre_Type varchar(50) not null   
    );

create table if not exists PlayList(
 Id int primary key auto_increment,    
 User_id int,
 foreign key(User_id) references Users(Id)
    
    );
    
    drop  database tashmusic;

