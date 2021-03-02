using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip blockSound, deathSound;
    static AudioSource audioSrc;

    void Start(){

        blockSound = Resources.Load<AudioClip>("block");

        deathSound = Resources.Load<AudioClip>("gameOver");

        audioSrc = GetComponent<AudioSource>();


    }

    public static void Play(string clip){
        switch (clip)
        {
            case "block":
                audioSrc.PlayOneShot(blockSound);
                break;
            case "over":
                audioSrc.PlayOneShot(deathSound);
                break;
        }
    }
}
