using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class KeyController : MonoBehaviour
{
    BoxCollider keyCollider;
    public Text txtToDisplay;
    public DoorController DC;

    private void Start()
    {
        keyCollider = GetComponent<BoxCollider>();
        keyCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DC.AddKey(); 
            txtToDisplay.gameObject.SetActive(true);
            //txtToDisplay.text = "Key Acquired";
            this.gameObject.SetActive(false);
        }
    }
}
