using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class Hearts
    {
        public static int Count;
        public static int MaxCount = 5;
        public static List<Heart> HeartsList = new List<Heart>(Count);

        public Hearts()
        {
            Count = 3;

            for(var i = 0; i < Count; i++)
            {
                var heartItem = new Heart(i);
                HeartsList.Add(heartItem);
            }
        }

        public static void AddHeart()
        {
            var heart = new Heart(Count);
            HeartsList.Add(heart);

            Count++;
        }

        public static void RemoveHeart()
        {
            Count--;

            HeartsList.RemoveAt(Count);
        }

        public void Reset()
        {
            HeartsList.Clear();
            Count = 3;
            for (var i = 0; i < Count; i++)
            {
                var heartItem = new Heart(i);
                HeartsList.Add(heartItem);
            }
        }
    }
}
