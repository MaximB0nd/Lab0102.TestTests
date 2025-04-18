namespace EmployeeLib;

public class Employee
{
    public enum Education
    {
        PRIMARY,
        SECONDARY,
        SPECIALIZED_SECONDARY,
        HIGHER
    };

    public enum CurrentPosition
    {
        DIRECTOR,
        MANAGER,
        JUNIOR,
        MIDDLE,
        SENIOR
    };

    public enum Gender
    {
        MALE,
        FEMALE
    };

    string name;
    DateTime birthday;
    Gender gender;
    decimal salary;
    private decimal percentMonthlyPremium;
    Education education;
    CurrentPosition position;


    public bool checkName()
    {
        if (name.Length < 2 || name.Length > 15) return false;

        int digitCount = 0;
        int digitPosition = -1;

        for (int i = 0; i < name.Length; i++)
        {
            if (char.IsDigit(name[i]))
            {
                digitCount++;
                digitPosition = i;
            }
        }

        if (digitCount != 1 || digitPosition == 0)
            return false;

        foreach (char c in name)
        {
            if (char.IsDigit(c))
                continue;

            bool isAllowed = (c >= 'a' && c <= 'z') ||
                             (c >= 'A' && c <= 'Z') ||
                             (c >= 'А' && c <= 'Я') ||
                             (c >= 'а' && c <= 'я') ||
                             c == 'Ё' || c == 'ё' ||
                             c == ' ' || c == '-';

            if (!isAllowed)
                return false;
        }

        return true;
    }

    public int timeUntilRetirement()
    {
        if (birthday > DateTime.Today)
            throw new ArgumentException("Дата рождения некорректна");

        int retirementAge = (gender == Gender.MALE) ? 65 : 60;
        DateTime retDate = birthday.AddYears(retirementAge);

        if (retDate.Date <= DateTime.Today)
            return 0;

        var days = retDate.Date - DateTime.Today;
        return days.Days;
    }

    public decimal monthPayment()
    {
        decimal percertPremium = 0;

        switch (position)
        {
            case CurrentPosition.DIRECTOR:
            case CurrentPosition.SENIOR:
                percertPremium = 0.15m;
                break;
            case CurrentPosition.MIDDLE:
                percertPremium = 0.10m;
                break;
            case CurrentPosition.JUNIOR:
                percertPremium = 0.05m;
                break;
            case CurrentPosition.MANAGER:
                percertPremium = 0.03m;
                break;
        }

        return salary * (1 + percertPremium);
    }

    public Employee(string name, DateTime birthday, Gender gender, decimal salary, CurrentPosition position,
        Education education)
    {

        this.name = name;
        this.birthday = birthday;
        this.gender = gender;
        this.salary = salary;
        this.position = position;
        this.education = education;
        switch (this.position)
        {
            case CurrentPosition.DIRECTOR:
            case CurrentPosition.SENIOR:
                percentMonthlyPremium = 0.15m;
                break;
            case CurrentPosition.MIDDLE:
                percentMonthlyPremium = 0.10m;
                break;
            case CurrentPosition.JUNIOR:
                percentMonthlyPremium = 0.05m;
                break;
            case CurrentPosition.MANAGER:
                percentMonthlyPremium = 0.03m;
                break;
        }
    }
}
    

