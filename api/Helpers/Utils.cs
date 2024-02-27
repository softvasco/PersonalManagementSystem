namespace api.Helpers
{
    public static class Utils
    {
        public static DateTime CalculateNextPaymentDate(DateTime startDate, int payDay)
        {
            if (payDay >= startDate.Day)
            {
                return new DateTime(startDate.Year, startDate.Month, payDay);
            }
            else if (payDay < startDate.Day)
            {
                return new DateTime(startDate.Year, startDate.Month, payDay).AddMonths(1);
            }
            else
            {
                // Handle the case when payDay is equal to the day of startDate
                return new DateTime(startDate.Year, startDate.Month, payDay);
            }
        }
    }
}
