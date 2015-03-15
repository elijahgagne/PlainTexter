using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Media;

namespace PlainTexter.Utilities
{
    public class SoundManager
    {
        public static void PlaySound()
        {
            SoundPlayer soundplayer = new SoundPlayer(PlainTexter.Resource.laser);
            soundplayer.Play();
        }
    }
}
