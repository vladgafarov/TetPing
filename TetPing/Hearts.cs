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
        public static int Count = 3;
        public static int MaxCount = 5;
        public static int RemovedHearts = 0;
        public static List<Heart> HeartsList = new List<Heart>(Count);

        public Hearts(Control form)
        {
            for(var i = 0; i < Count; i++)
            {
                var heartItem = new Heart(form, i);
                HeartsList.Add(heartItem);
            }
        }

        public static void AddHeart(Control form)
        {
            var heart = new Heart(form, Count);
            HeartsList.Add(heart);

            Count++;
        }

        public void RemoveHeart(Control form)
        {
            //Heart heartToRemove = HeartsList[Count - index - 1];
            //heartToRemove.ChangeBg();

            //RemovedHearts++;
            Count--;

            form.Controls.Remove(HeartsList[Count].HeartItem);
            HeartsList.RemoveAt(Count);
        }

        public void Reset()
        {
            HeartsList.ForEach(heart => heart.ChangeBg());
        }
    }
}
