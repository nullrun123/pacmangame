using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollector1 : MonoBehaviour
{
    public int targetCount; // จำนวนที่ต้องเก็บเพื่อทำให้ object หายไป
    private int currentCount = 0; // จำนวนที่เก็บได้
    public Text scoreText; // UI Text สำหรับแสดงจำนวนที่เก็บได้
    public GameObject objectToDisappear; // object ที่จะหายไปเมื่อเก็บครบ
    public AudioSource disappearSound; // เสียงที่จะเล่นเมื่อ object หายไป
    public Text fadeText; // UI Text ที่จะค่อยๆ fade หายไป

    void Start()
    {
        UpdateScoreText();
        fadeText.gameObject.SetActive(false); // ซ่อน fadeText ไว้ก่อน
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coins"))
        {
            currentCount++;
            UpdateScoreText();
            Destroy(other.gameObject); // ทำลาย object ที่เก็บได้

            if (currentCount >= targetCount)
            {
                objectToDisappear.SetActive(false); // ทำให้ object หายไป
                disappearSound.Play(); // เล่นเสียงเมื่อ object หายไป
                StartCoroutine(FadeOutText()); // เรียก Coroutine เพื่อทำให้ข้อความค่อยๆ จางหายไป
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = currentCount + "/" + targetCount;
    }

    IEnumerator FadeOutText()
    {
        fadeText.gameObject.SetActive(true); // แสดงข้อความ
        fadeText.text = "เหมือนว่าประตูจะเปิดน่ะ!"; // ข้อความที่ต้องการแสดง

        yield return new WaitForSeconds(5); // รอ 5 วินาที

        for (float t = 1f; t >= 0; t -= Time.deltaTime)
        {
            Color c = fadeText.color;
            c.a = t;
            fadeText.color = c;
            yield return null;
        }

        fadeText.gameObject.SetActive(false); // ซ่อนข้อความเมื่อ fade เสร็จ
    }
}
