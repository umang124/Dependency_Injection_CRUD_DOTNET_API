using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class PersonalInformationDBContext : DbContext
    {
        public PersonalInformationDBContext(DbContextOptions<PersonalInformationDBContext> options) : base(options)
        {

        }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }
    }
}
