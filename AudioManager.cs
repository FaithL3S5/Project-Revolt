using UnityEngine.Audio;
using UnityEngine;
using System;



public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Start()
    {
        Play("Mtheme");
        Play("Water");
    }

    public void Stop()
    {
        Sound s1 = Array.Find(sounds, sound => sound.name == "Mtheme");
        Sound s2 = Array.Find(sounds, sound => sound.name == "Water");
        s1.source.Pause();
        s2.source.Pause();
    }

    public void PEnter()
    {
        Play("Penter");
    }

    public void PClick()
    {
        Play("Pclick");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found!");
            return;
        }
        s.source.Play();
    }

}
