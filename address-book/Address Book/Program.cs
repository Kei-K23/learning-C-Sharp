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
                        AddNewContact();
                        break;
                    case "3":
                        EditContact();
                        break;
                    case "4":
                        DeleteContact();
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
                    Console.WriteLine("{0}. {1} ({2})", i + 1, contacts[i].Name, contacts[i].Email);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void AddNewContact()
        {
            Console.Clear();
            Console.WriteLine("Add new contact:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            contacts.Add(new Contact(name, email));

            Console.WriteLine("Contact added successfully");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void EditContact()
        {
            Console.Clear();
            Console.WriteLine("Edit contact:");

            Console.Write("Enter contact number to edit: ");
            int contactNumber = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            contacts[contactNumber] = new Contact(name, email);

            Console.WriteLine("Contact edited successfully");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void DeleteContact()
        {
            Console.Clear();
            Console.WriteLine("Delete contact:");

            Console.Write("Enter contact number to delete: ");
            int contactNumber = int.Parse(Console.ReadLine()) - 1;

            contacts.RemoveAt(contactNumber);

            Console.WriteLine("Contact deleted successfully");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    class Contact(string name, string email)
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
    }
}