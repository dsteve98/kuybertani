using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip tanamSound, panenSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        tanamSound = Resources.Load<AudioClip>("Goat Sheep (1)");
        panenSound = Resources.Load<AudioClip>("Cat (2)");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "tanam":
                audioSrc.PlayOneShot(tanamSound);
                break;
            case "panen":
                audioSrc.PlayOneShot(panenSound);
                break;
        }
    }
}
