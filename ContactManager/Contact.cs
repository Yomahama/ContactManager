namespace ContactManager
{
    class Contact
    {
        public Contact(string firstName, string lastName, string phoneNumber, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string ToString(int count)
        {
            return string.Format("| {0, 2}. | {1, -15} | {2, -15} | {3, 15} | {4, -20} |", count, FirstName, LastName, PhoneNumber, Address);
        }
    }
}
