using System;
using System.Collections.Generic;
using ControlCochesCosmosSql.Models;
using ControlCochesCosmosSql.Repositories;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ControlCochesCosmosSql
{
    public class Function1
    {
        RepositoryCoches repo;

        public Function1(RepositoryCoches repo)
        {
            this.repo = repo;
        }

        [FunctionName("functioncosmos")]
        public void Run([CosmosDBTrigger(
            databaseName: "coches",
            collectionName: "micoleccion",
            ConnectionStringSetting = "cosmosdb"
            , CreateLeaseCollectionIfNotExists = true,
             LeaseCollectionName = "leases")]
        IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                //LO QUE VIENE SON DATOS JSON, PERO UN ARRAY
                var data = JsonConvert.SerializeObject(input);
                log.LogInformation("Coche cosmos: " + data);
                List<Coche> coches =
                    JsonConvert.DeserializeObject<List<Coche>>(data);
                Coche car = coches[0];
                if (this.repo.BuscarCoche(car.Id) == null)
                {
                    this.repo.InsertarCoche(car.Id, car.Marca, car.Modelo, car.Velocidad);
                }
                else
                {
                    this.repo.ModificarCoche(car.Id, car.Marca, car.Modelo, car.Velocidad);
                }

                log.LogInformation("Datos almacenados en SQL!!!");
                log.LogInformation("Coche SQL: " 
                    + coches[0].Marca + ", " + coches[0].Modelo);
            }
        }
    }
}
