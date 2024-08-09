using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{

    public interface IMediaPlayer
    {
        void Play(string fileName);
    }

    //The VLCPlayer Class with a Different Interface
    public class VLCPlayer
    {
        public void PlayVLC(string fileName)
        {
            Console.WriteLine($"Playing {fileName} using VLC Player.");
        }
    }

    //To make VLCPlayer compatible with IMediaPlayer interface we can create an adapter
    public class MediaPlayerAdapter : IMediaPlayer
    {
        private readonly VLCPlayer _vlcPlayer;

        public MediaPlayerAdapter(VLCPlayer vlcPlayer)
        {
            _vlcPlayer = vlcPlayer;
        }

        public void Play(string fileName)
        {
            _vlcPlayer.PlayVLC(fileName); //Adapting the incompatible method
        }
    }

    //Now you can use the VLCPalyer with IMediaPlayer  interface via the adapter.
    internal class Program
    {
        static void Main(string[] args)
        {
            VLCPlayer vlcPlayer = new VLCPlayer();
            IMediaPlayer mediaPlayer = new MediaPlayerAdapter(vlcPlayer);

            mediaPlayer.Play("movie.mp4");
        }
    }
}
