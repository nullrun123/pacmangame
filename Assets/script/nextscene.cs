using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToMap1 : MonoBehaviour
{
    // เมื่อผู้เล่นชนกับ Collider
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าผู้เล่นชนกับ Collider นี้หรือไม่
        if (other.CompareTag("Player"))
        {
            // เปลี่ยนไปฉาก "map1"
            SceneManager.LoadScene("map2");
        }
    }
}
