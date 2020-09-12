using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn_Dorothy.Data;
using ClinkedIn_Dorothy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn_Dorothy.Controllers
{
    [Route("api/warden")]
    [ApiController]
    public class WardenController : ControllerBase
    {
        MemberRepository _repo;

        
        public WardenController()
        {
            _repo = new MemberRepository();
        }

        // Get all members
        [HttpGet("{id}")]
        public IActionResult GetAllMembers(int id)
        {
            var allMembers = _repo.GetAll();
            var wardenCheck = _repo.GetById(id);

            if (wardenCheck.isWarden == true)
            {
                return Ok(allMembers);
            } else
            {
                return Unauthorized();
            }
        }
    }
}
