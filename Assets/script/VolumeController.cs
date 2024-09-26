using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeControl : MonoBehaviour
{
    
    public AudioSource musicSource;  // เชื่อมต่อ AudioSource ที่เล่นเพลง
    public float musicVolume = 1f;
    void Start()
    {
        musicSource.Play();
    }
    private void Update()
    {
        musicSource.volume = musicVolume;
    }

    // ฟังก์ชันสำหรับปรับระดับเสียง
    public void SetVolume(float volume)
    {
        musicVolume = volume;
    }
}
