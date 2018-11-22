using Quartz;
using System;
using System.IO;
using System.Media;

namespace reminder
{
    
    public class Jobclass : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            string rootLocation = typeof(Program).Assembly.Location;
            string fullPathToSound = Path.Combine(rootLocation, @"Data\Audio\bell.wav");
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }
    }
}
