using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.Application.Queries.register
{
    public class UserRegisterQueuryResponse
    {
        public UserRegisterQueuryResponse() { }
        public bool IsSuccess { get; set; }
        public string Mensaje { get; set; }
    }
}
