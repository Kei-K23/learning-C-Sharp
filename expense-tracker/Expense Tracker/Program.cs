namespace ExpenseTracker
{
    class Expense
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }

    class ExpenseTracker
    {
        static List<Expense> expenses = new List<Expense>();

        static void Main()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("===== Expense Tracker =====");
                Console.WriteLine("1) Add Expense");
                Console.WriteLine("2) Categorize Expense");
                Console.WriteLine("3) Monthly Budget");
                Console.WriteLine("4) View Report");
                Console.WriteLine("5) Exit");
                Console.WriteLine("===========================");

                Console.WriteLine();
                Console.Write("Enter your choice(1-5): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addExpense();
                        break;
                    case 2:
                        categorizeExpense();
                        break;
                    case 3:
                        monthlyBudget();
                        break;
                    case 4:
                        viewReport();
                        break;
                    case 5:
                        Console.WriteLine("Bye bye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid number! Please choose correct number again");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void addExpense()
        {
            Console.Clear();
            Console.WriteLine("=== Add new Expense ===");

            Console.Write("Enter the amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the category: ");
            string category = Console.ReadLine();

            Console.Write("Enter the description: ");
            string description = Console.ReadLine();

            DateTime date = DateTime.Now;

            expenses.Add(new Expense
            {
                Amount = amount,
                Category = category,
                Description = description,
                Date = date
            });

            Console.WriteLine("New expense created successfully");
        }

        static void categorizeExpense()
        {
            Console.Clear();
            Console.WriteLine("=== Categorize Expense ===");

            checkExpenseListEmpty();

            showExpenseList();

            Console.WriteLine();
            Console.Write("Enter the expense number to categorize: ");
            int expenseNumber = int.Parse(Console.ReadLine()) - 1;

            if (expenseNumber < 0 || expenseNumber > expenses.Count)
            {
                Console.WriteLine("Invalid expense number");
            }

            Expense expense = expenses[expenseNumber];

            Console.Write("Enter the category: ");
            string category = Console.ReadLine();

            expense.Category = category;

            Console.WriteLine();
            Console.WriteLine("Expense categorized successfully");
        }

        static void monthlyBudget()
        {
            Console.Clear();
            Console.WriteLine("=== Monthly budget ===");

            checkExpenseListEmpty();

            showExpenseList();
            Console.WriteLine();

            Console.Write("Enter the month: ");
            int month = int.Parse(Console.ReadLine());

            if (month < 1 || month > 12)
            {
                Console.WriteLine("Invalid month");
                return;
            }

            Console.Write("Enter the year: ");
            int year = int.Parse(Console.ReadLine());

            decimal totalExpense = expenses
            .Where(expense => expense.Date.Month == month && expense.Date.Year == year)
            .Sum(expense => expense.Amount);

            Console.WriteLine();
            Console.WriteLine($"Your total balance: {totalExpense}");
        }

        static void viewReport()
        {
            Console.Clear();
            Console.WriteLine("=== View Report ===");

            checkExpenseListEmpty();

            showExpenseList();

            Console.WriteLine();
            Console.Write("Enter the category for reporting: ");
            string category = Console.ReadLine();

            List<Expense> categorizedExpenses = expenses.Where(expense => expense.Category == category).ToList();

            if (categorizedExpenses.Count < 0)
            {
                Console.WriteLine($"No expense found with the name '{category}' category");
                return;
            }
            Console.WriteLine();
            Console.WriteLine($"Expense lists for {category}: ");
            foreach (var item in categorizedExpenses)
            {
                Console.WriteLine($"Amount: {item.Amount}, Description: {item.Description}");
            }

        }

        static void checkExpenseListEmpty()
        {
            if (expenses.Count < 0)
            {
                Console.WriteLine("No expense found");
                return;
            }
        }

        static void showExpenseList()
        {
            Console.WriteLine("Expense lists: ");
            for (int i = 0; i < expenses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Amount: {expenses[i].Amount}, Description: {expenses[i].Description}");
            }
        }
    }
}