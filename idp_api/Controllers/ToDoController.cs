using idp_api.Models;
using idp_api.Services;
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
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly ToDoService _toDoService;
        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="memoryCache"></param>
        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;

        }

        #region Get
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_toDoService.Get());
        }
        #endregion

        #region Post
        /// <summary>
        /// Post
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]ToDoEdit toDoEdit)
        {
            var todo = new ToDo
            {
                Id = Guid.NewGuid(),
                Title = toDoEdit.Title,
                Completed = toDoEdit.Completed
            };
            _toDoService.Insert(todo);
            return Ok(todo);
        }
        #endregion
    }
}
