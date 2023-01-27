using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Application.DTOs.JWTDTOs.Responses
{
    public class RegistrationResponse
    {
        public string? Token { get; set; }
        public bool Success { get; set; }
        public List<String>? Errors { get; set; }
        public string? RefreshToken { get; set; }
        
    }
}
