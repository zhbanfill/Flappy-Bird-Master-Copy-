using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//grants access to the mixer
using UnityEngine.Audio;
public class RandomContainer : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioMixerGroup output;
    public KeyCode keytopress = KeyCode.Space;
    public float minPitch = 0.75f;
    public float maxPitch = 1.25f;
    void Update()
    {
        //defalt playback method for testing
        if (Input.GetKeyDown(keytopress))
        {

        }
        
    }

    public void PlaySound()
    {
        //randomize within the array length
        int randomClip = Random.Range(0, clips.Length);

        //create audio source 
        AudioSource source = gameObject.AddComponent<AudioSource>();

        //load clip into audio source
        source.clip = clips[randomClip];

        //setoutput for audio source
        source.outputAudioMixerGroup = output;

        //set pitch variation
        source.pitch = Random.Range(minPitch, maxPitch);

        //play clip
        source.Play();

        //destroy audio source when done, after full length of clip
        Destroy(source, clips[randomClip].length);
        
    }
}
