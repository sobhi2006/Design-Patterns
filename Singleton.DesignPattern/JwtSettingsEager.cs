using System.Text.Json;
using System.Text.Json.Serialization;

namespace Singleton.DesignPattern;

public sealed class JwtSettingsEager
{
    [JsonConstructor]
    private JwtSettingsEager(string secret,
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

        Console.WriteLine("Create a Singleton object by Eager");
    }

    private static readonly JwtSettingsEager Instance = JsonSerializer.Deserialize<JwtSettingsEager>(File.ReadAllText("appSettings.json"))!;
    private static readonly object _lock = new();

    public static JwtSettingsEager GetConfiguration()
    {
        return Instance;
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

