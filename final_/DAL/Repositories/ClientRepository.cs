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
    internal class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        readonly DbContext db;
        public ClientRepository(DbContext context) : base(context)
        {
            db = context;
        }

        public override async Task<IEnumerable<Client>> GetListAsync()
        {
            return await db.Set<Client>().Include(p => p.Order).ToListAsync().ConfigureAwait(false);
        }
    }
}

