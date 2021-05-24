using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace idp_api.Models
{
    /// <summary>
    /// ToDo
    /// </summary>
    public class ToDo
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid Id { get; set; }

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
