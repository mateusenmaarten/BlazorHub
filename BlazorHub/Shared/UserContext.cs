namespace BlazorHub.Shared
{
    public class UserContext
    {
        public string UserName { get; set; }

        public bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                UserName = "Please enter a name";
                return false;
            }
            return true;
        }
    }
}
