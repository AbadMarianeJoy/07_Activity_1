using System;

namespace Person
{
    public class User
    {
        private string user_id;
        protected string user_password;

        public User(string id, string pass)
        {
            this.user_id = id;
            this.user_password = pass;

        }
        public bool VerifyLogin(string id, string pass)
        {
            return this.user_id.Equals(id, StringComparison.OrdinalIgnoreCase) &&
          this.user_password.Equals(pass, StringComparison.OrdinalIgnoreCase);

        }

        public virtual void updatePassword(string newPassword)
        {
            this.user_password = newPassword;
        }
    }

    public class Administrator : User
    {
        private string admin_name;


        public Administrator(string name, string id, string pass) : base(id, pass)
        {
            this.admin_name = name;

        }
        public override void updatePassword(string newPassword)
        {
            base.updatePassword(newPassword);
            Console.WriteLine(" Admin password updated");
        }
        public void updateAdminName(string name)
        {
            this.admin_name += name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User regularUser = new User("yanyan_ey", "Dec1994");

            if (regularUser.VerifyLogin("yanyan_ey", "Dec1994"))
            {
                Console.WriteLine("Login sucessful!");
            }
            else
            {
                Console.WriteLine("Login failed. Incorrect credentials");
            }
            Administrator admin = new Administrator("Admin1", "admin123", "LetitGo");
            admin.updatePassword("newAdminPass");
    }
    }
}
