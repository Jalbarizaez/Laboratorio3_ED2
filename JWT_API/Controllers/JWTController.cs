using System;
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
		//Llave Recomendada "LlaveSuperSecretaDificilDeAdivinar"
		//La llave debe ser mayor a 256 bits

		[HttpPost("{Key}")]
		public IActionResult GenerarToken(string Key, [FromBody]JsonModel Json)
		{
			try
			{
				if (Key.Length < 31)
				{
					return BadRequest("Llave muy pequeña para cifrar, la llave debe ser mayor a 256 bits");
				}
				else
				{
					var LlaveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
					var credenciales = new SigningCredentials(LlaveSecreta, ALGO);
					var fechaExp = DateTime.UtcNow.AddHours(24); //El token se vence en 24 horas
					var iat = DateTime.UtcNow;
					var claims = new[] {
					new Claim("name", Json.name),
					new Claim("iat", EpochTime.GetIntDate(iat).ToString()),
					new Claim("sub", "Laboratorio-3-ED2")};

					JwtSecurityToken Token = new JwtSecurityToken(
						claims: claims,
						expires: fechaExp,
						signingCredentials: credenciales);

					return Ok(new
					{
						Token = new JwtSecurityTokenHandler().WriteToken(Token),
						fechaExp = fechaExp,
					});
				}
			}
			catch
			{
				return BadRequest("El formato del Json debe ser { \"nombre\" : \"LaboratorioED2}\"");
			}
		}
	}
}
