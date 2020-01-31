using UnityEngine;

public class Movement : MonoBehaviour
{
    //new public Rigidbody2D rigidbody;
    public LayerMask groundLayers;
    public float moveSpeed;
    public float jumpPower;
    float targetMoveSpeed;

    bool grounded;

    void Start()
    {
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        var rigidbody = gameObject.GetComponent<Rigidbody2D>();

        // Gets movement speed and applies it
        targetMoveSpeed = Mathf.Lerp(rigidbody.velocity.x, Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, Time.deltaTime * 10);

        // Jumps if not grounded
        if(grounded && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 1f * jumpPower);
            return;
        }

        rigidbody.velocity = new Vector2(targetMoveSpeed, rigidbody.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("ground", System.StringComparison.OrdinalIgnoreCase))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("ground", System.StringComparison.OrdinalIgnoreCase))
        {
            grounded = false;
        }
    }
}
