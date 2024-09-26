using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musicplay : MonoBehaviour
{
    public Slider volumeslider;
    // Start is called before the first frame update
    public GameObject objectmusic;

    private float musicVolume = 0f;
    public AudioSource AudioSource;
    void Start()
    {
        objectmusic = GameObject.FindWithTag("GameMusic");
        AudioSource = objectmusic.GetComponent<AudioSource>();
        AudioSource.Play();

        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;
        volumeslider.value = musicVolume;
    }


    void Update()
    {
        AudioSource.volume =  musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }
    public void VolumeUpdater(float volume)
    {
        musicVolume =  volume;
    }
    
    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 1;
        volumeslider.value = 1;
    }
}
