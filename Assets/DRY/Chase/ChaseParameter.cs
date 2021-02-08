using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DRY {
    public class ChaseParameter : MonoBehaviour {

        GameObject currentTarget;
        float speed = 2f;
        Rigidbody2D rb;
        Vector2 directionToTarget, step, newPosition;
        float accuracy = .1f;

        void Start() {
            rb = GetComponent<Rigidbody2D>();
            currentTarget = GameObject.Find("Player");
        }

        void FixedUpdate() {
            ChaseTarget(currentTarget);
        }

        /* This is a more flexible version that can chase whatever it's told to.
         * 
         * It's also been optimized a little - it's not using GameObject.Find and
         * all the local variables (step, newPosition, and so on) have been moved 
         * up to the class level.
         * 
         * It's debatable whether that is good programming style, since the variables are
         * really only used in this one function, but it is a common and simple 
         * optimization for a function like this that is called several times per frame.
         */

        void ChaseTarget(GameObject target) {
            directionToTarget = target.transform.position - transform.position;
            Debug.DrawRay(transform.position, directionToTarget, Color.blue);
            if (directionToTarget.magnitude > accuracy) {
                step = directionToTarget.normalized * speed * Time.deltaTime;
                newPosition = (Vector2)transform.position + step;
                rb.MovePosition(newPosition);
            }
        }

        /* This is the function that you could call from other classes to change
         * the target.
         */
        public void SetTarget(GameObject target) {
            currentTarget = target;
        }

    }
}
