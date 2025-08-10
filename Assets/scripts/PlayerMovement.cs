using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform spotLight; // Drag your Spot Light here in Inspector

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Horizontal movement
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(move * moveSpeed, rb.velocity.y, 0f);

        // Flip player sprite
        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1f, 1f);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            isGrounded = false;
        }

        // Make spotlight rotate to face player without moving it
        if (spotLight != null)
        {
            spotLight.LookAt(transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ground check
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }
}
