using Incub.BLL.Infra.Settings;
using Microsoft.IdentityModel.Tokens;
using Primpasso.Models.DTO;
using Primpasso.Models.Entities.General;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Incub.BLL.Services
{
    public static class LoginService
    {
        public static UserLogedDTO GerarToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthSettings.JWTSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Login)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserLogedDTO
            {
                Nome = user.Name,
                Token = tokenHandler.WriteToken(token)
            };
        }

        public static string Cifrar(string texto)
        {
            string cifra;
            string chaveCifragem = AuthSettings.CifraSecret;
            byte[] bytesLimpos = Encoding.Unicode.GetBytes(texto);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(chaveCifragem, new byte[] { 8, 37, 32, 10, 52, 61, 42, 77 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesLimpos, 0, bytesLimpos.Length);
                        cs.Close();
                    }

                    cifra = Convert.ToBase64String(ms.ToArray());
                }
            }

            return cifra;
        }
    }
}
