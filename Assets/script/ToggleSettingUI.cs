using UnityEngine;

public class ToggleSettingUI : MonoBehaviour
{
    public GameObject settingPanel;

    private bool isPanelActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPanelActive = !isPanelActive;
            settingPanel.SetActive(isPanelActive);
        }

        // ทำให้ cursor เปิด/ปิด ตามสถานะของ isPanelActive
        if (isPanelActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
