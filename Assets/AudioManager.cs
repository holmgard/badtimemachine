using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioManager : MonoBehaviour
{
    public enum SoundEffects
    {
       BlocksForward,
       BlocksBackward
    }
    
    public static AudioManager Instance;

    public AudioSource universalAudioSource;
    
    public AudioClip blocksForward;
    public AudioClip blocksBackwards;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void SoundEffect(AudioManager.SoundEffects soundEffect)
    {
        switch (soundEffect)
        {
            case SoundEffects.BlocksForward:
                universalAudioSource.PlayOneShot(blocksForward);
                break;
            case SoundEffects.BlocksBackward:
                universalAudioSource.PlayOneShot(blocksBackwards);
                break;
        }
    }
}
