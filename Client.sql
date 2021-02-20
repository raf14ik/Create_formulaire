create database Client;
create table inscription (
identifiant int primary key not null,
nom varchar(250) not null,
prenom varchar(250) not null,
email varchar(250) not null
)
