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

    public string Secret { get; } = null!;
    public string Issuer { get; } = null!;
    public string Audience { get; } = null!;
    public bool ValidateIssuer { get; }
    public bool ValidateAudience { get; }
    public bool ValidateLifetime { get; }
    public bool ValidateIssuerSigningKey { get; }
    public int TokenExpiredInMinutes { get; }
    public int RefreshTokenExpiredInMinutes { get; }
}

