using GeniusManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusManager.Domain.Entities.Lookups
{
    public class EducationLevel:BaseEntity
    {
        public IEnumerable<Qualification> Qualifications { get; set; } = new List<Qualification>();
    }
}
