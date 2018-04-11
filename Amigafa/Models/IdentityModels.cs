using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Amigafa.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Amigafa.Models.Militar> Militars { get; set; }

        public System.Data.Entity.DbSet<Amigafa.Models.Formulario> Formularios { get; set; }

        public System.Data.Entity.DbSet<Amigafa.Models.ContagemTotal> ContagemTotals { get; set; }

        public System.Data.Entity.DbSet<Amigafa.Models.Pagamentos> Pagamentos { get; set; }

        public System.Data.Entity.DbSet<Amigafa.Models.Militar_Evento> Militar_Evento { get; set; }

        public System.Data.Entity.DbSet<Amigafa.Models.Convidado> Convidadoes { get; set; }
    }
}