using System;
using UnityEngine;

[Serializable]
public class WaveCounter
{
    [SerializeField]
    private int _wavesLeft;

    public WaveCounter(int wavesLeft = Constants.Waves.WaveLimit)
    {
        _wavesLeft = wavesLeft;
    }

    public int WavesLeft { get { return _wavesLeft; } set { _wavesLeft = value; } }
}
