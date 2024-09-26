using UnityEngine;

public class SoundManager1 : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource musicSource1;
    [SerializeField] AudioSource SFXSource;

    public AudioClip collectSound1;
    public AudioClip completeSound;
    public AudioClip background;
    public AudioClip footstep;
    public AudioClip chaseSound;
    private AudioSource audioSource;

    public bool alreadychase = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicSource.clip = background;
        musicSource.Play();

        musicSource1.clip = chaseSound;
    }

    public void PlayCollectSound1()
    {
        audioSource.PlayOneShot(collectSound1);
    }

    public void PlayCompleteSound()
    {
        audioSource.PlayOneShot(completeSound);
    }

    public void PlayChaseSound()
    {
        
        musicSource.Stop();
        musicSource1.Play();

        alreadychase = true;
    }

    public void PlayBackSound()
    {
        musicSource1.Stop();
        musicSource.Play();
        alreadychase = false;
    }
}
