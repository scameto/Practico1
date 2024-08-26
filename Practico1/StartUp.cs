using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1
{
    internal class StartUp
    {
        public void UpdateDatabase()
        {
            using (var context = new DBContextCore())
            {
                context.Database.Migrate();
            }

        }
    }
}
