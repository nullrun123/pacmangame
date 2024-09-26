using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public string targetTag = "coins"; // แท็กที่คุณต้องการตรวจสอบ
    public AudioClip collisionSound; // เสียงเอฟเฟกต์ที่จะเล่น

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // รับ AudioSource จาก GameObject
    }

    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าชนกับวัตถุที่มี Tag ที่กำหนดหรือไม่
        if (other.CompareTag(targetTag))
        {
            // เล่นเสียงเอฟเฟกต์
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
