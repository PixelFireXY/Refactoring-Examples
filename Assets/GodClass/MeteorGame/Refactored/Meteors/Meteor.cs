using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodClass.Refactored {

    /* This script moves the meteor at a constant speed and
     * in a single direction, like the original GameManager class
     * did. If you apply it to all of your meteors,
     * you'll get the same behavior from all of them.
     * 
     * Like the original GameManager class, this script also doesn't
     * instantiate new meteors – it just moves any that are already
     * in the scene and have this script attached when you press Play.
     * 
     * This script is just for illustration – it would be the first step
     * in a refactoring of the god class. But you can do better. See the 
     * MeteorFactory class for a more flexible and interesting approach.
     */

    public class Meteor : MonoBehaviour {

        Rigidbody2D rb2D;
        Vector2 movement = new Vector2(2f, -3f);

        void Start() {
            rb2D = GetComponent<Rigidbody2D>();
            rb2D.velocity = movement;
        }

    }

}