using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions {

    /*
     * This version might be what you have after some cleanup.
     * 
     *    -All the hard-coded numbers are now stored in variables,
     *     so their meaning is clear.
     *    -Most of the values used in raycasting have also been 
     *     extracted into variables with descriptive names.
     *    -The raycasting code is now using the built-in
     *     Vector3.down instead of (0,-1,0) since its meaning
     *     is clearer.
     * 
     * Overall, the code is more legible. But FixedUpdate is now
     * 30+ lines long, and it's doing a lot of different things – 
     * raycasting, applying jump, clamping velocity and more.
     * If you were to go on and add animation, walking on slopes, 
     * crouching, double jump, wall climb, etc., FixedUpdate would 
     * get really long, and really hard to work with.
     * 
     * Take a look at
     *     PlayerMovementWithFunctions.cs
     * for an improved version.
     * 
     */

    public class PlayerMovementBetterVariables : MonoBehaviour {

        public float moveForce = 80f;
        public float jumpForce = 800f;
        public float groundCheckDist = .05f;
        public float maxHorizontalVelocity = 15f;
        public float minHorizontalVelocity = .01f;


        Collider2D groundCheckCollider;
        Bounds groundCheckBounds;
        Animator anim;
        Rigidbody2D rb2d;

        float horizontalInput;
        bool grounded = true;
        bool willJump = false;

        float toesYPos;
        Vector3 leftToeWorldPos;
        Vector3 rightToeWorldPos;
        RaycastHit2D leftToeRaycast;
        RaycastHit2D rightToeRaycast;

        void Awake() {
            anim = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            groundCheckCollider = transform.Find("GroundsCheck").GetComponent<Collider2D>();
        }

        void Update() {
            anim.SetBool("isGrounded", grounded);
            if (Input.GetButtonDown("Jump") && grounded) {
                willJump = true;
            }
        }

        void FixedUpdate() {
            if (willJump) {
                anim.SetBool("isGrounded", false);
                rb2d.AddForce(new Vector2(0f, jumpForce));
                willJump = false;
            }

            horizontalInput = Input.GetAxis("Horizontal");
            rb2d.AddForce(Vector3.right * horizontalInput * moveForce * rb2d.mass, ForceMode2D.Impulse);
            if (Mathf.Abs(horizontalInput) < minHorizontalVelocity) {
                rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            }
            if (Mathf.Abs(rb2d.velocity.x) > maxHorizontalVelocity) {
                rb2d.velocity = new Vector2(maxHorizontalVelocity * Mathf.Sign(horizontalInput), rb2d.velocity.y);
            }

            groundCheckBounds = groundCheckCollider.bounds;
            toesYPos = groundCheckBounds.min.y;

            leftToeWorldPos = new Vector3(groundCheckBounds.min.x, toesYPos);
            leftToeRaycast = Physics2D.Raycast(leftToeWorldPos, Vector3.down, groundCheckDist);
            Debug.DrawRay(leftToeWorldPos, Vector3.down * groundCheckDist, Color.red);
            if (leftToeRaycast.collider != null) {
                grounded = true;
            } else {
                rightToeWorldPos = new Vector3(groundCheckBounds.max.x, toesYPos);
                rightToeRaycast = Physics2D.Raycast(rightToeWorldPos, Vector3.down, groundCheckDist);
                Debug.DrawRay(rightToeWorldPos, Vector3.down * groundCheckDist, Color.red);
                if (rightToeRaycast.collider != null) {
                    grounded = true;
                    //Debug.Log(rightToeRaycast.collider.name);
                } else {
                    grounded = false;
                }
            } 
        }


    }
}