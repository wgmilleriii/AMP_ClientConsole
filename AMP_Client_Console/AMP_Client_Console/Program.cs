using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;
using Amplifier_Helpers;

namespace AMP_Client_Console
{
    class Program
    {
        private static AMP_Client c = new AMP_Client();
        private static void showError(string s)
        {
            Console.WriteLine("                   >> " + s);
        }

        private static void showHeader()
        {
            Console.Clear();
            AMP_ConsoleHelper.ShowMessageBox("AMPLIFIER: NEW CLIENT", 60, '=');
            Console.WriteLine("Please enter information as prompted.  ");
            Console.WriteLine("Fields with * are required.");
            Console.WriteLine();

        }

        private static void readFirstName()
        {
            string r = null;
            while ( r == null)
            {
                Console.Write("     * First name:      ");
                try
                {
                    r = Console.ReadLine();
                    c.firstName = r;
                }
                catch (Exception e)
                {
                    r = null;
                    showError(e.Message);
                }

            }

            
        }
        private static void readLastName()
        {
            string r  = null;
            while (r == null)
            {
                Console.Write("       Last name:       ");
                try
                {
                    r = Console.ReadLine();
                    c.lastName = r;
                }
                catch (Exception e)
                {
                    r = null;
                    showError(e.Message);
                }
            }
            
        }
        private static void readEmail()
        {
            string r = null;
            
            while (r == null)
            {
                Console.Write("     * Email address:   ");
                try
                {
                    r = Console.ReadLine();
                    c.email = r;
                }
                catch (Exception e)
                {
                    showError(e.Message);
                    r = null;
                }
                
            }


        }
        private static void readPassword()
        {
            string r = null;

            while (r== null)
            {
                Console.Write("     * Password  :      ");
                try
                {
                    r = Console.ReadLine();
                    c.password = r;
                }
                catch (Exception e)
                {
                    showError(e.Message);
                    r = null;
                }
            }

            c.password = r;
        }

        // return true if the user accepts the values that are displayed on screen
        private static bool readReview()
        {
            bool result=false;
            Console.WriteLine();
            AMP_ConsoleHelper.ShowMessageBox("Please review", 40);
            
            Console.WriteLine("  (1)         Email: " + c.email);
            Console.WriteLine("  (2)    First Name: " + c.firstName);
            Console.WriteLine("  (3)     Last Name: " + c.lastName);
            Console.WriteLine("  (4)      Password: " + c.password);
            Console.WriteLine();
            Console.WriteLine("  Enter any line number to edit that line, ");
            Console.WriteLine("  or any other key to save this data.");
            Console.WriteLine();
            ConsoleKeyInfo i = Console.ReadKey(true);

            switch (i.KeyChar.ToString())
            {
                case "1":
                    readEmail();
                    break;
                case "2" :
                    readFirstName();
                    break;
                case "3" :
                    readLastName();
                    break;
                case "4":
                    readPassword();
                    break;
                default :
                    result = true;
                    break;
            }
            return result;

        }
        private static void saveRecord()
        {
            bool tryagain = true;
            while (tryagain)
            {
                try
                {
                    using (var db = Mongo.Create("mongodb://amplifier_client:4mpcl13nt$%^@ds029277.mongolab.com:29277/amplifier_client?strict=false"))
                    {
                        //get LINQ access to your Posts
                        //Mongo created the database and collection on the fly!
                        var posts = db.GetCollection<AMP_Client>();

                        //insert into collection
                        posts.Save(c);
                        Console.WriteLine("Record saved.        record id " + c._id );
                        tryagain = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unsuccessful save : " + e.Message);
                    Console.WriteLine("Try again? (Y/N)");
                    ConsoleKeyInfo k = Console.ReadKey(true);
                    if (k.KeyChar.ToString().ToUpper() == "N")
                    {
                        tryagain = false;
                    }
                }
            }

        }

        private static bool getAnotherRecordPrompt()
        {
            bool result = false;

            Console.WriteLine("Create another customer? (Y/N)");
            ConsoleKeyInfo k = Console.ReadKey(true);
            if (k.KeyChar.ToString().ToUpper() == "Y")
            {
                result = true;
            }
            return result;
        }
        public static void Main()
        {
            // Read input as long as this is true.
            bool anotherRecord = true;

            while (anotherRecord)
            {
                // Commit to the database only after confirmation
                bool commit = false;

                showHeader();

                readEmail();
                readFirstName();
                readLastName();
                readPassword();

                while (commit == false)
                {
                    commit = readReview();
                }

                saveRecord();

                anotherRecord = getAnotherRecordPrompt();
            }
        }
    }
}
