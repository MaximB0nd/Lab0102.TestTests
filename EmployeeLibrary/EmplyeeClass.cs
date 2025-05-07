using System;

namespace EmployeeLibrary
{
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

        public string name { get; private set; }
        public DateTime birthday { get; private set; }
        public Gender gender { get; private set; }
        public Education education { get; private set; }
        public CurrentPosition position { get; private set; }
        public decimal salary { get; private set; }
        public decimal percentMonthlyPremium { get; private set;}
        public decimal bonus => monthPayment();
        
        public bool checkName()
        {
            if (name.Length < 2) return false;

            int digitCount = 0;
            int digitPosition = -1;

            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    digitCount++;
                    if (digitPosition == -1) digitPosition = i;
                }
            }

            if (digitCount == name.Length || digitPosition == 0)
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
        
        private decimal monthPayment()
        {
            decimal percentPremium = 0;
            switch (position)
            {
                case CurrentPosition.DIRECTOR:
                case CurrentPosition.SENIOR:
                    percentPremium = 0.15m;
                    break;
                case CurrentPosition.MIDDLE:
                    percentPremium = 0.10m;
                    break;
                case CurrentPosition.JUNIOR:
                    percentPremium = 0.05m;
                    break;
                case CurrentPosition.MANAGER:
                    percentPremium = 0.03m;
                    break;
            }
            return salary * percentPremium; 
        }
        
        public decimal FullSalary => salary + bonus;

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
}
