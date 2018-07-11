using ModernStore.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Transactions
{
    public class Uouw : IUow
    {
        private readonly ModernStoreDataContext _context;
        
        public Uouw(ModernStoreDataContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            
        }
    }
}
