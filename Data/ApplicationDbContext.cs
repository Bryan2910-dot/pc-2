using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pc_2.Models;

namespace pc_2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Mascotas> DbSetMascotas { get; set; }
    public DbSet<Adoptantes> DbSetAdoptantes { get; set; }
    public DbSet<Adopciones> DbSetAdopciones { get; set; }
}
