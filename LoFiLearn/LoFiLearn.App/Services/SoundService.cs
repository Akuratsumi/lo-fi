using System;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Media.Core;

namespace LoFiLearn.App.Services;

public sealed class SoundService
{
    private readonly MediaPlayer _player = new();

    public double Volume
    {
        get => _player.Volume * 100;
        set => _player.Volume = Math.Clamp(value / 100.0, 0, 1);
    }

    public async Task PlayPopAsync()
    {
        try
        {
            var uri = new Uri("ms-appx:///Assets/Sounds/pop.wav");
            var source = MediaSource.CreateFromUri(uri);
            _player.Source = source;
            _player.Volume = Math.Clamp(_player.Volume, 0, 1);
            _player.Play();
        }
        catch
        {
            // fallback quietly if sound cannot play
        }
    }
}
