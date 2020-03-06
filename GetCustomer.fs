namespace Customer

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.Extensions.Logging


module CosmosBindings =
    type Customer =
        { id: string
          name: string }

    [<FunctionName("HttpTrigger")>]
    let Run([<HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = null
            )>] req: HttpRequest,
            [<CosmosDB(
                databaseName = "customer-db",
                collectionName = "customer-container",
                ConnectionStringSetting = "CosmosDBConnection",
                SqlQuery = "select * from c"
            )>] customers: Customer seq) (log: ILogger) =
                log.LogInformation "F# HTTP trigger function processed a request."

                let names =
                    customers
                    |> Seq.map (fun c -> c.name)

                OkObjectResult(names)
