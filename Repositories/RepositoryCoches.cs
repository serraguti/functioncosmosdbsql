using ControlCochesCosmosSql.Data;
using ControlCochesCosmosSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlCochesCosmosSql.Repositories
{
    public class RepositoryCoches
    {
        CochesContext context;

        public RepositoryCoches(CochesContext context)
        {
            this.context = context;
        }

        public Coche BuscarCoche(String id)
        {
            return this.context.Coches
                .SingleOrDefault(x => x.Id == id);
        }

        public void InsertarCoche(String id, String marca, String modelo, int velocidad)
        {
            Coche car = new Coche();
            car.Id = id;
            car.Marca = marca;
            car.Modelo = modelo;
            car.Velocidad = velocidad;
            car.Estado = "NUEVECITO";
            car.Fecha = DateTime.Now;
            this.context.Coches.Add(car);
            this.context.SaveChanges();
        }

        public void ModificarCoche(String id, String marca, String modelo, int velocidad)
        {
            Coche car = this.BuscarCoche(id);
            car.Marca = marca;
            car.Modelo = modelo;
            car.Velocidad = velocidad;
            car.Estado = "USADO";
            car.Fecha = DateTime.Now;
            this.context.SaveChanges();
        }

        public void EliminarCoche(String id)
        {
            Coche car = this.BuscarCoche(id);
            car.Estado = "CHATARRA";
            this.context.SaveChanges();
        }
    }
}
