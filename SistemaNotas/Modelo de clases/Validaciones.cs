using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotas.Modelo_de_clases
{
    internal class Validaciones
    {
        public bool ValidarLogin(string usuario, string contraseña)
        {
            // Lógica para validar el inicio de sesión
            // Devuelve true si las credenciales son válidas, de lo contrario, false
            // Aquí deberías implementar la lógica real de validación
            return usuario == "admin" && contraseña == "admin123";
        }

        //public bool ValidarRegistro(Estudiante estudiante)
        //{
        //    // Lógica para validar la información del estudiante al registrarse
        //    // Devuelve true si la información es válida, de lo contrario, false
        //    // Aquí deberías implementar la lógica real de validación
        //    return !string.IsNullOrEmpty(estudiante.Nombre) &&
        //           !string.IsNullOrEmpty(estudiante.Apellidos) &&
        //           !string.IsNullOrEmpty(estudiante.Edad.ToString()) &&
        //           !string.IsNullOrEmpty(estudiante.Cedula) &&
        //           !string.IsNullOrEmpty(estudiante.Correo) &&
        //           !string.IsNullOrEmpty(estudiante.Telefono);
        //}
    }
}