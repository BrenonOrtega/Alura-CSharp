namespace FirstImpression.data.objects.valueObjects
{
    public class IncomeCategory
    {

        public decimal YearlyIncome { get; set; }
        public string Category { get; }

        public IncomeCategory(decimal yearlyIncome) {
            YearlyIncome = yearlyIncome;
            Category = GetCategory();
        }

        enum ECategories  
        {
            GREATER_THAN_120K = 5,
            BETWEEN_80K_120K = 4,

            BETWEEN_60K_80K = 3,

            BETWEEN_40K_60K = 2,
            LESS_THAN_40K = 1,
            UNKNOWN = 0
        }

        
        private string GetCategory()
        {   
            var income = this.YearlyIncome;
            var category = ECategories.UNKNOWN;
            if (income > 120_000M)
                category = ECategories.GREATER_THAN_120K;

            if (income > 80_000M && income < 120_000M)
                category = ECategories.BETWEEN_80K_120K;

            if (income > 60_000M && income < 80_000M)
                category = ECategories.BETWEEN_60K_80K;

            if (income > 40_000M && income < 60_000M)
                category = ECategories.BETWEEN_40K_60K;

            if (income < 40_000M)
                category = ECategories.LESS_THAN_40K;

            return category.ToString();
        }
    }
}