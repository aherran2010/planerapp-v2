using PlannerApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlaneerApp.Client.Services.Exceptions
{
    //hacer f12 en exception para ver la clase con sus metadatos
    public class ApiException : Exception
    {
        //propiedad obtener respuesta error, agregaremos este error para que se pueda acceder desde 1 declaración catch en el cliente o desde la sintaxis o declaración try catch
        public ApiErrorResponse ApiErrorResponse { get; set; }
        public HttpStatusCode StatusCode { get; set; }	//400, …
        public ApiException(ApiErrorResponse error, HttpStatusCode statusCode) : this(error)
        {
            StatusCode = statusCode;
        }
        //lanzaremos la excepción 
        public ApiException(ApiErrorResponse error)
        {
            ApiErrorResponse = error;
        }
    }
}
