using GeniusManager.Domain.Common;
using GeniusManager.Domain.Entities.Lookups;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusManager.Domain.Entities
{
    public class QualificationSpecialization :BaseEntity
    {
        
        public long QualificationId { get; set; }
        public Qualification? Qualification { get; set; }
        public long SpecializationId { get; set; }
        public Specialization? Specialization { get;set; }
    }
}
