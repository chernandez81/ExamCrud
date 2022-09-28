namespace Exam.Model;
public class Suscripcion
{
    public int IdAsociacion { get; set; }
    public int IdSuscriptor { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public string? Comentario { get; set; }
}
