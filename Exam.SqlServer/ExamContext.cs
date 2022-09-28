using Exam.SqlServer.Constant;
using Exam.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.SqlServer;
public class ExamContext : DbContext
{
    public ExamContext(DbContextOptions<ExamContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema(Schemas.Default);
        builder.ApplyConfigurationsFromAssembly(typeof(ExamContext).Assembly);
    }

    public DbSet<Suscripcion>? Suscripciones { get; set; }
    public DbSet<Suscriptor>? Suscriptores { get; set; }
}