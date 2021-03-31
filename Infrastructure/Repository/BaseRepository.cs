using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastucture.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly CaminhaoContext contexto;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(CaminhaoContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}
