using MediatR;
using NikosPizza.Application.Queries.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikosPizza.Application.Queries.register
{
    public  class UserRegisterQuery : IRequest<UserRegisterQueuryResponse>
    {
        public UserRegisterQuery() { }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
