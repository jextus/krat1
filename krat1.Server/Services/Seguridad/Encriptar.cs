using krat1.Server.Services.Seguridad;
using System.Security.Cryptography;
using System.Text;


public class EncriptacionService : IEncriptarService
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public EncriptacionService()
    {
        
        _key = Encoding.UTF8.GetBytes("1234567890123456"); 
        _iv = Encoding.UTF8.GetBytes("6543210987654321"); 
    }

    public string Encriptar(string textoPlano)
    {
        if (string.IsNullOrEmpty(textoPlano))
            return string.Empty;

        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(textoPlano);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    public bool VerificarHash(string textoPlano, string hash)
    {
        if (string.IsNullOrEmpty(textoPlano) || string.IsNullOrEmpty(hash))
            return false;

        try
        {
            string textoDesencriptado = Desencriptar(hash);
            return textoDesencriptado == textoPlano;
        }
        catch
        {
         
            return false;
        }
    }

    public string Desencriptar(string textoCifrado)
    {
        if (string.IsNullOrEmpty(textoCifrado))
            return string.Empty;

        using var aes = Aes.Create();
        aes.Key = _key;
        aes.IV = _iv;

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        var buffer = Convert.FromBase64String(textoCifrado);

        using var ms = new MemoryStream(buffer);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }
}