using idp_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idp_api.DBContext
{
    public class MyDbContext: DbContext
    {
        #region initialize
        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        {

        }
        #endregion

        #region DbSet
        public DbSet<ToDo> toDos { get; set; }
        #endregion
    }
}
