using UnityEngine;

public class SoundManager : MonoBehaviour
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
