using UnityEngine;

public abstract class CustomAudio
{
    [SerializeField]
    private AudioClip _clip;
    [SerializeField]
    [Range(0f, 1f)]
    private float _volume;

    public AudioClip Clip
    {
        get { return _clip; }
    }

    public float Volume {
        get { return _volume; }
        set {
            if (value < 0f || value > 1f) {
                return;
            }
            _volume = value;
        }
    } 
}
