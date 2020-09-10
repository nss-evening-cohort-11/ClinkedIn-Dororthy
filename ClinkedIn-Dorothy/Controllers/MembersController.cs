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
    }
}
