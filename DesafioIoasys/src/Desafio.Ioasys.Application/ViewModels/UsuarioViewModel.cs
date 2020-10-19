namespace Desafio.Ioasys.Application.ViewModels
{
    public class UsuarioViewModel 
    {
        public UsuarioViewModel()
        {
            SucessoLogin = false;
        }

        public string NomeUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public bool SucessoLogin { get; set; }
    }
}
