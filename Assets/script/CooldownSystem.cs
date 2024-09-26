using UnityEngine;
using System.Collections;

public class CooldownActivation : MonoBehaviour
{
    public float activationTime = 5f; // เวลาที่ object จะถูกเปิดใช้งาน
    private bool isActivated = false;

    void Start()
    {
        // เรียกการทำงานของ ActivateObject เมื่อเริ่มเกม
        StartCoroutine(ActivateObject());
    }

    private IEnumerator ActivateObject()
    {
        isActivated = true;
        // เปิดใช้งาน object
        gameObject.SetActive(true);

        // รอเวลา activationTime วินาที
        yield return new WaitForSeconds(activationTime);

        // ปิดการใช้งาน object
        gameObject.SetActive(false);

        isActivated = false;
    }
}
