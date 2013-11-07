using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASCII;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace ASCIIConsole
{
    class Display : IDisplay
    {
        private static IDisplay _Instance = null;
        private bool _Done = false;
        private IFort _Fort;
        private int _FortLocation;
        private int[] _FortHealthLocation;
        private int width = 120;
        private int height = 40;

        private String _Logo = "                        AAA                   SSSSSSSSSSSSSSS           CCCCCCCCCCCCC  IIIIIIIIII  IIIIIIIIII\n                       A:::A                SS:::::::::::::::S       CCC::::::::::::C  I::::::::I  I::::::::I\n                      A:::::A              S:::::SSSSSS::::::S     CC:::::::::::::::C  I::::::::I  I::::::::I\n                     A:::::::A             S:::::S     SSSSSSS    C:::::CCCCCCCC::::C  II::::::II  II::::::II\n                    A:::::::::A            S:::::S               C:::::C       CCCCCC    I::::I      I::::I  \n                   A:::::A:::::A           S:::::S              C:::::C                  I::::I      I::::I  \n                  A:::::A A:::::A           S::::SSSS           C:::::C                  I::::I      I::::I  \n                 A:::::A   A:::::A           SS::::::SSSSS      C:::::C                  I::::I      I::::I  \n                A:::::A     A:::::A            SSS::::::::SS    C:::::C                  I::::I      I::::I  \n               A:::::AAAAAAAAA:::::A              SSSSSS::::S   C:::::C                  I::::I      I::::I  \n              A:::::::::::::::::::::A                  S:::::S  C:::::C                  I::::I      I::::I  \n             A:::::AAAAAAAAAAAAA:::::A                 S:::::S   C:::::C       CCCCCC    I::::I      I::::I  \n            A:::::A             A:::::A    SSSSSSS     S:::::S    C:::::CCCCCCCC::::C  II::::::II  II::::::II\n           A:::::A               A:::::A   S::::::SSSSSS:::::S     CC:::::::::::::::C  I::::::::I  I::::::::I\n          A:::::A                 A:::::A  S:::::::::::::::SS        CCC::::::::::::C  I::::::::I  I::::::::I\n         AAAAAAA                   AAAAAA  ASSSSSSSSSSSSSSS             CCCCCCCCCCCCC  IIIIIIIIII  IIIIIIIIII\n";
        private int _LogoWidth = 92;
        private int _LogoHeight = 16;
        private String _Slogan = "Actual Simulated Crap Issues Irritation";
        private String _StartText = "Press any button to continue";
        private String[] _Models = new String[] { " ", ".", "o", "O", "U" };


        public void AddLivable(ILivable livable)
        {
            //_Livables.TryAdd(livable, livable);
            ISoldier entity = livable.Soldier;
            Random r = new Random(livable.GetHashCode() * this.GetHashCode() / 2);
            entity.Location = new int[2] { 0, r.Next(0, height) };
            livable.Soldier = entity;
            DrawEntity(livable);
        }

        public void RemoveLivable(ILivable livable)
        {
            //_AnimationQueue.Remove(livable);
            ISoldier entity = livable.Soldier;
            int[] loc = entity.Location;
            Console.SetCursorPosition((loc[0] > 2) ? loc[0] - 3 : loc[0], loc[1]);
            Console.Write("     ");
            //_Animators.Remove(livable);
            //_Livables.TryRemove(livable, out livable);
            //_AnimationQueue.TryRemove(livable, out livable);
            //_AnimationQueue.RemoveAll(i => i.Id == livable.Id);
        }

        public void AnimateEntity(ILivable livable)
        {
            ISoldier entity = livable.Soldier;
            int[] loc = entity.Location;
            //Console.SetCursorPosition((loc[0] > 1) ? loc[0] - 1 : loc[0], loc[1]);
            //Console.Write("  ");
            for (int i = loc[0] - 4; i < loc[0]; i++)
            {
                Console.SetCursorPosition((i > 0) ? i : 0, loc[1]);
                Console.Write(" ");
            }
            DrawEntity(livable);
        }

        public void DrawEntity(ILivable livable)
        {
            ISoldier entity = livable.Soldier;
            int[] loc = entity.Location;
            Console.SetCursorPosition(loc[0], loc[1]);
            Console.Write(_Models[entity.Level]);
        }

        public bool ReachedFort(int[] loc)
        {
            return loc[0] >= _FortLocation;
        }

        public void UpdateFort()
        {
            if (_FortHealthLocation == null)
            {
                int[] loc = new int[2];
                loc[0] = width - 7;
                loc[1] = height / 2;
                _FortHealthLocation = loc;
            }
            
            Console.SetCursorPosition(_FortHealthLocation[0], _FortHealthLocation[1]);
            Console.Write("    ");
            Console.SetCursorPosition(_FortHealthLocation[0], _FortHealthLocation[1]);
            Console.Write(_Fort.Health);
        }

        public bool isDone()
        {
            return _Done;
        }

        public void Gameover()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game over yay finally woopdiedoo");
        }

        public void End()
        {
            Console.Clear();
        }

        public void BuildFort(IFort fort)
        {
            _Fort = fort;
            _FortLocation = width - 10;
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(_FortLocation, i);
                Console.Write("|");
            }
            UpdateFort();
        }

        public bool HasFort()
        {
            return (_Fort != null) ? true : false;
        }

        public int RequestDifficulty()
        {
            bool valid = false;
            while (!valid)
            {
                Console.Clear();
                Console.WriteLine("-- Choose a simulation level");
                Console.WriteLine("[1] Low");
                Console.WriteLine("[2] Normal");
                Console.WriteLine("[3] High");
                Console.WriteLine("[4] Uber");
                Console.Write("Enter your choice: ");
                String c = Console.ReadKey().KeyChar.ToString();
                try
                {
                    int b = int.Parse(c);
                    if (b > 0 && b < 5)
                    {
                        Console.Clear();
                        return b;
                    }
                }
                catch (Exception e)
                {
                }
                Console.WriteLine();
                Console.WriteLine("Invalid selection, try again!");
                Console.ReadKey();
            }
            return 2;
            
        }

        public void Initialize()
        {
            String s = "";
            int h = ((height - _LogoHeight) - 12) / 2;
            for (int i = 0; i < h; i++)
            {
                Console.WriteLine();
            }
            for (int j = 0; j < 7; j++)
            {
                if (j != 3)
                {
                    for (int i = 0; i < width; i++)
                    {
                        s += "#";
                    }
                }
                else
                {
                    int w = (width - _Slogan.Length) / 2;
                    String s2 = "";
                    for (int i = 0; i < w; i++)
                    {
                        s2 += " ";
                    }
                    int w1 = (width - _StartText.Length) / 2;
                    String s3 = "";
                    for (int i = 0; i < w1; i++)
                    {
                        s3 += " ";
                    }
                    s += "\n";
                    s += _Logo;
                    s += "\n";
                    s += s2 + _Slogan;
                    s += "\n\n";
                    s += s3 + _StartText + "\n\n";
                }
                Console.Write(s);
                s = "";
            }
            Console.ReadKey();
        }

        public static IDisplay getInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Display();
            }
            return _Instance;
        }

        private Display()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
        }
    }
}
