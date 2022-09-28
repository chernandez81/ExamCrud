namespace Exam.SqlServer.Entities;
public class Suscriptor
{
    public int IdSuscriptor { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? NumeroDocumento { get; set; }
    public int? TipoDocumento { get; set; }
    public int? Estado { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Password { get; set; }
    public List<Suscripcion>? Suscripcion { get; set; }
}
