# SilmarillionWebAPI

SilmarillionWebAPI is a demo project I am implementing to experiment with Microservices architecture and show my capabilities.
The project is about to create a backend for a textual role playing game (like D&D) based on Tolkien's Universe of Arda.

Firsts MVPs are focused on simple and classic features as CRUD methods for custom entities such as Characters, future feat would focus on
providing entities for a map and a navigation engine through the nodes of it.
Another feature yet to be implemented would be fighting system.

## Installation

TBD

## Usage

Once you have correctly installed the solution and run it, you can test the APIs through tools such as Postman.
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
