using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions
{
    /// <summary>
    /// This is still far from complete, and it still has some bugs,
    /// e.g.with jumping while on slopes. But the bulk of the code has been
    /// moved out of FixedUpdate and into descriptively-named functions,
    /// making the overall order of events much clearer.Comments have been
    /// added to clarify exactly what the new functions are doing.

    /// The three versions of this script are a good demonstration of the
    /// steps to refactor a single class.
    /// </summary>
    public class PlayerMovementWithFunctions : MonoBehaviour
    {

        public float moveForce = 80f;
        public float jumpForce = 800f;
        public float groundCheckDist = .05f;
        public float maxHorizontalVelocity = 15f;
        public float minHorizontalVelocity = .1f;
        public LayerMask whatIsGround;

        Collider2D groundCheckCollider;
        Bounds groundCheckBounds;
        Animator anim;
        Rigidbody2D rb2d;
        SpriteRenderer spriteRenderer;

        float toesYPos;
        Vector3 leftToeWorldPos;
        Vector3 rightToeWorldPos;
        RaycastHit2D leftToeRaycast;
        RaycastHit2D rightToeRaycast;
        bool grounded = true;
        bool willJump = false;

        float xVelocity = 0f;
        float horizontalInput = 0f;

        void Awake()
        {
            anim = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            groundCheckCollider = transform.Find("GroundsCheck").GetComponent<Collider2D>();
        }

        void Update()
        {
            anim.SetBool("isGrounded", grounded);
            if (grounded)
            {
                anim.SetBool("isHurt", false);
            }
            if (Input.GetButtonDown("Jump") && grounded)
            {
                willJump = true;
            }
        }

        void FixedUpdate()
        {
            if (willJump)
            {
                anim.SetBool("isGrounded", false);
                rb2d.AddForce(new Vector2(0f, jumpForce));
                willJump = false;
            }
            horizontalInput = Input.GetAxis("Horizontal");
            rb2d.AddForce(Vector3.right * horizontalInput * moveForce * rb2d.mass, ForceMode2D.Impulse);
            xVelocity = rb2d.velocity.x;
            ClampVelocity(horizontalInput, xVelocity);
            UpdateAppearance(horizontalInput, xVelocity);
            grounded = IsGrounded();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Hazard"))
            {
                anim.SetBool("isHurt", true);
            }
        }

        /// <summary>
        /// Keeps player velocity under the max, and forces small values down to zero for a nice crisp stop.
        /// </summary>
        void ClampVelocity(float horizInput, float xVel)
        {
            if (Mathf.Abs(xVel) > maxHorizontalVelocity)
            {
                rb2d.velocity = new Vector2(maxHorizontalVelocity * Mathf.Sign(horizInput), rb2d.velocity.y);
            }
            if (Mathf.Abs(horizontalInput) < 0.2)
            {
                rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            }
        }

        /// <summary>
        /// Makes the sprite face left/right and sends velocity to the animator (so it can show standing or walking).
        /// </summary>
        void UpdateAppearance(float horizInput, float xVel)
        {
            if (horizInput >= 0 && spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }
            else if (horizInput < 0 && !spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }

            anim.SetFloat("absXVelocity", Mathf.Abs(xVel));

        }

        /// <summary>
        /// Sends raycasts downward to determine whether player is standing on  something in the "Ground" layer.Uses two so player can dangle off the edge of platforms, arcade style.
        /// </summary>
        bool IsGrounded()
        {
            groundCheckBounds = groundCheckCollider.bounds;
            toesYPos = groundCheckBounds.min.y;

            leftToeWorldPos = new Vector3(groundCheckBounds.min.x, toesYPos);
            leftToeRaycast = Physics2D.Raycast(leftToeWorldPos, Vector3.down, groundCheckDist, LayerMask.GetMask("Ground"));
            Debug.DrawRay(leftToeWorldPos, Vector3.down * groundCheckDist, Color.red);
            if (leftToeRaycast.collider != null)
            {
                return true;
            }

            rightToeWorldPos = new Vector3(groundCheckBounds.max.x, toesYPos);
            rightToeRaycast = Physics2D.Raycast(rightToeWorldPos, Vector3.down, groundCheckDist, LayerMask.GetMask("Ground"));
            Debug.DrawRay(rightToeWorldPos, Vector3.down * groundCheckDist, Color.red);
            if (rightToeRaycast.collider != null)
            {
                return true;
            }

            return false;

        }

    }
}