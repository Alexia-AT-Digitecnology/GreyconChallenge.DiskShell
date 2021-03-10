using System;

namespace GreyconChallenge.DiskShell
{
    public class Program
    {
        public Program()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Greycon Challenge Disk Shell v0.1.");
            Console.WriteLine("==================================");
            Console.WriteLine("Type 'help' for list of commands.");

            bool quit = false;
            
            while (quit == false)
            {
                Console.Write("diskshell>");
                
                string command = Console.ReadLine();

                switch (command.Split(" ")[0].ToLower())
                {
                    case "quit":
                        quit = true;
                        break;
                    case "help":
                        Console.WriteLine(
                            "Valid commands are: help, adddisk, removedisk <index>, setdiskused <index> <size>, setdisktotal <index> <size>, generate, loadfromfile <filename>, savetofile <filename>, preconciliate, conciliate, dumpdata, dumppretty, showdisk <index>, diskcount");
                        break;
                }
            }
            
        }
        
        static void Main(string[] args)
        {
            new Program();
        }
    }
}