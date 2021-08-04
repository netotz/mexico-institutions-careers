using System.Collections.Generic;

namespace Database {
    public class Institution {
        public int Id { get; set; }
        public string Name { get; set; }
        public long OriginalId { get; set; }
        public List<Career> Careers { get; set; }
        public List<InstitutionCareer> InstitutionCareers { get; set; }
    }

    public class Career {
        public int Id { get; set; }
        public string Name { get; set; }
        public long OriginalId { get; set; }
        public int DegreeId { get; set; }
        public Degree Degree { get; set; }
        public List<Institution> Institutions { get; set; }
        public List<InstitutionCareer> InstitutionCareers { get; set; }
    }

    public class Degree {
        public int Id { get; set; }
        public string Name { get; set; }
        public long OriginalId { get; set; }
        public List<Career> Careers { get; set; }
    }

    public class InstitutionCareer {
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public int CareerId { get; set; }
        public Career Career { get; set; }
    }
}