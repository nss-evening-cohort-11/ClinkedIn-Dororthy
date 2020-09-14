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
        public List<string> Interest { get; set; } = new List<string>();
        public List<string> Services { get; set; } = new List<string>();
        public List<Member> Friends { get; set; } = new List<Member>();
        public List<Member> Enemies { get; set; } = new List<Member>();
        public DateTime? DateOfRelease { get; set; } = null;
        public bool isWarden { get; set; } = false;


    }
}
