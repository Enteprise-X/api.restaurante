using Microsoft.EntityFrameworkCore;

namespace Orion.Infrastructure.Persistence;

/// <summary>
/// Banco de negócio do Orion. Identidade (usuarios/empresas) permanece no Core.
/// Schema padrão: orion.
/// </summary>
public sealed class OrionDbContext(DbContextOptions<OrionDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("orion");
        base.OnModelCreating(modelBuilder);
    }
}
