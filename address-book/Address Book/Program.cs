namespace AddressBook
{

    class AddressBook
    {
        static List<Contact> contacts = new List<Contact>();

        static void Main()
        {
            bool exist = false;

            while (!exist)
            {
                Console.Clear();
                Console.WriteLine("*** Address Book ***");
                Console.WriteLine("1) View contacts");
                Console.WriteLine("2) Add new contact");
                Console.WriteLine("3) Edit contact");
                Console.WriteLine("4) Delete contact");
                Console.WriteLine("5) Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        ViewContacts();
                        break;
                    case "2":
                        addNewContact();
                        break;
                    case "3":
                        editContact();
                        break;
                    case "4":
                        deleteContact();
                        break;
                    case "5":
                        Console.WriteLine("Good bye!");
                        exist = true;
                        break;
                }
            }
        }

        static void ViewContacts()
        {
            Console.Clear();
            Console.WriteLine("Contacts:");

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contact found.");
            }
            else
            {
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"{0}. {1} ({2})", i + 1, contacts[i].Name, contacts[i].Email);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void addNewContact()
        {

        }

        static void editContact()
        {

        }

        static void deleteContact()
        {

        }
    }

    class Contact(string name, string email)
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
    }
}