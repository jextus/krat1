namespace krat1.Server.Services.Seguridad;
public interface IEncriptarService
{
    string Encriptar(string textoPlano);
    string Desencriptar(string textoCifrado);
    bool VerificarHash(string textoPlano, string hash);
}