using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariableNames.TooVague {

    public class PowerUp : MonoBehaviour {

        SpriteRenderer spriteRenderer;

        void Awake() {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        void Update() {
            RotatePowerUp(3f);
        }

        /* This is an example of the kind of bug you can get from
         * vague variable names.
         * 
         * I've used "rotation" first to mean "how much to rotate"
         * and then to mean "how much I have rotated".
         * 
         * This code will run, but it won't do what I wanted.
         */

        void RotatePowerUp(float rotation) {
            //rotate the object
            gameObject.transform.Rotate(0f, rotation, 0f);

            //pulse the color
            if (rotation >= 45f && rotation <= 135f) {
                spriteRenderer.color = Color.red;
            } else {
                spriteRenderer.color = Color.white;
            }
        }

    }
}