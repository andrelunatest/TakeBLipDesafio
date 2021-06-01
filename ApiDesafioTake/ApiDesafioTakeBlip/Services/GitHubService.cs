using ApiDesafioTakeBlip.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiDesafioTakeBlip.Services
{
    public abstract class GitHubService
    {      
        private const string GITHUB_API_URL = "http://api.github.com/orgs/";

        public async static Task<List<GithubRepo>> GithubApiRequest()
        {
            List<GithubRepo> gitHubRepoList = new List<GithubRepo>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
               
                using (var response = await httpClient.GetAsync(GITHUB_API_URL + "takenet/repos?per_page=100"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    gitHubRepoList = JsonConvert.DeserializeObject<List<GithubRepo>>(apiResponse);
                }
            }

            return gitHubRepoList;
        }

        public static List<GithubRepo> GetTopFiveMostOldRepos(List<GithubRepo> repos)
        {
            return repos.OrderBy(x => x.Created_At).Take(5).ToList();
        }

        public static List<GithubRepo> GetRepos()
        {            
            List<GithubRepo> gitHubRepoList = GithubApiRequest().Result;                                 

            var fiveOldestRepos = GetTopFiveMostOldRepos(gitHubRepoList);

            return fiveOldestRepos;
        }

       
    }
}
