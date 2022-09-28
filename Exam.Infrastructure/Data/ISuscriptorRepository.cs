using Exam.Model;
using System.Security.Cryptography.X509Certificates;

namespace Exam.Infrastructure.Data;
public interface ISuscriptorRepository
{
    Task<Suscriptor> Select(int? idSuscriptor = null,int? tipoDocumento = null,
        string? numeroDocumento = null, string? userName = null);
    Task SaveSuscriptor(Suscriptor suscriptor);

    Task EditSuscriptor(Suscriptor suscriptor);
}
