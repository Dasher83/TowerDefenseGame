using System;
using UnityEngine;

[Serializable]
public class CustomSoundEffect: CustomAudio
{
    [SerializeField]
    private SoundEffectsEnum _id;

    public SoundEffectsEnum Id => _id;
}

