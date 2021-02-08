using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions {

    /* Here is a rough draft of a simple character controller. Besides
     * missing some big features, it has some bugs - play for a while
     * and you'll see some of them.
     * 
     * Imagine if you had to debug this code! Then look at
     *     PlayerMovementBetterVariables.cs 
     * for a somewhat improved, more readable version.    
     */

    public class PlayerMovementOriginal : MonoBehaviour {

        Collider2D check;
        Bounds bounds;
        Animator anim;
        Rigidbody2D rb2d;

        Vector3 rayPos;
        RaycastHit2D ray;
        bool grounded = true;
        bool jump = false;

        void Awake() {
            anim = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            check = transform.Find("GroundsCheck").GetComponent<Collider2D>();
        }

        void Update() {
            if (Input.GetButtonDown("Jump") && grounded) {
                jump = true;
            }
        }

        void FixedUpdate() {
            if (jump) {
                anim.SetBool("isGrounded", false);
                rb2d.AddForce(new Vector2(0f, 800f));
                jump = false;
            }
            anim.SetBool("isGrounded", grounded);
            rb2d.AddForce(Vector3.right * Input.GetAxis("Horizontal"), ForceMode2D.Impulse);
            if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f) {
                rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            }
            grounded = false;
            bounds = check.bounds;
            rayPos = new Vector3(bounds.min.x, bounds.min.y);
            ray = Physics2D.Raycast(rayPos, new Vector3(0, -1, 0), .05f);
            Debug.DrawRay(rayPos, new Vector3(0, -1, 0) * .05f, Color.red);
            if (ray.collider != null) {
                grounded = true;
            } else {
                rayPos = new Vector3(bounds.max.x, bounds.min.y);
                ray = Physics2D.Raycast(rayPos, new Vector3(0, -1, 0), .05f);
                Debug.DrawRay(rayPos, new Vector3(0, -1, 0) * .05f, Color.red);
                if (ray.collider != null) {
                    grounded = true;
                }
            }
        }


    }
}