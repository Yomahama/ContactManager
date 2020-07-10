using System;
using System.Collections.Generic;

namespace ContactManager
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "contacts.csv";
            bool run = true;

            while (run)
            {
                Console.WriteLine("Choose a function by number: ");
                Console.WriteLine("1 - Add contact");
                Console.WriteLine("2 - Delete contact");
                Console.WriteLine("3 - Update contact information");
                Console.WriteLine("4 - View all contacts");

                bool correctInput = int.TryParse(Console.ReadLine(), out int choiceInput);

                if (!correctInput || !(choiceInput < 5 && choiceInput > 0))
                {
                    Console.WriteLine("Error. Incorrect input. Please exit application and try again.");
                    break;
                }

                run = false;

                switch (choiceInput)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("ADD CONTACT");
                        Console.WriteLine("A contact format has to be: \"First_Name, Last_Name, Phone_Number, Address\". Address field is optional.");

                        string contactInput = Console.ReadLine();
                        TaskUtils.AddAndSave(filename, contactInput);

                        BackProcess(ref run);

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("REMOVE CONTACT");
                        InOut.PrintAllContacts("Type a phone number of a contact to be removed.");

                        string deleteByNumber = Console.ReadLine();
                        TaskUtils.RemoveContact(deleteByNumber, filename);

                        BackProcess(ref run);

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("UPDATE CONTACT");
                        InOut.PrintAllContacts("Type a number of a contact to be updated.");

                        bool contactIndex = int.TryParse(Console.ReadLine(), out int index);

                        if (!contactIndex)
                        {
                            Console.WriteLine("Error. Incorrect input.");
                            BackProcess(ref run);
                            break;
                        }

                        TaskUtils.UpdateContact(index, filename);

                        BackProcess(ref run);

                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("VIEW ALL CONTACTS");
                        InOut.PrintAllContacts("");

                        BackProcess(ref run);
                        break;
                }
            }
            Console.ReadKey();
        }

        public static void BackProcess(ref bool run)
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER key to go back.");
            TaskUtils.GoBack(ref run);
        }
    }
}
