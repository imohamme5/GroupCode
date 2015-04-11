using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class ReadLevel
    {
        static void Load(string[] args)
        {
            if (System.IO.File.Exists("testParse.txt"))
            {
                string entireFile = System.IO.File.ReadAllText("testParse.txt");

                foreach (char c in entireFile)
                {

                    //lower case - jump

                    if(c.Equals('a'))
                    {
                        //LEAVE OBJECT EMPTY
                        Console.WriteLine("Level one");
                    }
                    else if (c.Equals('b'))
                    {
                        //SPAWN JUMP OBJECT
                        Console.WriteLine("Level two");
                    }
                    else if (c.Equals('c'))
                    {
                        //SPAWN DUCK OBJECT
                        Console.WriteLine("Level three");
                    }
                    else if (c.Equals('d'))
                    {
                        //SPAWN ENEMY OBJECT
                        Console.WriteLine("Level four");
                    }

                    //upper case - duck

                    else if (c.Equals('A'))
                    {
                        //LEAVE OBJECT EMPTY
                        Console.WriteLine("Level one - Duck");
                    }
                    else if (c.Equals('B'))
                    {
                        //SPAWN JUMP OBJECT
                        Console.WriteLine("Level two - Duck");
                    }
                    else if (c.Equals('C'))
                    {
                        //SPAWN DUCK OBJECT
                        Console.WriteLine("Level three - Duck");
                    }
                    else if (c.Equals('D'))
                    {
                        //SPAWN ENEMY OBJECT
                        Console.WriteLine("Level four - Duck");
                    }
                    else
                    {
                        //LEAVE OBJECT EMPTY
                        Console.WriteLine("Error: Invalid Char");
                    }
                }
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
            Console.ReadLine();
        }
    }
}
