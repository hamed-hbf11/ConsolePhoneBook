// ++++++++++++++++++++++++++++++++++++++++++++
// This class is responsible for maintaining 
// the list of contacts in memory and performing operations.
// ++++++++++++++++++++++++++++++++++++++++++++

using System.Text.Json;
namespace phoneBookApp
{
    public class PhoneBook
    {
        private List<Contact> _contacts = new List<Contact>();
        private static readonly string ProjectRootPath =
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));
        private static readonly string FilePath = 
        Path.Combine(ProjectRootPath, "contacts.json");

        public PhoneBook()
        {
            LoadFromFile();
        }

        public bool IsPhoneNumberExists(string phoneNumber)
        {
            return _contacts.Any(c => c.PhoneNumber == phoneNumber);
        }
        public bool AddContact(Contact contact)
        {
            if (IsPhoneNumberExists(contact.PhoneNumber))
                return false;

            _contacts.Add(contact);
            SaveToFile();
            return true;
        }

        public IReadOnlyList<Contact> GetAllContacts()
        {
            return _contacts.AsReadOnly();
        }

        public List<Contact> SearchContact(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<Contact>();

            return _contacts
            .Where(c => c.FirstName.Contains(query) ||
            c.LastName.Contains(query) || c.PhoneNumber.Contains(query)).ToList();
        }

        public bool RemoveContact(string phoneNumber)
        {
            var contact = _contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
            if (contact == null)
                return false;

            _contacts.Remove(contact);
            SaveToFile();
            return true;
        }

        public Contact? GetByPhoneNumber(string phoneNumber)
        {
            return _contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        }
        public bool UpdateContact(string oldPhoneNumber, string newFirstName, string newLastName, string newPhoneNumber)
        {
            var contact = GetByPhoneNumber(oldPhoneNumber);

            if (contact == null)
                return false;

            if (oldPhoneNumber != newPhoneNumber && IsPhoneNumberExists(newPhoneNumber))
                return false;

            contact.FirstName = newFirstName;
            contact.LastName = newLastName;
            contact.PhoneNumber = newPhoneNumber;
            SaveToFile();

            return true;
        }

        private void SaveToFile()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(_contacts, options);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving contacts to file: {ex.Message}");
            }
        }

        private void LoadFromFile()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string jsonString = File.ReadAllText(FilePath);
                    var loadedContacts = JsonSerializer.Deserialize<List<Contact>>(jsonString);
                    if (loadedContacts != null)
                    {
                        _contacts = loadedContacts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading contacts from file: {ex.Message}");
                _contacts = new List<Contact>();
            }
        }
    }
}