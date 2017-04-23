using System;
using NAudio.Wave;

namespace TriggeredAnimation
{
    class AudioService
    {
        public AudioService()
        {
            //int waveInDevices = WaveIn.DeviceCount;
            //for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
            //{
            //    WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
            //    //Console.WriteLine("Device {0}: {1}, {2} channels",
            //    //    waveInDevice, deviceInfo.ProductName, deviceInfo.Channels);
            //}
            if (WaveIn.DeviceCount== 0)
                return;

            var waveIn = new WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.DataAvailable += waveIn_DataAvailable;
            int sampleRate = 8000; // 8 kHz
            int channels = 1; // mono
            waveIn.WaveFormat = new WaveFormat(sampleRate, channels);
            waveIn.StartRecording();
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) |
                                        e.Buffer[index + 0]);
                float sample32 = sample / 32768f;
                ProcessSample(sample32);
            }
        }

        public float Current;
        private void ProcessSample(float sample32)
        {
            if (sample32 > 0.01f)
                Current = sample32;
            else if (sample32 < -0.01f)
                Current = -sample32;
            else
                Current = 0f;
        }
    }
}
