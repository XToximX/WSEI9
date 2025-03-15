using UnityEngine;
using System.Collections.Generic;

public class SoundMgr : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    public int currTrack;

    [Header("Clips")]
    [SerializeField] List<AudioClip> musicClipList;
    [SerializeField] List<AudioClip> sfxClipList;


    public void PlaySFX(int nr)
    {
        sfxSource.clip = sfxClipList[nr];
        sfxSource.Play();
    }

    public void changeMusic(int nr)
    {
        musicSource.clip = musicClipList[nr];
        currTrack = nr;
        musicSource.Play();
    }
}
