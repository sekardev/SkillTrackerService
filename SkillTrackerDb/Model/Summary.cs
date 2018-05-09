using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillTrackerDb.Model
{
  public   class Summary
    {
        public int RegisteredCandidates { get; set; }
        public int  FemaleCandidates { get; set; }
        public int MaleCandidates { get; set; }
        public int FresherCandidates { get; set; }
        public int RatedCandidates { get; set; }

        public int MaleRatedCandidates { get; set; }
        public int FemaleRatedCandidates { get; set; }

        public int L1RatedCandidates { get; set; }
        public int L2RatedCandidates { get; set; }
        public int L3RatedCandidates { get; set; }
        
        public Chart skillChart { get; set; }
        

    }
    public class Chart
    {
        public List<string> Label { get; set; }
        public List<int> Values { get; set; }
    }
}
