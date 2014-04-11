using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3.Data;

namespace Google_Analytics_MetaData_API.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            string _client_id = "<yourclientid>.apps.googleusercontent.com";
            string _client_secret = "<your app secret>";

            GAAutentication Autentication = new GAAutentication();
            Autentication.initAnaltyics(_client_id, _client_secret);
            if (Autentication.service == null)
            {
                Console.WriteLine("User declined Autentication. Can not continue/n");
                var name = Console.ReadLine();

            }
            else
            {
                Program.ListMenu(Autentication);
            }
        }

        public static void ListMenu(GAAutentication Autentication)
        {

            Console.WriteLine("User Autenticated:  ");
            Console.WriteLine("RefreshToken     :  " + Autentication.credential.Token.RefreshToken);
            Console.WriteLine("Options          :  ");
            Console.WriteLine("     List               - Displays a list of all Metadata");
            Console.WriteLine("     Groups             - Displays a Distint MetaData groups");
            Console.WriteLine("     Dimensions <Group> - Displays a list of dimensions witin a group");
            Console.WriteLine("     Metrics    <Group> - Displays a list of metrics witin a group");
            Console.WriteLine("     Menu               - Shows this Menu");
            Console.WriteLine("");

            Program.PromptDoNext(Autentication);
        }
        public static void PromptDoNext(GAAutentication Autentication)
        {
            Console.WriteLine("");
            Console.WriteLine("What would you like to do:");
            var Action = Console.ReadLine();
            Program.readAction(Autentication, Action);


        }

        public static void readAction(GAAutentication Autentication, string Action)
        {

            string[] vars = Action.Split(' ');

            switch (vars[0].ToLower())
            {
                case "menu":
                    Program.ListMenu(Autentication);
                    break;
                case "list":
                    Console.WriteLine("");
                    Console.WriteLine("Listing All MetaData:  ");
                    Columns myMetaData = GAMetaData.MetaListAll(Autentication.service);
                    if (myMetaData == null)
                    {
                        Console.WriteLine("User does not have access to any MetaData");
                    }
                    else
                    {
                        foreach (Column cols in myMetaData.Items)
                        {
                            Console.WriteLine("ApiName    :" + cols.Id);
                            Console.WriteLine("UIName     : " + cols.Attributes["uiName"]);
                            Console.WriteLine("Group      : " + cols.Attributes["group"]);
                            Console.WriteLine("Type     : " + cols.Attributes["type"]);
                            Console.WriteLine("Description: " + cols.Attributes["description"]);

                            Console.WriteLine("");
                        }
                    }
                    Program.PromptDoNext(Autentication);
                    break;
                case "groups":

                    Console.WriteLine("");
                    Console.WriteLine("Listing All MetaData:  ");
                    List<string> myGroups = GAMetaData.getGroups(Autentication.service);
                    if (myGroups == null)
                    {
                        Console.WriteLine("User does not have access to any MetaData");
                    }
                    else
                    {
                        foreach (string group in myGroups)
                        {
                            Console.WriteLine(group);
                        }
                    }
                    Program.PromptDoNext(Autentication);
                    break;
                case "dimensions":
                    Console.WriteLine("");
                    Console.WriteLine("Listing All Dimensions:  ");

                    foreach (Column col in GAMetaData.getDimensions(Autentication.service))
                    {
                        Console.WriteLine("ApiName    :" + col.Id);
                        Console.WriteLine("UIName     : " + col.Attributes["uiName"]);
                        Console.WriteLine("Group      : " + col.Attributes["group"]);
                        Console.WriteLine("Type     : " + col.Attributes["type"]);
                        Console.WriteLine("Description: " + col.Attributes["description"]);

                        Console.WriteLine("");
                    }
                    Program.PromptDoNext(Autentication);
                    break;

                case "metrics":
                    Console.WriteLine("");
                    Console.WriteLine("Listing All Metrics:  ");

                    foreach (Column col in GAMetaData.getMetrics(Autentication.service))
                    {
                        Console.WriteLine("ApiName    :" + col.Id);
                        Console.WriteLine("UIName     : " + col.Attributes["uiName"]);
                        Console.WriteLine("Group      : " + col.Attributes["group"]);
                        Console.WriteLine("Type     : " + col.Attributes["type"]);
                        Console.WriteLine("Description: " + col.Attributes["description"]);

                        Console.WriteLine("");
                    }
                    Program.PromptDoNext(Autentication);
                    break;
                default:
                    Console.WriteLine("unknown option: " + vars[0]);
                    Program.PromptDoNext(Autentication);
                    break;
            }
        }
    }
}
