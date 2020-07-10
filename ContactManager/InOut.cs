using System;
using System.Collections.Generic;
using System.IO;

namespace ContactManager
{
    class InOut
    {
        /// <summary>
        /// Prints all contacts in a table
        /// </summary>
        /// <param name="header"></param>
        public static void PrintAllContacts(string header)
        {
            List<Contact> allContacts = GetAllContacts();

            if (allContacts.Count < 1)
            {
                Console.WriteLine("There are no contacts to be shown.");
                Console.WriteLine("Press ENTER key.");
                return;
            }

            Console.WriteLine(header);

            PrintContactsHeader(out int lenght);

            int count = 1;

            foreach (Contact contact in allContacts)
            {
                Console.WriteLine(contact.ToString(count));

                count++;
            }

            Console.WriteLine(new string('-', lenght));
        }

        /// <summary>
        /// Prints header of a contacts table
        /// </summary>
        /// <param name="lenght"></param>
        private static void PrintContactsHeader(out int lenght)
        {
            string header = string.Format("| {0, 2} | {1, -15} | {2, -15} | {3, 15} | {4, -20} |", "No.", "First Name", "Last Name", "Phone Number", "Address");

            lenght = header.Length;

            Console.WriteLine(new string('-', header.Length));
            Console.WriteLine(header);
            Console.WriteLine(new string('-', header.Length));
        }

        /// <summary>
        /// Reads the data file and gets all contacts
        /// </summary>
        /// <returns>List of contacts</returns>
        public static List<Contact> GetAllContacts()
        {
            string filename = "contacts.csv";

            List<Contact> allContacts = new List<Contact>();

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                if(values.Length == 4)
                {
                    allContacts.Add(new Contact(values[0], values[1], values[2], values[3]));
                }
                else
                {
                    allContacts.Add(new Contact(values[0], values[1], values[2], ""));
                }
            }

            return allContacts;
        }
    }
}
