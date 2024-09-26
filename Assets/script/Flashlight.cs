using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashlightPlayer;
    private bool FlashlightActive = false;
    // Start is called before the first frame update
    void Start()
    {
        FlashlightPlayer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(FlashlightActive == false)
            {
                FlashlightPlayer.gameObject.SetActive(true);
                FlashlightActive = true;
            }
            else
            {
                FlashlightPlayer.gameObject.SetActive(false);
                FlashlightActive = false;

            }
        }
    }
}
