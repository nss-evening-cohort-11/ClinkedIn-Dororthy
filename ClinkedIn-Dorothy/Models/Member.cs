using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn_Dorothy.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Interest { get; set; }
        public List<string> Services { get; set; }
        public List<Member> Friends { get; set; }
        public List<Member> Enemies { get; set; }

    }
}
