using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    [SerializeField]
    private SoundType[] Sounds;


    private void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        PlayerMusic(global::Sounds.BackgroundMusic);
    }
   
    public void PlayerMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.Play();
        }
    }
    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
     SoundType returnSound = Array.Find(Sounds, item => item.soundType == sound);
        if(returnSound != null)
            return returnSound.soundClip;
        return null;
    }
}
[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    buttonClick,
    BackgroundMusic,
    PlayerJump,
    PlayerMove,
    PlayerDeath, 
    PlayerPicUp,
    EnemyDeath,
    MovingPlatform,

}
