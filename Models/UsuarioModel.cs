using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanaderiaDonMario.Models
{
    public class UsuarioModel : AbstractModel<Usuario>
    {
        public Usuario VerificarCuentaporEmail(String email, String pin)
        {
            return ctx.Usuario.Where(u => u.Usuario1 == email && u.Contraseña == pin).FirstOrDefault();

        }
    }

}