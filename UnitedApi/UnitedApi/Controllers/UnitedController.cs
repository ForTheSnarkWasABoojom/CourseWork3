using UnitedApi.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace UnitedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitedController : ControllerBase
    {
        private List<string> connectionStrings;
        public UnitedController()
        {
            connectionStrings = new List<string>();
            var res = JsonConvert.DeserializeObject<Dictionary<string, string>>
                 (System.IO.File.ReadAllText("ConnectionStrings.json"));
            foreach (var f in res)
            {
                connectionStrings.Add(f.Value);
            }
        }

        [HttpGet("MetaChemicalSystems")]

        public async Task<IActionResult> ChemicalSystemsAll()
        {
            List<MetaChemicalSystem> result = new List<MetaChemicalSystem>();
            try
            {
                foreach (var connectionString in connectionStrings)
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        result.AddRange(db.Query<MetaChemicalSystem>("SELECT * FROM MetaChemicalSystems").ToList());
                    }

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }

        [HttpGet("MetaChemicalSystems_FullName")]
        public async Task<IActionResult> ChemicalSystemsFullName(string compound)
        {
            List<MetaChemicalSystem> result = new List<MetaChemicalSystem>();
            try
            {
                foreach (var connectionString in connectionStrings)
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        result.AddRange(db.Query<MetaChemicalSystem>
                            ($"SELECT * FROM MetaChemicalSystems where System = '{compound}'").ToList());
                    }

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }

        [HttpGet("MetaChemicalSystems_Elements")]
        public async Task<IActionResult> ChemicalSystemsByElements(string elements)
        {
            List<MetaChemicalSystem> result = new List<MetaChemicalSystem>();
            try
            {
                var compoundName = ElementParser.ParseElements(elements);
                foreach (var connectionString in connectionStrings)
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        result.AddRange(db.Query<MetaChemicalSystem>($"SELECT * FROM MetaChemicalSystems where System Like " +
                            $"'%{compoundName}%' COLLATE SQL_Latin1_General_CP1_CS_AS").ToList());
                    }

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }

        [HttpGet("MetaProperties")]
        public async Task<IActionResult> PropertiesAll()
        {
            List<MetaProperties> result = new List<MetaProperties>();
            try
            {
                foreach (var connectionString in connectionStrings)
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        result.AddRange(db.Query<MetaProperties>("SELECT * FROM MetaProperties").ToList());
                    }

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }

        [HttpGet("MetaSystemProperties")]
        public async Task<IActionResult> SystemPropertiesAll()
        {
            List<MetaSystemProperties> result = new List<MetaSystemProperties>();
            try
            {
                foreach (var connectionString in connectionStrings)
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        result.AddRange(db.Query<MetaSystemProperties>("SELECT * FROM MetaSystemProperties").ToList());
                    }

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }

        [HttpGet("MetaSystemProperties_BySubstance")]
        public async Task<IActionResult> SystemPropertiesBySubstance(string compound)
        {
            List<MetaSystemProperties> result = new List<MetaSystemProperties>();
            try
            {
                foreach (var connectionString in connectionStrings)
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        result.AddRange(db.Query<MetaSystemProperties>
                            ($"SELECT * FROM MetaSystemProperties where System = '{compound}'").ToList());
                    }

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }

        [HttpGet("MetaSystemProperties_ByProperty")]
        public async Task<IActionResult> SystemPropertiesByProperty(string property)
        {
            List<MetaSystemProperties> result = new List<MetaSystemProperties>();
            try
            {
                foreach (var connectionString in connectionStrings)
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        result.AddRange(db.Query<MetaSystemProperties>
                            ($"SELECT * FROM MetaSystemProperties where Property = '{property}'").ToList());
                    }

                if (result.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }




    }

}
