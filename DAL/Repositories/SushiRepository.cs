using Final_project.DAL.Interfaces;
using Final_project.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.DAL.Repositories
{
    internal class SushiRepository : BaseRepository<Sushi>
    {
        readonly DbContext db;
        public SushiRepository(DbContext context) : base(context)
        {
            db = context;
        }

        public override async Task<IEnumerable<Sushi>> GetListAsync()
        {
            return await db.Set<Sushi>().ToListAsync().ConfigureAwait(false);
        }

        public Sushi GetNumer(int number)
        {
            return db.Set<Sushi>().Find(number);
        }
    }
}
