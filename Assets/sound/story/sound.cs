using UnityEngine;

public class SoundManager11 : MonoBehaviour
{
  

    private void Awake()
    {
        GameObject[] musicobj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicobj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
