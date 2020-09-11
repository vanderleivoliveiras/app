using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FCA_Login_WebApi.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace FCA_Login_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly MainContext _context;
        static HttpClient client = new HttpClient();

        public AuthUserController(MainContext context)
        {
            _context = context;
        }

         // GET: api/getUserInformationFromToken
        [Route("getUserInformationFromToken")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetUserInformationFromToken()
        {
            client.BaseAddress = new Uri("http://security-master-internal.digital.fcalatam.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            AuthUser user = new AuthUser()
            {
                username = "F29869D",
                password = "xxxx"
            };


            var jsonContent = JsonConvert.SerializeObject(user); 
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            //contentString.Headers.Add("Session-Token", session_token); 


            HttpResponseMessage response = await client.GetAsync(
                "service/security/auth");

            // return URI of the created resource.
            return response;
        }

        [Route("verifyUserSystemAuth")]
        [HttpGet]
        public async Task<HttpResponseMessage> VerifyUserSystemAuth(string session_token)
        {
            client.BaseAddress = new Uri("http://security-master-internal.digital.fcalatam.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
             client.DefaultRequestHeaders.Add("Authorization", session_token); 


            HttpResponseMessage response = await client.GetAsync(
                "service/security/userAuthority");

            // return URI of the created resource.
            return response;
        }

        [Route("getUserInformationFromToken")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetUserInformationFromToken(string session_token)
        {
            client.BaseAddress = new Uri("http://security-master-internal.digital.fcalatam.com.br/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
             client.DefaultRequestHeaders.Add("Authorization", session_token); 


            HttpResponseMessage response = await client.GetAsync(
                "service/security/user");

            // return URI of the created resource.
            return response;
        }

    }
}
