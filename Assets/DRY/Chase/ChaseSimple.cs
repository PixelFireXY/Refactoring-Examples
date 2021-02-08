using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DRY {
    public class ChaseSimple : MonoBehaviour {

        float speed = 2f;
        Rigidbody2D rb;
        float accuracy = .1f;

        void Start() {
            rb = GetComponent<Rigidbody2D>();
        }


        void FixedUpdate() {
            ChasePlayer();
        }

        /* This is how you might write this function the first time,
         * just to get it working. It has several issues, including calling
         * GameObject.Find every frame, which will slow down your game.
         */

        void ChasePlayer() {
            GameObject player = GameObject.Find("Player");
            Vector2 directionToTarget = player.transform.position - transform.position;
            Debug.DrawRay(transform.position, directionToTarget, Color.green);
            if (directionToTarget.magnitude > accuracy) {
                Vector2 step = directionToTarget.normalized * speed * Time.deltaTime;
                Vector2 newPosition = (Vector2)transform.position + step;
                rb.MovePosition(newPosition);
            }
        }

    }
}
