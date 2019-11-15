﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Laboratorio3.Models;

namespace Laboratorio3.Controllers
{
	//27:25
	[Route("api/JWT/")]
	[ApiController]
	public class JWTController : ControllerBase
	{
		private const string ALGO = "HS256";

		#region
		// GET: api/JWT
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/JWT/5
		[HttpGet("{id}", Name = "Get")]
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/JWT
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT: api/JWT/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
		#endregion
		[Route("token")]
		[HttpPost("{Key}")]
		public async Task<IActionResult> GenerarJWT( [FromBody]JsonModel Json)
		{
			try
			{
				return GenerarToken(Json);
			}
			catch
			{
				return BadRequest();
			}
		}

		public IActionResult GenerarToken(JsonModel Json)
		{
			var LlaveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Json.id));
			var credenciales = new SigningCredentials(LlaveSecreta, ALGO);
			var claims = new[] { new Claim(JwtRegisteredClaimNames.NameId, Json.id) };
			JwtSecurityToken Token = new JwtSecurityToken(
				claims: claims,
				signingCredentials: credenciales );

			return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(Token)});
		}
	}
}
