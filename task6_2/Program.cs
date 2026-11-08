using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using simple player
            IMediaPlayer player = new SimpleAudioPlayer();
            player.Play("audio.mp3");

            // Using new system from Adapter
            AdvancedAudioSystem advancedAudio = new AdvancedAudioSystem();
            IMediaPlayer adapter = new AudioAdapter(advancedAudio);
            adapter.Play("track.flac");
            Console.Read();
        }
    }

    //Target Interface
    interface IMediaPlayer
    {
        void Play(string fileName);
    }

    //ConcreteTarget
    class SimpleAudioPlayer : IMediaPlayer
    {
        public void Play(string fileName)
        {
            Console.WriteLine("Standard audio file playing: " + fileName);
        }
    }

    //Adaptee
    class AdvancedAudioSystem
    {
        public void PlayAdvanced(string filePath)
        {
            Console.WriteLine("Advanced high-quality file playing: " + filePath);
        }
    }

    //Adapter
    class AudioAdapter : IMediaPlayer
    {
        private AdvancedAudioSystem advanced_audio_;

        public AudioAdapter(AdvancedAudioSystem advanced_audio)
        {
            advanced_audio_ = advanced_audio;
        }

        public void Play(string fileName)
        {
            advanced_audio_.PlayAdvanced(fileName);
        }
    }
}