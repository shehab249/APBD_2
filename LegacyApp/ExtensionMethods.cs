using System;

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
    
    public static int CalculateAge(this DateTime birthDate, DateTime referenceDate)
    {
        int age = referenceDate.Year - birthDate.Year;

        if (referenceDate.Month < birthDate.Month || 
            (referenceDate.Month == birthDate.Month && referenceDate.Day < birthDate.Day))
        {
            age--;
        }

        return age;
    }

    public static bool IsAdult(this DateTime birthDate, DateTime referenceDate, int minAge = 21)
    {
        return birthDate.CalculateAge(referenceDate) >= minAge;
    }
}