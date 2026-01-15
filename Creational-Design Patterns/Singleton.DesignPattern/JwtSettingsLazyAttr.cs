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

    public string Secret { get; }
    public string Issuer { get; }
    public string Audience { get; }
    public bool ValidateIssuer { get; }
    public bool ValidateAudience { get; }
    public bool ValidateLifetime { get; }
    public bool ValidateIssuerSigningKey { get; }
    public int TokenExpiredInMinutes { get; }
    public int RefreshTokenExpiredInMinutes { get; }
}

