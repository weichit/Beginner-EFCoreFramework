namespace EFAssessment.Security;

public record JwtOptions
{
    public static string SectionName = "Jwt";
    public string Issuer { get; set; }  = String.Empty;
    public string Secret { get; set; } = String.Empty;  
}
