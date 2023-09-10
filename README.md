

<h1 align="center">Neko space project</h1>

<p align="center">
    <i>multilingual anime database</i>
</p>

![GitHub status](https://img.shields.io/pypi/status/ansicolortags.svg)

## **Our Goal**

Popularizing the passion for anime, manga, and games in various corners of the world.

## Our Vision

We believe that this translation portal will become a great starting point for popularizing anime and manga in different countries around the world where information about them is limited due to language barriers. Additionally, we plan to open an API for third-party developers so that they can create their own fantastic applications!

## **Our Capabilities**

- Providing information about the work in various languages of the world.
- Viewing information about the work in different languages.

## **Our Audience**

- People interested in anime, manga, or games.
- Creators.
- Developers.

## **Platform Features**

### **Login and Registration**

It is done through:

- Email and Password
- Social networks
    - Facebook
    - Google
    - Telegram

> Authorization is based on Jwt tokens. The token is refreshed using a refresh token.
> 

### Search

With the help of search, you can search for works available in the database in different languages. Available functions include:

- Filtering
- Sorting
- Pagination

### Data Localization

The process of data localization is divided into 2 stages:

1. User-provided translation.
2. Administration verification of the correctness of the translation.

Localization can be done for:

- Title
- Description
- Poster

Users have the ability to provide translations for any work through a special form. In addition to providing the translation of the title or description, or uploading a localized poster, the user needs to specify the language to which the translation is being made.

Also, if necessary, they can indicate the source of the translation if they are not the author.

In the administrator panel, all proposals submitted by site users are displayed. Here, the administrator can accept or reject the proposal or change the decision already made. They can also view additional information about the work or the user.

In addition, the administration can modify the properties of proposals:

- Priority
- Visibility

### Roles

- Administrator: A user who has full access to granting and changing roles of other users.
- Moderator: A user who can view and make decisions regarding proposals.
- Registered User: An individual who is registered on the website and has the right to submit proposals.
- Guest: A user who does not have an account on the website and can only view information.

> Ролі працюють на базі **ClaimsPrincipal**
> 

### Data Seeding and Auto-Updates

A plugin system for data providers has been implemented. It allows adding various data providers for information about anime, manga, light novels, and more to the program.

Additionally, a priority system has been developed, which allows specifying priorities for each individual repository. In other words, you can indicate which data is considered a priority when it's available from different sources.

The following functions are available based on the plugin system:

- Auto-Seeding: Fills the portal with initial data.
- Auto-Updates: Keeps the data up-to-date through regular updates.

## The libraries used

- Entity Framework Core
- DependencyInjection
- Mapster
- AspNetCore.Authentication
- AspNetCore.Identity
- Microsoft.Extensions.Configuration
- AspNet.WebApi
- JikanDotNet

And other

## The technologies used

- Elastic Search
- Postgres SQL
- Identity / Refresh tocken
- Swagger   / OpenAPI 3.1
- Docker

## The used software

- Visual Studio
- Swagger UI
- Insomnia
- Jira
- Docker CLI
- Cloudflare (zero trust tunnel)

The project is hosted on an external Linux server. To expedite the testing and deployment process, relevant scripts have been written.

## Architecture

We plan to develop this project as a multi-service platform.

## Prototype UI
![Home page](https://github.com/Axiks/SpaceNeko/assets/36519646/8daf789b-730d-4b75-afb2-1f6c8ab686b1)
![Search page](https://github.com/Axiks/SpaceNeko/assets/36519646/007d6c57-8470-4db8-8d93-6b3784b260e9)
![Login page](https://github.com/Axiks/SpaceNeko/assets/36519646/cb4f1175-3db1-4b94-99b1-3321619e3176)

