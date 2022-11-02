using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Projekt_JPWP_Sebastian_Kowanda
{
    class audioAah: WaveOut
    {
        private WaveStream stream1 = new AudioFileReader(@"E:\Projekcik\githubRep\JPWP-projectRep\Projekt JPWP Sebastian Kowanda\Projekt JPWP Sebastian Kowanda\Audio\Aaah.wav");
        public audioAah(Gierka parent)
        {
            this.Init(stream1);
            this.Play();
        }
    }
}
