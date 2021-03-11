using System;
using GreyconChallenge.Base;

namespace GreyconChallenge.DiskShell
{
    /// <summary>
    /// Main program class
    /// </summary>
    public class Program
    {
        private HardDiskContainer _container = new HardDiskContainer();
        
        /// <summary>
        /// Program class constructor
        /// </summary>
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
                            _container.AddDisk(used, total);

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
                            _container.DeleteDisk(value);

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
                            _container.SetDiskUsed(diskindex, size);

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
                            _container.SetDiskTotal(diskindex, size);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Argument is invalid.");
                        }
                        break;
                    case "generate":
                        _container.GenerateRandom();
                        break;
                    case "loadfromfile":
                        _container.LoadFromFile(command.Split(" ")[1]);
                        break;
                    case "savetofile":
                        _container.SaveToFile(command.Split(" ")[1]);
                        break;
                    case "preconciliate":
                        Console.WriteLine("Preconciliation value is {0}", _container.Preconciliate());
                        break;
                    case "conciliate":
                        Console.WriteLine("Conciliation in progress...");
                        _container.Conciliate();
                        Console.WriteLine("Done!!");
                        break;
                    case "dumpdata":
                        Console.Write("(");
                        
                        for (int i = 0; i <= _container.DiskCount() - 1; i++)
                        {
                            Console.Write(_container.GetDisk(i).Used);
                            
                            if (i != _container.DiskCount() - 1)
                            {
                                Console.Write(",");
                            }
                        }

                        Console.Write(")\n");
                        
                        Console.Write("(");
                        
                        for (int i = 0; i <= _container.DiskCount() - 1; i++)
                        {
                            Console.Write(_container.GetDisk(i).Total);
                            
                            if (i != _container.DiskCount() - 1)
                            {
                                Console.Write(",");
                            }
                        }

                        Console.Write(")\n");
                        break;
                    case "dumppretty":
                        for (int i = 0; i <= _container.DiskCount() - 1; i++)
                        {
                            Console.WriteLine("Hard drive {0}: {1} MB total, {2} MB used, {3} MB free.", i + 1, _container.GetDisk(i).Total, _container.GetDisk(i).Used, _container.GetDisk(i).Free);
                        }
                        break;
                    case "showdisk":
                        value = 0;

                        try
                        {
                            value = Convert.ToInt32(command.Split(" ")[1]);
                            Console.WriteLine("Hard drive {0}: {1} MB total, {2} MB used, {3} MB free.", value + 1, _container.GetDisk(value).Total, _container.GetDisk(value).Used, _container.GetDisk(value).Free);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Argument is invalid.");
                        }
                        break;
                    case "diskcount": 
                        Console.WriteLine("Number of disks are {0}", _container.DiskCount());
                        break;
                    case "addrandomdisk":
                        _container.AddDisk(HardDisk.GenerateRandom());
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
            
        }
        
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">Program arguments</param>
        static void Main(string[] args)
        {
            new Program();
        }
    }
}