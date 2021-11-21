using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Responses
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }

    //mismo objeto en un genérico y tiene carga util o 1 valor dentro de el
    public class ApiResponse<T> : ApiResponse   //heredará de ApiResponse
    {
        public T Value { get; set; }    //adición tendrá valor get
    }
 
}
