# fsharp-cosmos-function
Azure Function with Cosmos DB bindings

## Infrastrucutre

### Create database
Create a cosmos database and name it `customer-db` with a collection named `customer-container`.
Populate the db with some records `{id: string, name: string}`

### Add cosmos connection string to local.settings.json
```
...
"Values" {
    ...
    "CosmosDBConnection": "AccountEndpoint=https://XXXXXXX;"
}
...
```

## Run
```
$ func start
$ curl http://localhost:7071/api/HttpTrigger
["Alice", "Bob"]
```
