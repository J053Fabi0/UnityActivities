using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState
    {
        Idle = 0,
        Running = 1,
        Jumping = 2,
        Falling = 3
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation(dirX);
    }

    private void UpdateAnimation(float dirX)
    {
        MovementState state = MovementState.Idle;

        if (dirX != 0)
        {
            state = MovementState.Running;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }

        if (dirX != 0)
            sr.flipX = dirX < 0;

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);

        return raycastHit.collider != null;
    }
}
