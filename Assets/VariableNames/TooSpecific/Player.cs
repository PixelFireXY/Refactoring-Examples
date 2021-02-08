using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VariableNames.TooSpecific {

    public class Player : MonoBehaviour {

        int health = 10;

        /*
         * Unity fills in the Collision2D parameter with info about
         * whatever happened to hit this GameObject, which could be a
         * lot of different things – like enemies, powerups, etc. in a 
         * space shooter. So it's best to give the parameter a more
         * general name like "collision" – that way you'll know that 
         * you need to check what it is before you do anything with it.
         */

        void OnCollisionEnter2D(Collision2D collision) {
            //first check if it's an enemy
            if (collision.gameObject.CompareTag("Enemy")) {
                health = health - 3;
            
            //if it's not an enemy, see if it's a powerup
            } else if (collision.gameObject.CompareTag("PowerUp")) {
                PowerUp collectedPowerUp = collision.gameObject.GetComponent<PowerUp>();
                ActivatePowerUp(collectedPowerUp);
            }
            Destroy(collision.gameObject);
        }

        void ActivatePowerUp(PowerUp powerUp) {
        }


        /* Imagine you wrote this code instead.
         */
        void BadOnCollisionEnter2D(Collision2D enemy) {
            health = health - 3;
            Destroy(enemy.gameObject);
        }
        /*
         * It's easy to see what would happen if the player
         * collides with an enemy. But what would happen if
         * the player collided with a powerup?
         * 
         * You might update your code like this:
         */

        void WorseOnCollisionEnter2D(Collision2D enemy) {
            if (enemy.gameObject.CompareTag("Enemy")) {
                health = health - 3;
                Destroy(enemy.gameObject);
            } else if (enemy.gameObject.CompareTag("PowerUp")) {

                //but this line becomes really confusing. Is it an enemy
                //or a powerup? Why would an enemy have a PowerUp script?
                PowerUp collectedPowerUp = enemy.gameObject.GetComponent<PowerUp>();
                ActivatePowerUp(collectedPowerUp);
            }
        }

    }
}