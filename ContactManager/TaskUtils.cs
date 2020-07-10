using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ContactManager
{
    class TaskUtils
    {
        public static bool CheckIfNumberAlreadyExists(string number)
        {
            List<Contact> contacts = InOut.GetAllContacts();

            int quantity = (from contact in contacts where contact.PhoneNumber.Equals(number) select contact).Count();

            return quantity < 1 ? false : true;
        }

        public static void AddAndSave(string filename, string contactInput)
        {
            try
            {
                string[] values = contactInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                string phoneNumber = values[2];

                bool numberExists = CheckIfNumberAlreadyExists(phoneNumber);

                if (numberExists)
                {
                    Console.WriteLine("A contact with the same number already exists.");
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filename))
                    {
                        if (values.Length == 4)
                            sw.WriteLine($"{values[0]},{values[1]},{values[2]},{values[3]}");
                        else
                            sw.WriteLine($"{values[0]},{values[1]},{values[2]},");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error. Incorrect input.");
            }
        }

        public static void RemoveContact(string number, string filename)
        {
            if (InOut.GetAllContacts().Count != 0)
            {
                if (number.Equals(""))
                {
                    Console.WriteLine("Error. Incorrect input.");
                    return;
                }

                int linesLenghtBefore = InOut.GetAllContacts().Count;
                string[] lines = File.ReadAllLines(filename).Where(line => !line.Contains(number)).ToArray();

                if (linesLenghtBefore > lines.Length)
                {
                    File.WriteAllLines(filename, lines);
                    Console.WriteLine("A contact was successfully deleted.");
                }
                else
                {
                    Console.WriteLine("A contact with typed number does not exists.");
                }

            }
        }

        public static void UpdateContact(int index, string filename)
        {
            if (InOut.GetAllContacts().Count != 0)
            {
                string[] lines = File.ReadAllLines(filename);

                if (index - 1 > lines.Length || index - 1 < 0)
                {
                    Console.WriteLine("Incorrect input. A contact with this typed number does not exists.");
                    return;
                }

                Console.WriteLine("Retype updated contact in format \"First_Name, Last_Name, Phone_Number, Address\"");

                try
                {
                    string updateContact = Console.ReadLine();
                    string[] values = updateContact.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string phoneNumber = values[2];


                    if (lines[index - 1].Contains(phoneNumber))
                    {
                        lines[index - 1] = updateContact;

                        File.WriteAllLines(filename, lines);
                        Console.WriteLine("A contact was successfully updated.");
                    }
                    else
                    {
                        if (CheckIfNumberAlreadyExists(phoneNumber))
                        {
                            Console.WriteLine("A contact with same phone number already exists.");
                            return;
                        }
                        else
                        {
                            lines[index - 1] = updateContact;

                            File.WriteAllLines(filename, lines);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error. Incorrect input.");
                }

            }
        }

        public static void GoBack(ref bool run)
        {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                run = true;
            }
            else
            {
                return;
            }
        }
    }
}
