﻿using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Language
    {
        public Language()
        {
            Publication = new HashSet<Publication>();
            Vacancy = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Publication> Publication { get; set; }
        public virtual ICollection<Vacancy> Vacancy { get; set; }
    }
}
