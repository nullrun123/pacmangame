using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed;
    public float speedrun;
    public float walkspeed;
    public float gravity = -9.81f;
    Vector3 V;

    public GameObject lightspot;
    public bool alreadylight = true;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Left Shift key is being held down for sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedrun;
        }
        else
        {
            speed = walkspeed;
        }

        // Toggle the lightspot on and off when the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            alreadylight = !alreadylight;
            lightspot.SetActive(alreadylight);
        }

        // Check if the player is on the ground
        if (controller.isGrounded && V.y < 0)
        {
            V.y = -2f;
        }

        // Get input from the player for movement
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        // Create a movement vector based on input
        Vector3 M = transform.right * X + transform.forward * Z;

        // Move the character controller based on the movement vector and speed
        controller.Move(M * speed * Time.deltaTime);

        // Apply gravity
        V.y += gravity * Time.deltaTime;

        // Move the character controller based on the gravity vector
        controller.Move(V * Time.deltaTime);
    }
}
