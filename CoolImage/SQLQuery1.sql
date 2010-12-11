
--create database CoolImage

use CoolImage;
create table Users(
userId integer identity(1,1) not null,
userLoginName varchar(12) not null,
userPassword varchar(12) not null,
userName varchar(20) not null,
sex varchar(2),
birth varchar(17),
MSN varchar(17),
email varchar(30),
logoUrl text,
question1 text,
answer1 text,
question2 text,
answer2 text,
question3 text,
answer3 text,
descriptions text,
primary key(userId)
)

create table Albums(
albumId integer identity(1,1) not null,
albumName varchar(20) not null,
logoUrl text, 
descriptions text,
userId integer not null,
permission text,
primary key(albumId),
foreign key (userId) references Users(userId)
)

create table Images(
imageId integer identity(1,1) not null,
imageName varchar(20) not null,
imageUrl text not null, 
descriptions text,
createDate varchar(12), 
imageType text,
albumId integer,
primary key(imageId),
foreign key (albumId) references Albums(albumId)
)

create table userComment(
commentId integer identity(1,1) not null,
fromUser varchar(20) not null,
commentText text not null,
userId integer,
primary key(commentId),
foreign key (userId) references Users(userId)
)

create table albumComment(
commentId integer identity(1,1) not null,
fromUser varchar(20) not null,
commentText text not null,
albumId integer,
primary key(commentId),
foreign key (albumId) references Albums(albumId)
)

create table imageComment(
commentId integer identity(1,1) not null,
fromUser varchar(20) not null,
commentText text not null,
imageId integer,
primary key(commentId),
foreign key (imageId) references Images(imageId)
)



