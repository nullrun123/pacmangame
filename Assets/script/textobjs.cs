using UnityEngine;
using UnityEngine.UI;

public class ObjZoneController : MonoBehaviour
{
    public Text txtToDisplay;      // ข้อความ UI ที่จะแสดงเมื่อผู้เล่นเข้าใกล้
    public string objectTag = "door";   // กำหนด tag ที่ต้องการตรวจสอบ
    private bool playerInZone = false;

    private void Start()
    {
        // ซ่อนข้อความ UI ตั้งแต่เริ่มต้น
        txtToDisplay.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // เช็คว่าผู้เล่นเข้ามาใกล้กับวัตถุที่มี tag "objs" หรือไม่
        if (other.CompareTag(objectTag))
        {
            txtToDisplay.gameObject.SetActive(true);  // แสดงข้อความ UI
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // เช็คว่าผู้เล่นออกจากโซนของวัตถุที่มี tag "objs" หรือไม่
        if (other.CompareTag(objectTag))
        {
            txtToDisplay.gameObject.SetActive(false);  // ซ่อนข้อความ UI
            playerInZone = false;
        }
    }

    private void Update()
    {
        // อัปเดตข้อความ UI (ในกรณีที่ต้องการเปลี่ยนแปลงข้อความตามสถานการณ์อื่นๆ)
        if (playerInZone)
        {
            txtToDisplay.text = "You are near the object!";
        }
    }
}
