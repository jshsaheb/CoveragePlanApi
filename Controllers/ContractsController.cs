using CoveragePlanApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoveragePlanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly CoveragePlanDBContext _context;

        public ContractsController(CoveragePlanDBContext context)
        {
            _context = context;
        }

        // GET: api/Contracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contracts>>> GetContracts()
        {
            return await _context.Contracts.ToListAsync();
        }

        // GET: api/Contracts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contracts>> GetContracts(int id)
        {
            var contracts = await _context.Contracts.FindAsync(id);

            if (contracts == null)
            {
                return NotFound();
            }

            return contracts;
        }

        // PUT: api/Contracts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContracts(int id, Contracts contracts)
        {
            if (id != contracts.customerId)
            {
                return BadRequest();
            }

            contracts.coveragePlan = getCoveragePlan(contracts.customerCountry, contracts.saleDate);
            contracts.netPrice = getNetRate(contracts.coveragePlan, contracts.customerGender, contracts.customerDateofBirth, contracts.saleDate);
            if (contracts.coveragePlan == null || contracts.netPrice == 0)
                return UnprocessableEntity();

            _context.Entry(contracts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractsExists(id))
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
        public string getCoveragePlan(string country, DateTime saleDate)
        {

            var coveragePlan = _context.coveragePlans.Where
                (c => c.EligibilityCountry == country && c.EligibilityDateFrom <= saleDate && c.EligibilityDateTo >= saleDate);
            if (coveragePlan == null || coveragePlan.Count() == 0)
            {
                coveragePlan = _context.coveragePlans.Where
                (c => c.EligibilityCountry == "*" && c.EligibilityDateFrom <= saleDate && c.EligibilityDateTo >= saleDate);
            }
            if (coveragePlan == null || coveragePlan.Count() == 0)
                return null;
            else
                return coveragePlan.First().coveragePlan;

        }
        public float getNetRate(string coveragePlan, string customerGender, DateTime customerDateofBirth, DateTime saleDate)
        {


            // Calculate the age.
            var age = saleDate.Year - customerDateofBirth.Year;

            // Go back to the year the person was born in case of a leap year
            if (customerDateofBirth.Date > saleDate.AddYears(-age)) age--;
            string ageFormat = "";
            if (age <= 40) ageFormat = "<=40";
            else ageFormat = ">40";

            var rateChart = _context.rateCharts.Where
    (r => r.CustomerAge == ageFormat && r.coveragePlan == coveragePlan && r.customerGender == customerGender);
            if (rateChart == null || rateChart.Count() == 0)
                return 0;
            else
                return rateChart.First().netPrice;

        }
        // POST: api/Contracts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Contracts>> PostContracts(Contracts contracts)
        {
            contracts.coveragePlan = getCoveragePlan(contracts.customerCountry, contracts.saleDate);
            contracts.netPrice = getNetRate(contracts.coveragePlan, contracts.customerGender, contracts.customerDateofBirth, contracts.saleDate);
            if (contracts.coveragePlan == null || contracts.netPrice == 0)
                return UnprocessableEntity();

            _context.Contracts.Add(contracts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContracts", new { id = contracts.customerId }, contracts);
        }

        // DELETE: api/Contracts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contracts>> DeleteContracts(int id)
        {
            var contracts = await _context.Contracts.FindAsync(id);
            if (contracts == null)
            {
                return NotFound();
            }

            _context.Contracts.Remove(contracts);
            await _context.SaveChangesAsync();

            return contracts;
        }

        private bool ContractsExists(int id)
        {
            return _context.Contracts.Any(e => e.customerId == id);
        }
    }
}
