using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip footstepClip; // คลิปเสียงฟุตสเต็ปสำหรับปุ่ม W, A, S, D
    public AudioClip runningClip;  // คลิปเสียงฟุตสเต็ปสำหรับปุ่ม Shift
    public AudioSource audioSource; // AudioSource component
    public float walkStepInterval = 0.5f; // ช่วงเวลาระหว่างแต่ละเสียงฟุตสเต็ปเมื่อเดิน
    public float runStepInterval = 0.2f;  // ช่วงเวลาระหว่างแต่ละเสียงฟุตสเต็ปเมื่อวิ่ง

    private float timeSinceLastStep = 0f;
    private bool isRunning = false;

    void Update()
    {
        // เช็คการกดปุ่ม W, A, S, D และ Shift
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            // เลือกช่วงเวลาตามว่ากำลังวิ่งหรือเดิน
            float stepInterval = isRunning ? runStepInterval : walkStepInterval;

            // นับเวลาที่ผ่านไปตั้งแต่เสียงฟุตสเต็ปครั้งล่าสุด
            timeSinceLastStep += Time.deltaTime;

            // ถ้าถึงเวลาที่ต้องเล่นเสียงฟุตสเต็ป
            if (timeSinceLastStep >= stepInterval)
            {
                if (isRunning)
                {
                    PlayRunningSound(); // เล่นเสียงฟุตสเต็ปเมื่อวิ่ง
                }
                else
                {
                    PlayFootstepSound(); // เล่นเสียงฟุตสเต็ปเมื่อเดิน
                }
                timeSinceLastStep = 0f; // รีเซ็ตเวลานับใหม่
            }
        }
        else
        {
            timeSinceLastStep = walkStepInterval; // รีเซ็ตเวลานับเมื่อไม่มีการกดปุ่ม
        }
    }

    void PlayFootstepSound()
    {
        audioSource.PlayOneShot(footstepClip); // เล่นเสียงฟุตสเต็ปเมื่อเดิน
    }

    void PlayRunningSound()
    {
        audioSource.PlayOneShot(runningClip); // เล่นเสียงฟุตสเต็ปเมื่อวิ่ง
    }
}
