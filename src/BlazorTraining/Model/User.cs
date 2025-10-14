namespace BlazorTraining.Model
{
    public class User
    {
        public string UserName { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;

        public bool LoggedIn
        {
            get
            {
                return !String.IsNullOrEmpty(Token);
            }
        }
    }
}
