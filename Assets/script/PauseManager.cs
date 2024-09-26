using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseMenu;
 

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseMenu.activeInHierarchy == true)
            {
                PauseMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                PauseMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void Backbutton()
    {
        PauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ExitButton()
    {
  
        SceneManager.LoadScene(0);
    }
}
