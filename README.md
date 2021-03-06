# StudentBook
> A simplified version of Facebook for students

## Table of contents
* [General info](#general-info)
* [Screenshots](#screenshots)
* [Technologies](#technologies)
* [Setup](#setup)
* [Features](#features)
* [Status](#status)
* [Contact](#contact)

## General info
This is a simplified version of Facebook - StudentBook. You can register in the portal and then use functions such as browsing user profiles, liking them, editing the profile, adding photos, posts, as well as filtering users by age and gender. 

## Screenshots
<p align="center">
  <img src="./Screenshots/listauzytkownikow.png">
</p>

<p align="center">
  <img src="./Screenshots/ekranglowny.png">
  
  <img src="./Screenshots/rejestracja.png">

  <img src="./Screenshots/posty.png">
  
  <img src="./Screenshots/posty2.png">

  <img src="./Screenshots/profil.png">

  <img src="./Screenshots/profilowe.png">
 </p>

<p align="center">
  <img src="./Screenshots/edycja.png">
  
  <img src="./Screenshots/edycja2.png">

  <img src="./Screenshots/listauzytkownikow2.png">

  <img src="./Screenshots/galeria.png">
  
  <img src="./Screenshots/likes.png">

  <img src="./Screenshots/dodawaniezdjec.png">
 </p>

## Technologies
Back-end:
* ASP.NET Core Web Api - version 3.1
* ASP.NET Core Authentication JWT Bearer - version 3.0
* Entity Framework Core - version 3.1.2
* AutoMapper - version 4.0.1
* Cloudinary .NET - version 1.3.1
* MySQL Database - version 8.0 

Front-end:
* Angular - version 9.0.6
* ng2-file-upload - version 1.3.0
* auth0/angular-jwt - version 4.1.2
* Bootstrap - version 4.4.1
* Font-Awesome - version 4.7.0
* Ngx-bootstrap - version 5.5.0
* kolkov/ngx-gallery - version 1.1.0
* AlertifyJS - version 1.13.1


## Setup
All you have to do is to go to directory 'StudentBook.API' and then enter the command: 'dotnet run' from terminal.
Then on the other terminal go to directory 'StudentBook.SPA' and enter the command: 'ng serve'.
The application should build. If build was successful, you can enter in your browser: http://localhost:4200/
And that's it! You can now use the application :)

## Features
List of features ready:
* Registration and login with tokens
* Viewing the list of users along with filtering and pagination
* Liking users and viewing likes
* Editing a profile
* Adding photos to the profile and viewing them in the photo gallery
* Possibility to set the photo as the main one
* Adding simple posts

## Status
Project is: _finished_.

## Contact
Created by [Piotr Buczek](mailto:piotr.buczek37@gmail.com?subject=[GitHub]%20StudentBook) and [Małgorzata Wróbel](mailto:77wrobel@gmail.com?subject=[GitHub]%20StudentBook)- feel free to contact us!
