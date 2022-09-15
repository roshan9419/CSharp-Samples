using System;
using System.Linq;
using System.Text;

namespace PlacementManagement.Web.Utils
{
    public static class PasswordGenerator
    {
        private readonly static Random _rand = new Random();
        public static string GenerateRandom(int length = 10)
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string number = "0123456789";
            const string special = "@#$";

            var password = new StringBuilder();

            // Adding minimum needs
            password.Append(lower[_rand.Next(lower.Length)]);
            password.Append(upper[_rand.Next(upper.Length)]);
            password.Append(number[_rand.Next(number.Length)]);
            password.Append(special[_rand.Next(special.Length)]);

            length -= 4;

            while (length > 0)
            {
                length--;

                switch (_rand.Next(4))
                {
                    case 0:
                        password.Append(lower[_rand.Next(lower.Length)]);
                        break;
                    case 1:
                        password.Append(upper[_rand.Next(upper.Length)]);
                        break;
                    case 2:
                        password.Append(number[_rand.Next(number.Length)]);
                        break;
                    case 3:
                        password.Append(special[_rand.Next(special.Length)]);
                        break;
                }
            }

            // Shuffle
            return new string(password.ToString().ToCharArray()
                .OrderBy(s => (_rand.Next(2) % 2) == 0).ToArray());
        }
    }
}