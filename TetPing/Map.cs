using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class Map
    {
        public static int[,] map;
        public static int mapHeight = 18;
        public static int mapWidth = 15;
        public static List<Block> BlocksList = new List<Block>();

        public Map(Control form)
        {
            map = new int[mapHeight, mapWidth];
            //map[0, 0] = 1;
            //map[0, 1] = 1;
            //map[0, 2] = 1;
            //map[1, 3] = 1;
            //map[17, 14] = 1;
            //map[10, 10] = 1;
            //map[15, 14] = 1;
            //Init();
        }

        public static void Init()
        {
            for(var y = 0; y < mapHeight; y++)
            {
                for(var x = 0; x < mapWidth; x++)
                {
                    if (map[y, x] == 1)
                    {
                        var block = new Block(x, y, 1);
                        BlocksList.Add(block);
                    }
                }
            }
        }

        public static bool IsHiddenPartEmpty(int heightForSearching)
        {
            int count = 0;
            int countShould = mapWidth * heightForSearching;

            for (int i = 0; i < mapWidth; i++)
            {   
                for (int j = 0; j < heightForSearching; j++)
                {
                    if (map[j, i] == 0)
                        count++;
                }
            }

            return count == countShould;
        }
    }
}
