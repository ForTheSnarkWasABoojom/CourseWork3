using ApiForBanfGap.Models;
using Dapper;
using MasterApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace MasterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private List<string> baseNames;
        public MasterController()
        {
            baseNames = new List<string>();
            var res = JsonConvert.DeserializeObject<Dictionary<string, string>>
                (System.IO.File.ReadAllText("ApiAddresses.json"));
            foreach (var f in res)
            {
                baseNames.Add(f.Value);
            }
        }

        [HttpGet("MetaChemicalSystems")]

        public async Task<IActionResult> ChemicalSystemsAll()
        {
            List<MetaChemicalSystem> result = new List<MetaChemicalSystem>();
            try
            {
                foreach (var f in baseNames)
                {
                    var client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(
                        f + "/MetaChemicalSystems");

                    HttpContent responseContent = response.Content;

                    using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                    {
                        var x = await reader.ReadToEndAsync();

                        var y = JsonConvert.DeserializeObject<List<MetaChemicalSystem>>(x);
                        result.AddRange(y);
                    }
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
                foreach (var f in baseNames)
                {
                    var client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(
                        f + "/MetaChemicalSystems_FullName?compound="+ compound);

                    HttpContent responseContent = response.Content;

                    using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                    {
                        var x = await reader.ReadToEndAsync();

                        var y = JsonConvert.DeserializeObject<List<MetaChemicalSystem>>(x);
                        result.AddRange(y);
                    }
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

                foreach (var f in baseNames)
                {
                    var client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(
                        f + "/MetaChemicalSystems_Elements?elements=" + compoundName);

                    HttpContent responseContent = response.Content;

                    using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                    {
                        var x = await reader.ReadToEndAsync();

                        var y = JsonConvert.DeserializeObject<List<MetaChemicalSystem>>(x);
                        result.AddRange(y);
                    }
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
                foreach (var f in baseNames)
                {
                    var client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(
                        f + "/MetaProperties");

                    HttpContent responseContent = response.Content;

                    using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                    {
                        var x = await reader.ReadToEndAsync();

                        var y = JsonConvert.DeserializeObject<List<MetaProperties>>(x);
                        result.AddRange(y);
                    }
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
                foreach (var f in baseNames)
                {
                    var client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(
                        f + "/MetaSystemProperties");

                    HttpContent responseContent = response.Content;

                    using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                    {
                        var x = await reader.ReadToEndAsync();

                        var y = JsonConvert.DeserializeObject<List<MetaSystemProperties>>(x);
                        result.AddRange(y);
                    }
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
                foreach (var f in baseNames)
                {
                    var client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(
                        f + "/MetaSystemProperties_BySubstance?compound=" + compound);

                    HttpContent responseContent = response.Content;

                    using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                    {
                        var x = await reader.ReadToEndAsync();

                        var y = JsonConvert.DeserializeObject<List<MetaSystemProperties>>(x);
                        result.AddRange(y);
                    }
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
                foreach (var f in baseNames)
                {
                    var client = new HttpClient();

                    HttpResponseMessage response = await client.GetAsync(
                        f + "/MetaSystemProperties_ByProperty?property=" + property);

                    HttpContent responseContent = response.Content;

                    using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                    {
                        var x = await reader.ReadToEndAsync();

                        var y = JsonConvert.DeserializeObject<List<MetaSystemProperties>>(x);
                        result.AddRange(y);
                    }
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
