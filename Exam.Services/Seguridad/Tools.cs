using System.Text;

namespace Exam.Services.Seguridad;
public static class Tools
{
    /// Encripta una cadena
    public static string Encriptar(this string _cadenaAencriptar)
    {
        string result = string.Empty;
        byte[] encryted = Encoding.Unicode.GetBytes(_cadenaAencriptar);
        result = Convert.ToBase64String(encryted);
        return result;
    }

    /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
    public static string DesEncriptar(this string _cadenaAdesencriptar)
    {
        string result = string.Empty;
        byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
        //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
        result = Encoding.Unicode.GetString(decryted);
        return result;
    }
}
