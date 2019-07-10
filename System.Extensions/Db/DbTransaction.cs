using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace System.Db
{
    public class DbTransaction : IUnitOfWork
    {
        private readonly DbContext context;

        public DbTransaction()
        {

        }

        public DbTransaction(DbContext context)
        {
            this.context = context;
        }

        public async Task BeginTransaction()
        {
            
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public async Task Rollback()
        {
            
        }
    }
}
