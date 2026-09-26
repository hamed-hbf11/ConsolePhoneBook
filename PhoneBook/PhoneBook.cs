// ++++++++++++++++++++++++++++++++++++++++++++
// This class is responsible for maintaining 
// the list of contacts in memory and performing operations.
// ++++++++++++++++++++++++++++++++++++++++++++

namespace phoneBookApp
{
    public class PhoneBook
    {
        private List<Contact> _contacts = new List<Contact>();

        public bool IsPhoneNumberExists(string phoneNumber)
        {
            return _contacts.Any(c => c.PhoneNumber == phoneNumber);
        }
        public bool AddContact(Contact contact)
        {
            if (IsPhoneNumberExists(contact.PhoneNumber))
                return false;

            _contacts.Add(contact);
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

            return true;
        }
    }
}