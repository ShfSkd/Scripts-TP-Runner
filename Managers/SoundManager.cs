using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
   
    private void Awake()
    {
        
        foreach (Sound sound in sounds)
        {
            sound.source= gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.loop = sound.loop;
            
           
        }

        PlaySound("MainTheme");
        
    }

    public void PlaySound(string name)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == name)
                sound.source.Play();
        }
    }
    public void StopSound(string name)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name == name)
                sound.source.Stop();
        }
    }
}
