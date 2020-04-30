#define First
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FDA_tech_lab_2.Models
{
#if First
    #region snippet
    public class TodoItem
    {
        public long Id { get; private set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
    #endregion
#else
    // Use this to test you can over-post
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }
#endif
}

