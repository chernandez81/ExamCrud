namespace Exam.SqlServer.Entities;
public class Suscripcion
{
    public int IdAsociacion { get; set; }
    public int IdSuscriptor { get; set; }
    public ICollection<Suscriptor> Suscriptor { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime FechaFin { get; set; }
    public string? MotivoFin { get; set; }
}
