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

MIT License

Copyright (c) 2024 Francesco Dell'Ascenza

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
