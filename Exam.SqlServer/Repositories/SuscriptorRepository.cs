using AutoMapper;
using Exam.Infrastructure.Data;
using Exam.Model;
using EntitySuscriptor = Exam.SqlServer.Entities.Suscriptor;
using Microsoft.EntityFrameworkCore;

namespace Exam.SqlServer.Repositories;
public class SuscriptorRepository : ISuscriptorRepository
{
    private readonly IMapper _mapper;
    private readonly ExamContext _context;

    public SuscriptorRepository(ExamContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task EditSuscriptor(Suscriptor suscriptor)
    {
        try
        {
            var result = await Select(suscriptor.IdSuscriptor);

            if (result != null)
            {
                try
                {
                    var suscriptorEntity = _mapper.Map<Suscriptor, EntitySuscriptor>(suscriptor);

                    _context.Suscriptores!.Attach(suscriptorEntity);
                    _context.Entry(suscriptorEntity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    public async Task SaveSuscriptor(Suscriptor suscriptor)
    {
        try
        {
            var suscriptorEntity = _mapper.Map<Suscriptor, EntitySuscriptor>(suscriptor);
            await _context.AddAsync(suscriptorEntity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }

    public async Task<Suscriptor> Select(int? idSuscriptor = null, int? tipoDocumento = null,
        string? numeroDocumento = null, string? userName = null)
    {
        var objSuscriptor = new Suscriptor();

        var query = _context
            .Suscriptores!
        // .Include(x => x.Suscriptor)
            .AsNoTracking();

        if (idSuscriptor != null)
            query = query.Where(x => x.IdSuscriptor == idSuscriptor);

        if (tipoDocumento != null)
            query = query.Where(x => x.TipoDocumento == tipoDocumento);

        if (numeroDocumento != null)
            query = query.Where(x => x.NumeroDocumento == numeroDocumento);

        if (userName != null)
            query = query.Where(x => x.NombreUsuario == userName);

        objSuscriptor = await query.Select(r => _mapper.Map<Suscriptor>(r)).FirstOrDefaultAsync();

        return objSuscriptor!;
    }
}
