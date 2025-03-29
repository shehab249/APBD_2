namespace LegacyApp;

public static class StringExtensionMethod
{
    public static bool IsValidEmail(this string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
}