using Exam.Infrastructure.Data;
using Exam.Model;

namespace Exam.Services;
public class Services
{
    private readonly ISuscripcionRepository _suscripcionRepository;
    private readonly ISuscriptorRepository _suscriptorRepository;

    public Services(ISuscripcionRepository suscripcionRepository, 
        ISuscriptorRepository suscriptorRepository)
    {
        _suscripcionRepository = suscripcionRepository;
        _suscriptorRepository = suscriptorRepository;
    }

    public async Task GetSubscriptor()
    {
        var localSuscripcion = await _suscriptorRepository.Select();       
    }

    public async Task<Suscriptor> BuscaSuscriptor(BuscaSuscriptor buscaSuscriptor)
    {
        var localSuscripcion = await _suscriptorRepository.Select(null,buscaSuscriptor.TipoDocumento, buscaSuscriptor.NumeroDocumento);

        return localSuscripcion;
    }

    public async Task<Suscriptor> BuscaUsername(string username)
    {
        var localSuscripcion = await _suscriptorRepository.Select(null, null, null, username);

        return localSuscripcion;
    }

    public async Task GuardaSuscriptor(Suscriptor suscriptor)
    {
        suscriptor.Pwd = Seguridad.Tools.Encriptar(suscriptor.Pwd!);

        await _suscriptorRepository.SaveSuscriptor(suscriptor);
    }
    public async Task EditarSuscriptor(Suscriptor suscriptor)
    {
        await _suscriptorRepository.EditSuscriptor(suscriptor);
    }

    public async Task GuardaSuscripcion(Suscripcion suscripcion)
    {
        await _suscripcionRepository.Save(suscripcion);
    }
}