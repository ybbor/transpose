using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace transpose
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length == 1)
            {
                System.Console.WriteLine("Please enter file name and output file");
                System.Console.WriteLine("Usage: transpose <file.csv> <output.csv> <BlockSize>");
                System.Console.WriteLine("BlockSize: Somewhat useful if you want to break up your list in to blocks of <BlockSize> number of items.  I use this if I need to export a big list of ID's from mySql, and then use those in an 'in' query but don't want to do them all at the same time. ");
                
                return;
            }

            

            int counter = 0;
            string line;

            bool bBlockGroups = false;
            int iBlockSize = 0;
            if (args.Length == 3)
            {
                bBlockGroups = true;
                iBlockSize = Convert.ToInt32(args[2]);                    
            }

            if (!File.Exists(args[0]))
            {
                System.Console.WriteLine("Input file " + args[0] + " not found!!");
                return;
            }

            if (!File.Exists(args[1]))
            {
                var fNewFile = File.Create(args[1]);
                fNewFile.Close();
            }


            

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(args[0]);
            using (StreamWriter sw = File.AppendText(args[1]))
            {
                while ((line = file.ReadLine()) != null)
                {
                    //System.Console.WriteLine(line);



                    if (counter > 0)
                        sw.Write("," + line);
                    else
                        sw.Write(line);

                    if (bBlockGroups == true && counter % iBlockSize == 1)
                    {
                        sw.WriteLine("\n\r\n\r\n\r\n\r\n\r");
                    }

                    counter++;
                }
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);

            return;


        }
    }
}
