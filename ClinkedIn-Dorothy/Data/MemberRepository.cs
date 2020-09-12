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

        

        public void AddMember(Member memberToAdd)
        {
            int newId = 1;
            if (_members.Count > 0)
            {
                newId = _members.Select(p => p.Id).Max() + 1;
            }
            memberToAdd.Id = newId;

            _members.Add(memberToAdd);
        }

        public void AddAsEnemy(int memberId, int enemyId)
        {
            var member = GetById(memberId);
            var newEnemy = GetById(enemyId);

            member.Enemies.Add(newEnemy);
        }

        public Member GetById(int id)
        {
            return _members.FirstOrDefault(member => member.Id == id);
        }
    }
}
