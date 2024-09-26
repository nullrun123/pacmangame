using UnityEngine;

public class PlayerMovement101 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Vector3 pushDirection = collision.contacts[0].normal;
            rb.MovePosition(transform.position + pushDirection * moveSpeed * Time.deltaTime);
        }
    }
}
