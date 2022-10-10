using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource _audioSource;
    [SerializeField]
    private CustomSong[] _songs;
    [SerializeField]
    private CustomSoundEffect[] _soundEffects;

    public CustomSong GetCustomSong(SongsEnum songId) { 
        foreach(CustomSong _song in _songs)
        {
            if(_song.Id == songId)
            {
                return _song;
            }
        }
        return null;
    }

    public CustomSoundEffect GetCustomSoundEffect(SoundEffectsEnum soundEffectId)
    {
        foreach (CustomSoundEffect _soundEffect in _soundEffects)
        {
            if (_soundEffect.Id == soundEffectId)
            {
                return _soundEffect;
            }
        }
        return null;
    }

    private void Start()
    {
        if(instance != null)
        {
            return;
        } 
        else
        {
            instance = this;
        }
        _audioSource = GetComponent<AudioSource>();
        PlaySong(SongsEnum.SONG_1);
    }

    IEnumerator PlayAudioCorutine(CustomAudio audio, float delay, bool loop = false)
    {
        yield return new WaitForSeconds(delay);
        if (loop)
        {
            _audioSource.Stop();
            _audioSource.clip = audio.Clip;
            _audioSource.volume = audio.Volume;
            _audioSource.loop = true;
            _audioSource.Play();
        }
        else
        {
            _audioSource.PlayOneShot(audio.Clip, audio.Volume);
        }
    }

    public void StopSong()
    {
        _audioSource.Stop();
    }

    public void PlaySong(SongsEnum songId, float delay = Constants.AudioManager.InBetweenSongsPauseLength)
    {
        _audioSource.Stop();
        CustomSong song = GetCustomSong(songId);
        StartCoroutine(PlayAudioCorutine(song, delay, loop: true));
    }

    public void PlaySoundEffect(SoundEffectsEnum soundEffectId, float delay = 0f)
    {
        CustomSoundEffect soundEffect = GetCustomSoundEffect(soundEffectId);
        StartCoroutine(PlayAudioCorutine(soundEffect, delay));
    }
}
