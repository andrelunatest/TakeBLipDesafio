using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDesafioTakeBlip.Models;
using ApiDesafioTakeBlip.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ApiDesafioTakeBlip.Controllers
{
    [ApiController]
    [Route("controller")]
    public class TakeBlipApiController : ControllerBase
    {       
        [HttpGet("/GetTopOldestRepositories")]
        public ActionResult<String> GetTopOldestRepositories()
        {
            List<GithubRepo> repos = GitHubService.GetRepos();

            var reposJson = JsonConvert.SerializeObject(repos);

            return Ok(reposJson);
            
        }       

    }

        
}
