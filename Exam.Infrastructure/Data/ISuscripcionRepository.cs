using Exam.Model;

namespace Exam.Infrastructure.Data;
public interface ISuscripcionRepository
{
    Task<IList<Suscripcion>> Select(int? IdSuscriptor = null);

    Task Save(Suscripcion suscripcion);
}
