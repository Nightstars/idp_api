using idp_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idp_api.Controllers
{
    /// <summary>
    /// ToDo controller
    /// </summary>
    [Route("api/todo")]
    public class ToDoController : Controller
    {
        /// <summary>
        /// _memoryCache
        /// </summary>
        private IMemoryCache _memoryCache { get; set; }
        private const string Key = "TODO_KEY";
        private readonly List<ToDo> _toDos;
        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="memoryCache"></param>
        public ToDoController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _toDos = new List<ToDo>
            {
                new ToDo
                {
                    Id=Guid.NewGuid(),
                    Titie="吃饭",
                    Completed=true
                },
                new ToDo
                {
                    Id=Guid.NewGuid(),
                    Titie="学习C#",
                    Completed=false
                },
                new ToDo
                {
                    Id=Guid.NewGuid(),
                    Titie="学习 .NET CORE",
                    Completed=false
                },
                new ToDo
                {
                    Id=Guid.NewGuid(),
                    Titie="学习 ASP.NET CORE",
                    Completed=false
                },
                new ToDo
                {
                    Id=Guid.NewGuid(),
                    Titie="学习 Entity Framework",
                    Completed=false
                }
            };
            if(!memoryCache.TryGetValue(Key,out List<ToDo> todos))
            {
                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(1));
                _memoryCache.Set(Key, todos, options);
            }
        }

        #region Get
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            if(!_memoryCache.TryGetValue(Key,out List<ToDo> todos))
            {
                todos = _toDos;
                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(1));
                _memoryCache.Set(Key, todos, options);
            }
            return Json(_toDos);
        }
        #endregion

        #region Post
        /// <summary>
        /// Post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ToDoEdit toDoEdit)
        {
            var todo = new ToDo
            {
                Id = Guid.NewGuid(),
                Titie = toDoEdit.Titie,
                Completed = toDoEdit.Completed
            };

            if (!_memoryCache.TryGetValue(Key, out List<ToDo> todos))
            {
                todos = _toDos;
            }
            _toDos.Add(todo);
            var options = new MemoryCacheEntryOptions()
                   .SetAbsoluteExpiration(TimeSpan.FromDays(1));
            _memoryCache.Set(Key, todos, options);

            return Ok(todo);
        }
        #endregion
    }
}
