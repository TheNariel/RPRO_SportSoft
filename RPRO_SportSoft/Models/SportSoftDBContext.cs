using System.Data.Entity;

namespace RPRO_SportSoft.Models
{
    public class SportSoftDBContext: DbContext
    {
        public DbSet<Sportoviste> TSportoviste { get; set; }
    }
   
}