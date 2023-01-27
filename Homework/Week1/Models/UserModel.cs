namespace Week1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }

        protected static int userCount; 

        public UserModel()
        {
            Id = userCount++;
        }
    }
}
