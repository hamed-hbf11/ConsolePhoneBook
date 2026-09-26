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
    }
}