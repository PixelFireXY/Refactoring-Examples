using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodClass.Original {

    /* This is the stub of a player class before cleaning up.
     * In this setup it doesn't have a lot to do, because 
     * everything's in the GameManager script.
     */

    public class Player : MonoBehaviour {

        public int health = 10;
        int meteorDamage = 3;

        void Start() {
        }

        void Update() {
        }

        void OnCollisionEnter2D(Collision2D collision) {
            print("collided with " + collision.gameObject.name);
            Destroy(collision.gameObject);
            health = health - meteorDamage;
        }
    }
}