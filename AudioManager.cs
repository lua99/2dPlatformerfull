using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundeffects;

    public AudioSource bgm, Endlevel;


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int soundToPlay)
    {
        soundeffects[soundToPlay].Play();
       // soundeffects[soundToPlay].pitch = Random.Range(0.9f, 1.1f);
    }
    
}
