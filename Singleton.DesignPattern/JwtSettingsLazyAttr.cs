using System.Text.Json;
using System.Text.Json.Serialization;

namespace Singleton.DesignPattern;

public sealed class JwtSettingsLazyAttr
{
    [JsonConstructor]
    private JwtSettingsLazyAttr(string secret,
                                  string issuer,
                                  string audience,
                                  bool validateIssuer,
                                  bool validateAudience,
                                  bool validateLifetime,
                                  bool validateIssuerSigningKey,
                                  int tokenExpiredInMinutes,
                                  int refreshTokenExpiredInMinutes)
    {
        Secret = secret;
        Issuer = issuer;
        Audience = audience;
        ValidateIssuer = validateIssuer;
        ValidateAudience = validateAudience;
        ValidateLifetime = validateLifetime;
        ValidateIssuerSigningKey = validateIssuerSigningKey;
        TokenExpiredInMinutes = tokenExpiredInMinutes;
        RefreshTokenExpiredInMinutes = refreshTokenExpiredInMinutes;

        Console.WriteLine("Create a Singleton object by Lazy Build-In");
    }

    private static readonly Lazy<JwtSettingsLazyAttr> Instance = new(JsonSerializer.Deserialize<JwtSettingsLazyAttr>(File.ReadAllText("appSettings.json"))!);
    private static readonly object _lock = new();

    public static JwtSettingsLazyAttr GetConfiguration()
    {
        return Instance.Value;
    }

    public string Secret { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateLifetime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
    public int TokenExpiredInMinutes { get; set; }
    public int RefreshTokenExpiredInMinutes { get; set; }
}

