namespace DevFreela.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwToken(string email, string role);
    }
}
