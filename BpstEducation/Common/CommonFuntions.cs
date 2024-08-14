namespace BpstEducation.Common
{
    public static class CommonFuntions
    {
        public static string GetDefaultPassword(DateTime dob)
        {
            return "Bpst@" + dob.Month.ToString() + dob.Year.ToString();  
        }
    }
}
