using AutoMapper;
using Exam.Infrastructure.Data;
using Exam.Model;
using EntitySuscriptor = Exam.SqlServer.Entities.Suscripcion;
using Microsoft.EntityFrameworkCore;

namespace Exam.SqlServer.Repositories;
public class SuscripcionRepository : ISuscripcionRepository
{
    private readonly ExamContext _context;
    private readonly IMapper _mapper;

    public SuscripcionRepository(ExamContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    
    public async Task Save(Model.Suscripcion suscripcion)
    {
        try
        {
            var suscriptorEntity = _mapper.Map<Suscripcion, EntitySuscriptor>(suscripcion);
            await _context.AddAsync(suscriptorEntity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<IList<Suscripcion>> Select(int? IdSuscriptor = null)
    {
        var list = new List<Suscripcion>();

        var query = _context
            .Suscripciones!
           // .Include(x => x.Suscriptor)
            .AsNoTracking();

        if(IdSuscriptor != null)
            query = query.Where(x => x.IdSuscriptor == IdSuscriptor);

        try
        {

            list = await query.Select(r => _mapper.Map<Suscripcion>(r)).ToListAsync();
        }
        catch (Exception ex)
        {

            throw;
        }

        return  list;
    }

    Task<IList<Model.Suscripcion>> ISuscripcionRepository.Select(int? IdSuscriptor)
    {
        throw new NotImplementedException();
    }
}
