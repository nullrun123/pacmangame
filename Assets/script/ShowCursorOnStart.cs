using UnityEngine;

public class ShowCursorOnStart : MonoBehaviour
{
    private void Start()
    {
        // แสดง cursor mouse
        Cursor.visible = true;

        // ปลดล็อค cursor จากตรงกลางจอ
        Cursor.lockState = CursorLockMode.None;
    }
}
