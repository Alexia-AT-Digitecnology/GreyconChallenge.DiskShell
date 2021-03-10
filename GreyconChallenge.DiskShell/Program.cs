using System;
using GreyconChallenge.Base;

namespace GreyconChallenge.DiskShell
{
    public class Program
    {
        private HardDiskContainer container = new HardDiskContainer();
        
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
                            "Valid commands are: help, adddisk <used> <total>, removedisk <index>, setdiskused <index> <size>, setdisktotal <index> <size>, generate, loadfromfile <filename>, savetofile <filename>, preconciliate, conciliate, dumpdata, dumppretty, showdisk <index>, diskcount, addrandomdisk");
                        break;
                    case "adddisk":
                        int used = 0;
                        int total = 0;

                        try
                        {
                            used = Convert.ToInt32(command.Split(" ")[1]);
                            total = Convert.ToInt32(command.Split(" ")[2]);
                            container.AddDisk(used, total);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Argument is invalid.");
                        }
                        break;
                    case "removedisk":
                        int value = 0;

                        try
                        {
                            value = Convert.ToInt32(command.Split(" ")[1]);
                            container.DeleteDisk(value);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Argument is invalid.");
                        }
                        break;
                    case "setdiskused":
                        int diskindex = 0;
                        int size = 0;

                        try
                        {
                            diskindex = Convert.ToInt32(command.Split(" ")[1]);
                            size = Convert.ToInt32(command.Split(" ")[2]);
                            container.SetDiskUsed(diskindex, size);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Argument is invalid.");
                        }
                        break;
                    case "setdisktotal":
                        diskindex = 0;
                        size = 0;

                        try
                        {
                            diskindex = Convert.ToInt32(command.Split(" ")[1]);
                            size = Convert.ToInt32(command.Split(" ")[2]);
                            container.SetDiskTotal(diskindex, size);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Argument is invalid.");
                        }
                        break;
                    case "generate":
                        container.GenerateRandom();
                        break;
                    case "loadfromfile":
                        container.LoadFromFile(command.Split(" ")[1]);
                        break;
                    case "savetofile":
                        container.SaveToFile(command.Split(" ")[1]);
                        break;
                    case "preconciliate":
                        Console.WriteLine("Preconciliation value is {0}", container.Preconciliate());
                        break;
                    case "conciliate":
                        Console.WriteLine("Conciliation in progress...");
                        container.Conciliate();
                        Console.WriteLine("Done!!");
                        break;
                    case "dumpdata":
                        Console.Write("(");
                        
                        for (int i = 0; i <= container.DiskCount() - 1; i++)
                        {
                            Console.Write(container.GetDisk(i).Used);
                            
                            if (i != container.DiskCount() - 1)
                            {
                                Console.Write(",");
                            }
                        }

                        Console.Write(")\n");
                        
                        Console.Write("(");
                        
                        for (int i = 0; i <= container.DiskCount() - 1; i++)
                        {
                            Console.Write(container.GetDisk(i).Total);
                            
                            if (i != container.DiskCount() - 1)
                            {
                                Console.Write(",");
                            }
                        }

                        Console.Write(")\n");
                        break;
                    case "dumppretty":
                        for (int i = 0; i <= container.DiskCount() - 1; i++)
                        {
                            Console.WriteLine("Hard drive {0}: {1} MB total, {2} MB used, {3} MB free.", i + 1, container.GetDisk(i).Total, container.GetDisk(i).Used, container.GetDisk(i).Free);
                        }
                        break;
                    case "showdisk":
                        value = 0;

                        try
                        {
                            value = Convert.ToInt32(command.Split(" ")[1]);
                            Console.WriteLine("Hard drive {0}: {1} MB total, {2} MB used, {3} MB free.", value + 1, container.GetDisk(value).Total, container.GetDisk(value).Used, container.GetDisk(value).Free);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Argument is invalid.");
                        }
                        break;
                    case "diskcount": 
                        Console.WriteLine("Number of disks are {0}", container.DiskCount());
                        break;
                    case "addrandomdisk":
                        container.AddDisk(HardDisk.GenerateRandom());
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
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