namespace Prueba1.Models.DataModels
{
    public class JwtSettings
    {
        public bool ValidateIssuerSignigKey { get; set; }
        public string IssuerSigningKey { get; set; } = string.Empty;

        public bool ValidateIusser { get; set; }=true;
        public string? ValidIuuser { get; set; }

        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set; }

        public bool RequieredExpirationTime { get; set; }  
        public bool ValidateLifeTime { get; set; } = true;


    }
}
