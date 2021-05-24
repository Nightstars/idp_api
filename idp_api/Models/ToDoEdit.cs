using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idp_api.Models
{
    /// <summary>
    /// ToDoEdit
    /// </summary>
    public class ToDoEdit
    {
        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// completed flag
        /// </summary>
        public bool Completed { get; set; }
    }
}
