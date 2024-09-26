using UnityEngine;
using UnityEngine.SceneManagement; // จำเป็นต้องใช้

public class SceneController : MonoBehaviour
{
    public string sceneToLoad; // ชื่อของฉากที่ต้องการโหลด

    // ฟังก์ชันสำหรับเปลี่ยนไปยังฉากที่กำหนด
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    // ฟังก์ชันสำหรับออกจากเกม
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
