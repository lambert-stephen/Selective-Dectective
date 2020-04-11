using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] songs;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }

        //enables songs to be played through scenes
        DontDestroyOnLoad(gameObject);
        //loop through the songs
        foreach(Sound s in songs){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    //plays a sounds by string name
    public void Play(String name){
        Sound s = Array.Find(songs,sound => sound.name == name);
        if(s == null){
            return;
        }
        s.source.Play();
    }
    //allows you to play a sound anywhere in the code
    //FindObjectOfType<AudioManager>().Play("name");
}
