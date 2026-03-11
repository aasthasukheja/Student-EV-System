using System.Security.Claims;
using LeaveManagementAPI.Data;
using LeaveManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaveController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Employee")]
        [HttpPost("apply")]
        public IActionResult ApplyLeave(LeaveRequest leave)
        {
            var userId = User.FindFirst("UserId")?.Value;
            if (userId == null)
                return Unauthorized();

            leave.EmployeeId = int.Parse(userId);
            leave.Status = "Pending";

            _context.LeaveRequests.Add(leave);
            _context.SaveChanges();

            return Ok(new { message = "Leave applied successfully" });
        }

        [Authorize(Roles = "Employee")]
        [HttpGet("my-leaves")]
        public IActionResult MyLeaves()
        {
            var userId = User.FindFirst("UserId")?.Value;
            if (userId == null)
                return Unauthorized();

            int employeeId = int.Parse(userId);

            var leaves = _context.LeaveRequests
                .Where(l => l.EmployeeId == employeeId)
                .ToList();

            return Ok(leaves);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("all")]
        public IActionResult GetAllLeaves()
        {
            return Ok(_context.LeaveRequests.ToList());
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("approve/{id}")]
        public IActionResult ApproveLeave(int id)
        {
            var leave = _context.LeaveRequests.FirstOrDefault(l => l.Id == id);

            if (leave == null)
                return NotFound("Leave request not found");

            leave.Status = "Approved";
            _context.SaveChanges();

            return Ok(new { message = "Leave approved successfully" });
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("reject/{id}")]
        public IActionResult RejectLeave(int id)
        {
            var leave = _context.LeaveRequests.FirstOrDefault(l => l.Id == id);

            if (leave == null)
                return NotFound("Leave request not found");

            leave.Status = "Rejected";
            _context.SaveChanges();

            return Ok(new { message = "Leave rejected successfully" });
        }
    }
}