namespace LegacyApp;

public static class ExtensionMethods
{
    public static bool IsValidEmail(this string email)
    { 
        if (!email.Contains("@") || !email.Contains("."))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidName(this string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            return false;
        }

        return true;
    }
}