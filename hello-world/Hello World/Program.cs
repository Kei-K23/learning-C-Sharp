using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the program to greet you.");
            Console.WriteLine("Enter [Y/y] to continue or [N/n] to exit the program");

            // Get user's choice
            string choice = Console.ReadLine();
            if (choice.ToLower() == "n")
            {
                Console.WriteLine("Exiting the program...");
                return;
            }

            // Get name
            Console.Write("What is your name: ");
            string name = Console.ReadLine();

            // Get age
            Console.Write("How old are you: ");
            string ageInput = Console.ReadLine();

            // Check if name or age are null or empty, if so, exit the program
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(ageInput))
            {
                Console.WriteLine("Name or age cannot be empty. Exiting the program...");
                return;
            }

            // Parse age and handle potential format exceptions
            if (!int.TryParse(ageInput, out int age))
            {
                Console.WriteLine("Invalid age input. Exiting the program...");
                return;
            }

            string greetingMessage = GenerateGreeting(name, age);

            // Output the message
            Console.WriteLine("****************************************");
            Console.WriteLine(greetingMessage);
            Console.WriteLine("****************************************");
        }

        private static string GenerateGreeting(string name, int age)
        {
            var greetings = new List<string>
            {
                $"Hello, {name}!",
                $"Hello, {name}! You are {age} years old.",
                $"Hey {name}! Enjoy your youth.",
                $"{name}, being {age} is an amazing time of life!",
                $"Hey {name}! Your twenties are the best years.",
                $"{name}, at {age}, the world is full of possibilities!",
                $"Hello {name}! You're in the prime of your life.",
                $"{name}, {age} is a great age to achieve your dreams.",
                $"Hello {name}! Age is just a number.",
                $"{name}, {age} years of experience is something to be proud of!",
                $"Good morning, {name}!",
                $"Good afternoon, {name}!",
                $"Good evening, {name}!",
                $"Greetings, {name}! How does it feel to be {age}?",
                $"Hi {name}! At {age}, you're doing great!"
            };

            Random random = new Random();
            int index = random.Next(greetings.Count);

            return greetings[index];
        }
    }
}
