namespace UsuariosMG.Microservice.Dtos
{
    /// <summary>
    /// DTO utilizado para crear usuarios.
    /// </summary>
    public class UserDto
    {
        public string NombreUsuario { get; set; }

        public int ElementosPendientes { get; set; }

        public int ElementosCompletados { get; set; }

        public int PendientesAltaPrioridad { get; set; }

        public bool EstaSaturado { get; set; }
    }
}
