namespace WPF.validate
{
    public class Validate
    {
        public bool checkStringIsNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }
        public bool checkEmail(string value)
        {
            if (string.IsNullOrEmpty(value) && value.Contains("@gmail.com"))
            {
                return true;
            }
            return false;
        }
    }
}
