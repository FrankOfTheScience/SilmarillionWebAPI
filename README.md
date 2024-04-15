# SilmarillionWebAPI

SilmarillionWebAPI is a demo project I am implementing to experiment with Microservices architecture and show my capabilities.
The project is about to create a backend for a textual role playing game (like D&D) based on Tolkien's Universe of Arda.

Firsts MVPs are focused on simple and classic features as CRUD methods for custom entities such as Characters, future feat would focus on
providing entities for a map and a navigation engine through the nodes of it.
Another feature yet to be implemented would be fighting system.

## Installation

As this project as just a demo purpose and it is not intended to be a complete and full product, at least for now, release version is not available.
You can download and run the repo in debug mode to test it tho, this brief guide is to show how to do it.

### Prerequisite:
You must have Docker installed on your machine.

### Procedure:
1. Download the repository
2.1 Open the solution file with VS Code or VS;
2.1.1 Be sure that Docker Compose is set as default Startup Project, if not choose it
2.1.2 Launch the project in Debug mode
2.2 Alternatively you can position yourself in the solution folder and then:
2.2.1 Launch the command `dotnet restore`
2.2.2 Launch the command `docker-compose up -b`
2.2.3 Launch the command `docker-compose up -d`


## Usage

Once you have correctly installed the solution and ran it, you can test the APIs through tools such as Postman.
Authentication method is through JwtToken, at the moment there are two hard-coded users with roles of Admin and User,
a future feat is to implement a full authentication storage with a dedicated DB to store accounts data.
So you are required to send an HTTP request like those, depending which role you want to test:

```bash
curl --location --request POST 'http://localhost:8001/api/Account' \
--header 'Content-Type: application/json' \
--data '{
    "UserName": "admin",
    "Password": "AdminPassword01!"
}'
```

```bash
curl --location --request POST 'http://localhost:8001/api/Account' \
--header 'Content-Type: application/json' \
--data '{
    "UserName": "user",
    "Password": "UserPassword01!"
}'
```

Then once you get the token, you can call other APIs (go to **SilmarillionWebAPI/ApiGateway/ocelot.json** to have a list of all the available APIs) with Bearer Authorization header,
you need to add the key-value header "Authorization"-"Bearer {{insert_token}}" to the API call, such as the following:

```bash
curl --location --request {{insert_method}} 'http://localhost:8001/api/{{insert_path}}' \
--header 'Authorization: Bearer {{insert_token}}'
```

## License

[License](https://github.com/FrankOfTheScience/SilmarillionWebAPI/blob/master/LICENSE)
