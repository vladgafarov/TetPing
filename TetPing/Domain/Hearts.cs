using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing.Domain
{
    class Hearts
    {
        public const int Count = 5;
        public int RemovedHearts = 0;
        private List<Heart> HeartsList = new List<Heart>(Count);

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

        internal void Reset()
        {
            foreach(Heart heart in HeartsList)
            {
                heart.ChangeBg();
            }
        }
    }
}
