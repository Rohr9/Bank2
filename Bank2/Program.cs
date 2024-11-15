namespace Bank2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "Users.txt");

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            try
            {
                Console.WriteLine("Velkommen til Bank2!");

                Console.Write("Indtast fornavn: ");
                string firstName = Console.ReadLine()?.Trim();
                ValidateName(firstName);

                Console.Write("Indtast efternavn: ");
                string lastName = Console.ReadLine()?.Trim();
                ValidateName(lastName);

                Console.Write("Indtast alder: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                    throw new InvalidAgeException("Alderen skal være et gyldigt heltal.");
                ValidateAge(age);

                Console.Write("Indtast e-mail: ");
                string email = Console.ReadLine()?.Trim();
                ValidateEmail(email);

                string userData = $"{firstName} {lastName}, {age}, {email}";
                SaveUser(filePath, userData);

                Console.WriteLine("\nRegistrerede brugere:");
                PrintUsers(filePath);
            }
            catch (InvalidNameException ex)
            {
                Console.WriteLine($"Navnefejl: {ex.Message}");
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine($"Alderfejl: {ex.Message}");
            }
            catch (InvalidEmailException ex)
            {
                Console.WriteLine($"E-mailfejl: {ex.Message}\nDetaljer: {ex.InnerException?.Message}");
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine($"Filfejl: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Uventet fejl: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Programmet afsluttes korrekt.");
            }
        }

        static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException("Navn må ikke være tomt eller kun indeholde mellemrum.");
        }

        static void ValidateAge(int age)
        {
            if (age < 18 || age > 50)
                throw new InvalidAgeException("Alderen skal være mellem 18 og 50.");
        }

        static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                throw new InvalidEmailException("E-mail er ikke gyldig.", new Exception("E-mail skal indeholde '@' og '.'"));
        }

        static void SaveUser(string filePath, string userData)
        {
            try
            {
                File.AppendAllText(filePath, userData + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Kunne ikke gemme brugerdata til filen.", ex);
            }
        }

        static void PrintUsers(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Ingen registrerede brugere endnu.");
                    return;
                }

                string[] users = File.ReadAllLines(filePath);
                foreach (string user in users)
                {
                    Console.WriteLine(user);
                }
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Kunne ikke læse fra filen.", ex);
            }
        }
    }
}
