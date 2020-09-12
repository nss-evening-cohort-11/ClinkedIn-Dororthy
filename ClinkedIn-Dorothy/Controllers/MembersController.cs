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

        [HttpPost]
        public IActionResult CreateMember(Member member)
        {
            _repo.AddMember(member);
            return Created($"/api/members/{member.Id}", member);
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var allMembers = _repo.GetAll();

            return Ok(allMembers);
        }

        [HttpGet("api/members/{memberId}/enemies")]
        public IActionResult GetAllEnemies()
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

        [HttpGet("{interest}")]
        public IActionResult GetMembersByInterest(string interest)
        {
            var lowercaseInterest = interest.ToLower();
            var allMembersByInterest = _repo.FindByInterest(lowercaseInterest);
            return Ok(allMembersByInterest);
        }
    }
}
