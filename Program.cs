using EFCodeFirst;

public class Program
{
    public static void Main(string[] args)
    {
        //lisätty edustaväri
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Record Management");
        Console.ForegroundColor = ConsoleColor.Green;

        while (true)
        {
            Console.WriteLine(" Commands:");
            Console.WriteLine(" [ 1 ] -> Add Record\n [ 2 ] -> Remove Record\n [ 3 ] -> Search Record" +
                "\n [ 4 ] -> List All\n [ 0 ] -> Quit");
            string question = Console.ReadLine();

            if (question == "1")
            {
                Aanite AddRecord = new Aanite();
                AddRecord.addRecord();
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();

            }
            else if (question == "2")
            {
                Aanite RemoveRecord = new Aanite();
                RemoveRecord.removeRecord();
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
            }
            else if (question == "3")
            {
                Aanite SearchRecord = new Aanite();
                SearchRecord.searchRecord();
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();

            }
            else if (question == "4")
            {
                Aanite ListAll = new Aanite();
                ListAll.printAllRecord();
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
            }
            else if (question == "0")
            {
                Console.WriteLine("You go exit. Goodbye. See you later!");
                Console.WriteLine("Press enter to quit.");
                break;
            }

        }
    }

}










