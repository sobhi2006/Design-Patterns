using System.Text.Json;
using System.Text.Json.Serialization;

namespace Singleton.DesignPattern;

public sealed class JwtSettingsLazyManual
{
    [JsonConstructor]
    private JwtSettingsLazyManual(string secret,
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

        Console.WriteLine("Create a Singleton object by lazy manual");
    }

    private static JwtSettingsLazyManual? Instance = null;
    private static readonly object _lock = new();

    public static JwtSettingsLazyManual GetConfiguration()
    {
        if (Instance == null)
        {
            lock (_lock)
            {
                Instance ??= JsonSerializer.Deserialize<JwtSettingsLazyManual>(File.ReadAllText("appSettings.json"))!;
            }
            return Instance;
        }
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

