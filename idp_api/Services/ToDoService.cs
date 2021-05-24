using idp_api.DBContext;
using idp_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idp_api.Services
{
    public class ToDoService
    {
        #region initizlize
        public readonly MyDbContext _dbContext;
        public ToDoService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Insert
        public void Insert(ToDo toDo)
        {
            _dbContext.toDos.Add(toDo);

            _dbContext.SaveChanges();
        }
        #endregion

        #region Get
        public List<ToDo> Get()
        {
            return _dbContext.toDos.ToList();
        }
        #endregion
    }
}
