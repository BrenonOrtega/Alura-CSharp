using System;

namespace FirstImpression.data.objects.valueObjects
{
    public class Age
    {

        public Age(int actualAge)
        {
            this.ActualAge = actualAge;
            this.BirthYear = GetBirthYear(actualAge);
        }

        private DateTime GetBirthYear(int age)
        {   var birthYear = DateTime.Today;
            birthYear.AddYears( -age );
            return birthYear; 
        }

        private int actualAge;
        public int ActualAge
        {   get => actualAge;
            set => actualAge = value;
        }

        private DateTime birthYear;
        public DateTime BirthYear
        {   get => birthYear;
            set => birthYear = value;
        }
        
    }
}