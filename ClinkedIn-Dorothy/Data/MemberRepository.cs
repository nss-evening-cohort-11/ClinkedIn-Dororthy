﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn_Dorothy.Models;

namespace ClinkedIn_Dorothy.Data
{
    public class MemberRepository
    {
        static List<Member> _members = new List<Member>()
         {
            new Member {
                Id = 1,
                Name = "Prison Mike",
                Interest = new List<string> { "Swimming", "Singing", "Basketball" },
                Services = new List<string> { "Haircuts", "Smuggling", "Shoe shine" },
                Friends = new List<Member> { },
                Enemies = new List<Member> { },
            },
            new Member {
                Id = 2,
                Name = "Joe",
                Interest = new List<string> { "Swimming", "Gambling", "Arm Wrestling" },
                Services = new List<string> { "Haircuts", "Masonry", "Carpentry" },
                Friends = new List<Member> { },
                Enemies = new List<Member> { },
            },
            new Member {
                Id = 3,
                Name = "Brad",
                Interest = new List<string> { "Weight Lifting", "Gambling", "Fishing" },
                Services = new List<string> { "Writing", "Sewing", "Carpentry" },
                Friends = new List<Member> { },
                Enemies = new List<Member> { },
            }
        };

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

        public void RemoveService(int id, string delServe)
        {
            var oneMember = GetById(id);
            oneMember.Services.Remove(delServe);
        }

        public Member GetById(int id)
        {
            return _members.FirstOrDefault(member => member.Id == id);
        }

        public List<Member> LowercaseInterests()
        {
            var loweredMembers = new List<Member>();

            // loop through the members 
            foreach (var member in _members)
            {
                var loweredInterests = new List<string>();
                // change each string in Interests list for current member to be lowercased
                loweredInterests = member.Interest.ConvertAll(i => i.ToLower());

                // overwrite previous list of interests with modified list
                member.Interest = loweredInterests;

                loweredMembers.Add(member);
            };

            return loweredMembers;
        }

        public List<Member> FindByInterest(string interest)
        {
            var membersWithLowercaseInterests = LowercaseInterests();
            var filteredMembers = membersWithLowercaseInterests.Where(member => member.Interest.Contains(interest)).ToList();

            return filteredMembers;
        }
    }
}
