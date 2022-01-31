# Backend Engineer assignment
This assignment is not a fail/pass kind of assignment, it's merely a way for us to get insight into how you structure code etc.

We use it as a base for interview 2.

You should fork the repository and once you have completed the assignment you should send us the link to your version.

Create you code in the `src` folder.

If you have to use private repository for the assignment, then ask us for github usernames that you can invite.

## The assignment
_NOTE: You are expected to know how to use docker containers_

Implement a `GatewayService` which handles incoming requests. Pass the `GET` requests on to a underlying service called `PokemonService`.

The `PokemonService` should respond back to the `GatewayService` and on to the `Client`. The service should hold data in a `PostgreSQL` database. How you store the data in the database is up to you.

We have provided a `pokedex.json` file - you can use `https://json2csharp.com/` to create a C# class for it.

You should handle all standard REST operations (`GET`, `PUT`, `POST`, `DELETE`) in the `GatewayService`

For all operations except `GET` you should handle them in a async manner through a broker of some sort - use `RabbitMQ` as it's quite easy to get working locally in `docker`.