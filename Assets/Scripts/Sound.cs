using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource totalaudio;
    public AudioClip[] sounds;
    void Start()
    {
        totalaudio = GetComponent<AudioSource>();
    }
    
    public void SoundPlay(int soundNum)
    {
        totalaudio.PlayOneShot(sounds[soundNum]);
    }

    public void SoundStop(int soundNum)
    {
        totalaudio.Stop();
    }
}
