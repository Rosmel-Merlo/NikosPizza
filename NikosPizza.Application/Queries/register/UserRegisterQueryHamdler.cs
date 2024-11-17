using MediatR;
using Microsoft.AspNetCore.Identity;
using NikosPizza.Application.Queries.register;
using NikosPizza.core.Entities.Identity;

namespace NikosPizza.Application.Queries.Register
{
    public class UserRegisterQueryHandler : IRequestHandler<UserRegisterQuery, UserRegisterQueuryResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRegisterQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserRegisterQueuryResponse> Handle(UserRegisterQuery request, CancellationToken cancellationToken)
        {
            var response = new UserRegisterQueuryResponse();

            // Verificar si el usuario ya existe por correo electrónico
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                response.Mensaje = "El usuario ya existe.";
                response.IsSuccess = false;
                return response;
            }

            // Crear un nuevo usuario
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email
                
            };

            // Registrar al usuario con la contraseña proporcionada
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                response.Mensaje = "Usuario registrado exitosamente.";
                response.IsSuccess = true;
            }
            else
            {
                response.Mensaje = "Error al registrar el usuario: " + string.Join(", ", result.Errors.Select(e => e.Description));
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
