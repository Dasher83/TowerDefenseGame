using System;
using UnityEngine;

[Serializable]
public class CustomSong: CustomAudio
{
    [SerializeField]
    private SongsEnum _id;

    public SongsEnum Id => _id;
}
