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
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Edit Contact");
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
                    case "4":
                        DeleteContact(PhoneBook);
                        break;
                    case "5":
                        EditContact(PhoneBook);
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
                bool isAdded = phoneBook.AddContact(contact);

                if (isAdded)
                    Console.WriteLine("\nContact added successfully!");
                else
                    Console.WriteLine("\nThis phone number already exists.");
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
            if (result.Count == 0)
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

        public static void DeleteContact(PhoneBook phoneBook)
        {
            Console.Clear();
            Console.WriteLine(" === Delete Contact === ");

            Console.Write("Enter phone number of the contact to delete: ");
            string phoneNember = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phoneNember))
            {
                Console.WriteLine("\nError: Phone number cannot be empty!");
            }
            else
            {
                bool isDeleted = phoneBook.RemoveContact(phoneNember);
                if (isDeleted)
                {
                    Console.WriteLine("\nContact deleted successfully!");
                }
                else
                {
                    Console.WriteLine("\nContact not found!");
                }
            }

            Console.WriteLine("\nPress Any Key to return to menu...");
            Console.ReadKey();
        }

        public static void EditContact(PhoneBook phoneBook)
        {
            Console.Clear();
            Console.WriteLine(" === Edit Contact === ");

            Console.Write("Enter Exiting phone Number : ");
            string oldPhone = Console.ReadLine();

            var contact = phoneBook.GetByPhoneNumber(oldPhone);
            if (contact == null)
            {
                Console.WriteLine("\nContact not Found! ");
            }
            else
            {
                Console.WriteLine($"Current Details: {contact.FirstName} {contact.LastName} - {contact.PhoneNumber}");

                Console.Write("Enter New Name: ");
                string newFirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newFirstName))
                    newFirstName = contact.FirstName;

                Console.Write("Enter Last Name: ");
                string newLastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newLastName))
                    newLastName = contact.LastName;

                Console.Write("Enter New Phone Number : ");
                string newPhone = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newPhone))
                    newPhone = contact.PhoneNumber;

                bool isUpdated = phoneBook.UpdateContact(oldPhone, newFirstName, newLastName, newPhone);
                if (isUpdated)
                    Console.WriteLine("\nContact updated successfully.");
                else
                    Console.WriteLine("\nError: This phone number already exists.");
            }

            Console.WriteLine("\nPress Any Key to return to menu...");
            Console.ReadKey();
        }
    }
}