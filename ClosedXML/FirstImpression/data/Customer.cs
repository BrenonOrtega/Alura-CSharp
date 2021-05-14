using System;
using FirstImpression.data.objects;
using FirstImpression.data.objects.enums;
using FirstImpression.data.objects.valueObjects;

namespace FirstImpression.data
{
    public class Customer 
    {
        public long Id { get; set; }
        public bool IsAttrited { get; set; }
        private Age customerAge;
        public int Age { get => customerAge.ActualAge; }
        public String Gender { get; }
        public int DependentCount { get ; set; }

        public string EducationLevel { get; }

        public string MaritalStatus { get; }
        private IncomeCategory incomeCategory;
        public string Category	{get => incomeCategory.Category; }
    }
}