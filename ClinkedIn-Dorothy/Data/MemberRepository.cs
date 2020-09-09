using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn_Dorothy.Models;

namespace ClinkedIn_Dorothy.Data
{
    public class MemberRepository
    {
        static List<Member> _members = new List<Member>();

        public List<Member> GetAll()
        {
            return _members;
        }
    }
}
