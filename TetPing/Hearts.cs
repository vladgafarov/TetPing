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
        public const int Count = 7;
        public int RemovedHearts = 0;
        public List<Heart> HeartsList = new List<Heart>(Count);

        public Hearts(Control form)
        {
            for(var i = 0; i < Count; i++)
            {
                var heartItem = new Heart(form, i);
                HeartsList.Add(heartItem);
            }
        }

        public void RemoveHeart(int index)
        {
            Heart heartToRemove = HeartsList[Count - index - 1];
            heartToRemove.ChangeBg();

            RemovedHearts++;
        }

        public void Reset()
        {
            HeartsList.ForEach(heart => heart.ChangeBg());
        }
    }
}
