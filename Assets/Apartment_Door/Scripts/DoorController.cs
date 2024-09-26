using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public bool keyNeeded = false;              // Is key needed for the door
    public int totalKeysNeeded = 50;            // Number of keys required to open the door
    public int currentKeyCount = 0;             // Count of keys the player has acquired
    public GameObject txtToDisplay;             // Display the information about how to close/open the door

    private bool playerInZone;                  // Check if the player is in the zone
    private bool doorOpened;                    // Check if door is currently opened or not

    private Animation doorAnim;
    private BoxCollider doorCollider;           // To enable the player to go through the door if door is opened else block him

    enum DoorState
    {
        Closed,
        Opened,
        Jammed
    }

    DoorState doorState = new DoorState();      // To check the current state of the door

    private void Start()
    {
        doorOpened = false;                     // Is the door currently opened
        playerInZone = false;                   // Player not in zone
        doorState = DoorState.Closed;           // Starting state is door closed

        txtToDisplay.SetActive(false);

        doorAnim = transform.parent.gameObject.GetComponent<Animation>();
        doorCollider = transform.parent.gameObject.GetComponent<BoxCollider>();

        // If Key is needed and the KeyGameObject is not assigned, stop playing and throw error
        if (keyNeeded && totalKeysNeeded <= 0)
        {
            Debug.LogError("");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        txtToDisplay.SetActive(true);
        playerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInZone = false;
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        // To Check if the player is in the zone
        if (playerInZone)
        {
            if (doorState == DoorState.Opened)
            {
                txtToDisplay.GetComponent<Text>().text = "กด 'E' เพื่อปิด";
                doorCollider.enabled = false;
            }
            else if (doorState == DoorState.Closed && currentKeyCount >= totalKeysNeeded)
            {
                txtToDisplay.GetComponent<Text>().text = "กด 'E' เพื่อเปิด";
                doorCollider.enabled = true;
            }
            else if (doorState == DoorState.Closed && currentKeyCount < totalKeysNeeded)
            {
                txtToDisplay.GetComponent<Text>().text = $"เหมือนว่าประตูล็อคน่ะ";
                doorCollider.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && playerInZone)
        {
            doorOpened = !doorOpened;           // The toggle function of door to open/close

            if (doorState == DoorState.Closed && currentKeyCount >= totalKeysNeeded && !doorAnim.isPlaying)
            {
                doorAnim.Play("Door_Open");
                doorState = DoorState.Opened;
            }

            if (doorState == DoorState.Opened && !doorAnim.isPlaying)
            {
                doorAnim.Play("Door_Close");
                doorState = DoorState.Closed;
            }
        }
    }

    public void AddKey()
    {
        currentKeyCount++;  // Increment the key count
    }
}
