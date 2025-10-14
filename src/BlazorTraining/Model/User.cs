namespace BlazorTraining.Model
{
    public class User
    {
        public string UserName { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
        public List<string> Roles { get; set; } = new List<string>();

        public bool LoggedIn
        {
            get
            {
                return !String.IsNullOrEmpty(Token);
            }
        }
    }
}
