using GeniusManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusManager.Domain.Entities.Lookups
{
    public class Qualification : BaseEntity
    {
        public long EducationLevelId { get; set; }
        public EducationLevel? EducationLevel { get; set; }

        public IEnumerable<QualificationSpecialization> Specializations { get; set; }= new List<QualificationSpecialization>();
    }
}
