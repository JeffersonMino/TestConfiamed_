namespace UsuariosMG.Microservice.Dtos
{
    public class UserDto
    {
        public string NombreUsuario { get; set; }

        public int ElementosPendientes { get; set; }

        public int ElementosCompletados { get; set; }

        public int PendientesAltaPrioridad { get; set; }

        public bool EstaSaturado { get; set; }
    }
}
