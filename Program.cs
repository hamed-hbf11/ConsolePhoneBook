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
                Console.WriteLine("2. Show Contacts");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("0. Exit");
                Console.Write("select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddContact(PhoneBook);
                        break;
                    case "2":
                        ShowContacts(PhoneBook);
                        break;
                    case "3":
                        SearchContact(PhoneBook);
                        break;
                    case "0":
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
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

        public static void ShowContacts(PhoneBook phoneBook)
        {
            Console.Clear();
            Console.WriteLine(" === Contacts List === ");

            var contacts = phoneBook.GetAllContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                int index = 0;
                foreach (var contact in contacts)
                {
                    Console.WriteLine($" {++index}. Name: {contact.FirstName} {contact.LastName}, Phone: {contact.PhoneNumber}");
                }
            }

            Console.WriteLine("\nPress Any Key to return to menu...");
            Console.ReadKey();
        }

        public static void SearchContact(PhoneBook phoneBook)
        {
            Console.Clear();
            Console.WriteLine(" === Search Contact === ");

            Console.Write("Enter Name or Phone Nember to search: ");
            var query = Console.ReadLine();
            
            var result = phoneBook.SearchContact(query);

            Console.WriteLine(" === Search Contact ===");
            if(result.Count == 0)
            {
                Console.WriteLine("No Contacts Found!");
            }
            else
            {
                foreach (var contact in result)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}, Phone: {contact.PhoneNumber}");
                }
            }

            Console.WriteLine("\nPress Any Key to return to menu...");
            Console.ReadKey();
        }
    }
}