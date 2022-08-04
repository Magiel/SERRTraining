using System;

namespace Entities.Core
{
    public class Todo
    {
        public int TodoID { get; set; }
        public int UserID { get; set; }
        public int TodoTypeID { get; set; }
        public DateTime DueDate { get; set; }
        public string Comment { get; set; }
        public DateTime DateFlag { get; set; }
        public bool IsActive { get; set; }
    }
}