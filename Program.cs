namespace phoneBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var PhoneBook = new PhoneBook();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(" === Phone Book System === ");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("0. Exit");
                Console.Write("select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddContact(PhoneBook);
                        break;
                    case "0":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void AddContact(PhoneBook phoneBook)
        {
            Console.Clear();
            Console.WriteLine(" === Add New Contact === ");

            Console.Write("Enter name: ");
            var first_name = Console.ReadLine();

            Console.Write("Enter last name: ");
            var last_name = Console.ReadLine();

            Console.Write("Enter phone number: ");
            var phone_number = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(first_name) || string.IsNullOrWhiteSpace(last_name) || string.IsNullOrWhiteSpace(phone_number))
            {

                Console.WriteLine("\nError: Name and Phone Number cannot be empty!");
            }
            else
            {
                var contact = new Contact(first_name, last_name, phone_number);
                phoneBook.AddContact(contact);
                Console.WriteLine("\nContact added successfully!");
            }

            Console.WriteLine("\nPress Any Key to return to menu...");
            Console.ReadKey();
        }
    }
}