using System;

class Program
{
    public static void Main()
    {
        // Welcome message and ask how many rolls
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.WriteLine("How many dice rolls would you like to simulate?");

        // Get number of rolls from user
        int numberOfRolls = int.Parse(Console.ReadLine());

        // Create instance of DiceRoller and get results
        DiceRoller diceRoller = new DiceRoller();
        int[] rollResults = diceRoller.SimulateRolls(numberOfRolls);

        // Print histogram
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {numberOfRolls}.");

        // Print histogram for each possible roll value
        for (int i = 2; i <= 12; i++)
        {
            int percentage = (rollResults[i] * 100) / numberOfRolls;
            string stars = new string('*', percentage);
            Console.WriteLine($"{i}: {stars}");
        }

        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }
}

class DiceRoller
{
    private Random random;

    public DiceRoller()
    {
        random = new Random();
    }

    public int[] SimulateRolls(int numberOfRolls)
    {
        // Create array to store counts
        int[] counts = new int[13];

        // Simulate dice rolls
        for (int i = 0; i < numberOfRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;
            counts[sum]++;
        }

        return counts;
    }
}