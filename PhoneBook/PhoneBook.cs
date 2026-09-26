// ++++++++++++++++++++++++++++++++++++++++++++
// This class is responsible for maintaining 
// the list of contacts in memory and performing operations.
// ++++++++++++++++++++++++++++++++++++++++++++

namespace phoneBookApp
{
    public class PhoneBook
    {
        private List<Contact> _contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
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
    }
}