using System;

namespace LegacyApp;

public class AgeServ:IAgeValidation

{
    private DateTime dateOfBirth;
    public bool ageCalculations(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month ||
            (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) 
            age--;
        
        // if (age < 21)
        // {
        //     return false;
        // }

        return age >= 21;
    }
}