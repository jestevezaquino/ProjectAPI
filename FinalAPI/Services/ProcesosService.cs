using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAPI.Models;

namespace FinalAPI.Services
{
    public class ProcesosService
    {

        private readonly ApiDBContext apiDBContext;

        public ProcesosService(ApiDBContext _apiDBContext) 
        {
            apiDBContext = _apiDBContext;
        }

        //Obtener los registros del stock
        public List<Stock> ObtenerEntradas() 
        {
            var resultado = apiDBContext.Stock.ToList();
            return resultado;
        }

    }
}