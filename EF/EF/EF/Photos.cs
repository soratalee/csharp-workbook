using System;
using System.Collections.Generic;

namespace EF
{
    public class Photos
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }      

        public DateTime CreateDate { get; set; }

    }
}