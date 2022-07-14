namespace Contratacion.Modelos.Seguridad
{
    public class AuthenticationResponse : GeneralResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Email { get; set; }
    }
}
