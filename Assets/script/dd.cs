using UnityEngine;
using System.Collections;

public class CooldownActivation11 : MonoBehaviour
{
    public GameObject objectToActivate; // ออบเจ็กต์ที่จะเปิดใช้งาน
    public GameObject objectToDeactivate; // ออบเจ็กต์ที่จะปิดใช้งาน
    public float cooldownTime = 5.0f; // เวลาคูลดาวน์เป็นวินาที

    void Start()
    {
        StartCoroutine(CooldownCoroutine());
    }

    IEnumerator CooldownCoroutine()
    {
        // ปิดการใช้งาน objectToDeactivate ก่อนเริ่ม cooldown
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }

        // รอเวลา cooldownTime ก่อนเปิดใช้งานออบเจ็กต์
        yield return new WaitForSeconds(cooldownTime);

        // เปิดใช้งานออบเจ็กต์ที่กำหนด
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
