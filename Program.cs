using OOP_Assigment_classlib;

namespace OOP_final_project
{
    internal class Program
    {
        // component based modelling (1) [Rafan] 
        // API with DB (2) [Brian] 
        // Unit testing (3) [Radit]
        // Design patterns (4) [Syauqi]
        // Refactor (5) [Rafan]
        static void Main(string[] args)
        {
            bool isrun = true;
            while (isrun)
            {
                List<string> options = new List<string>()
            {
                "LOGIN","QUIT"
            };
                textdraw textdraw = new textdraw();
                textdraw.drawtitle("HOSPITAL APPLICATION", "A hospital application", false);
                textdraw.drawmultoption(options);
                textdraw.drawtextnole(">");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "LOGIN":
                        // add login function here
                        break;
                    case "QUIT":
                        isrun = false;
                        break;
                    default:
                        textdraw.drawtext("Please input option");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
