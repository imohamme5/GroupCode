using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Profile
    {
        Level[] level = new Level[Global.levelCount];
		
        public Profile()
        {
            

            for(int i = 0; i<level.Length; i++)
            {
                level[i] = new Level(false, 0);
            }

            level[0]._unlocked = true;
        }

        public void Load()
        {
            if (!System.IO.File.Exists("/Documents/Profile.txt"))
            { 
                Console.WriteLine("File not found.");
				Save();
            }
            else
            {
                string profileData = System.IO.File.ReadAllText("/Documents/Profile.txt");

                int startHead = 0;
                int endHead = 0;
                string read;
                int alt = 0;

                for(int i= 0; i<Global.levelCount;i++)
                {
                    for(int c = 0; c <profileData.Length;c++)
                    {
                        if (c == ' ')
                        {
                            endHead = c;
                            read = profileData.Substring(startHead, endHead);
                            startHead = endHead;

                            switch (alt)
                            {
                                case 0:
                                    level[i]._unlocked = Convert.ToBoolean(read);
                                    alt = 1;
                                    break;
                                case 1:
                                    level[i]._highscore = Convert.ToInt32(read);
                                    alt = 0;
                                    break;
                            }
                        }
                        
                    }
                }
            }

        }

        public void Save()
        {
            if (!System.IO.File.Exists("/Documents/Profile.txt"))
            {
                System.IO.File.Create("/Documents/Profile.txt");
            }


            //for each level in level[]
            //level.unlocked
            //'evel.highscore
            string profileData = "";
            int i = 0;
            foreach(Level l in level)
            {
                profileData = profileData.Insert(profileData.Length, level[i]._unlocked.ToString());
                profileData = profileData.Insert(profileData.Length, " ");
                profileData = profileData.Insert(profileData.Length, level[i]._highscore.ToString());
                profileData = profileData.Insert(profileData.Length, " ");
                i++;
            }

            profileData = profileData.Remove(profileData.Length-1);
            System.IO.File.WriteAllText("/Documents/Profile.txt",profileData);
        }
    }
    class Level
    {
        public bool _unlocked = false;
        public int _highscore = 0;

        public Level(bool unlocked, int highscore)
        {
            _unlocked = unlocked;
            _highscore = highscore;
        }

        //public bool unlocked
        //{
        //    get { return unlocked; }
        //}
    }
    public static class Global
    {
        public const int levelCount = 4;
    }
}
