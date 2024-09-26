using UnityEngine;

public class SpotlightFollowCamera : MonoBehaviour
{
    public Transform cameraTransform; 

    void Update()
    {
       
        transform.rotation = cameraTransform.rotation;
    }
}
