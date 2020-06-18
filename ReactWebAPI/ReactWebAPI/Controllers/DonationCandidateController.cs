using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWebAPI.Models;

namespace ReactWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationCandidateController : ControllerBase
    {
        private readonly DonationDbContext _context;

        public DonationCandidateController(DonationDbContext context)
        {
            _context = context;
        }

        // GET: api/DonationCandidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonationCandidate>>> GetDonationCandidates()
        {
            return await _context.DonationCandidates.ToListAsync();
        }

        // GET: api/DonationCandidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationCandidate>> GetDonationCandidate(string id)
        {
            var donationCandidate = await _context.DonationCandidates.FindAsync(id);

            if (donationCandidate == null)
            {
                return NotFound();
            }

            return donationCandidate;
        }

        // PUT: api/DonationCandidate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonationCandidate(string id, DonationCandidate donationCandidate)
        {
            donationCandidate.id = id;

            _context.Entry(donationCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationCandidateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DonationCandidate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DonationCandidate>> PostDonationCandidate(DonationCandidate donationCandidate)
        {
            _context.DonationCandidates.Add(donationCandidate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DonationCandidateExists(donationCandidate.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDonationCandidate", new { id = donationCandidate.id }, donationCandidate);
        }

        // DELETE: api/DonationCandidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DonationCandidate>> DeleteDonationCandidate(string id)
        {
            var donationCandidate = await _context.DonationCandidates.FindAsync(id);
            if (donationCandidate == null)
            {
                return NotFound();
            }

            _context.DonationCandidates.Remove(donationCandidate);
            await _context.SaveChangesAsync();

            return donationCandidate;
        }

        private bool DonationCandidateExists(string id)
        {
            return _context.DonationCandidates.Any(e => e.id == id);
        }
    }
}
