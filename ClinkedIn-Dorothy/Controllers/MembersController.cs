using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinkedIn_Dorothy.Models;
using ClinkedIn_Dorothy.Data;

namespace ClinkedIn_Dorothy.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        MemberRepository _repo;

        public MembersController()
        {
            _repo = new MemberRepository();
        }

        // Add a member
        [HttpPost]
        public IActionResult CreateMember(Member member)
        {
            _repo.AddMember(member);
            return Created($"/api/members/{member.Id}", member);
        }


        // Friends API calls
        [HttpPut("{memberId}/friends/{friendId}")]
        public IActionResult AddFriend(int memberId, int friendId)
        {
            _repo.AddAsFriend(memberId, friendId);

            return Ok();
        }

        [HttpGet("{memberId}/friends")]

        public IActionResult GetMyFriends(int memberId)
        {
            var getMyFriends = _repo.GetYourFriends(memberId);

            return Ok(getMyFriends);
        }

        [HttpGet("{memberId}/friends/their-friends")]
        public IActionResult FindFriendsOfMyFriend(int memberId)
        {
            var potentialFriends = _repo.GetFriendsOfMyFriends(memberId);
            return Ok(potentialFriends);
        }


        // Enemies API calls
        [HttpGet("{memberId}/enemies")]
        public IActionResult GetAllEnemies(int memberId)
        {
            var allEnemies = _repo.GetEnemies(memberId);

            return Ok(allEnemies);
        }

        [HttpPut("{memberId}/enemies/{enemyId}")]
        public IActionResult AddEnemy(int memberId, int enemyId)
        {
            _repo.AddAsEnemy(memberId, enemyId);

            return Ok();

        }


        // Services API Calls
        [HttpGet("{id}/services")]
        public IActionResult GetServices(int id)
        {
            var oneMember = _repo.GetById(id);

            return Ok(oneMember.Services);
        }

        [HttpPut("{id}/services")]
        public IActionResult NewService(int id, Member newService)
        {
            var oneMember = _repo.GetById(id);

            foreach (var service in newService.Services)
            {
                oneMember.Services.Add(service);
            }

            return Ok();
        }

        [HttpDelete("{id}/services")]
        public IActionResult DeleteService(int id, Member servicesToDelete)
        {
            var oneMember = _repo.GetById(id);

            for (int i = 0; i < oneMember.Services.ToArray().Length; i++)
            {
                foreach (var service in servicesToDelete.Services)
                {
                    if (service == oneMember.Services[i])
                    {
                        _repo.RemoveService(id, service);
                    }
                }
            }

            return Ok();
        }


        // Services API Calls
        [HttpGet("{interest}")]
        public IActionResult GetMembersByInterest(string interest)
        {
            var lowercaseInterest = interest.ToLower();
            var allMembersByInterest = _repo.FindByInterest(lowercaseInterest);
            return Ok(allMembersByInterest);
        }
        [HttpGet("{id}")]
        public IActionResult GetDaysLeft(int memberId)
        {
            var daysToFreedom = _repo.DaysLeft(memberId);
            return Ok(daysToFreedom);
        }
    }
}
