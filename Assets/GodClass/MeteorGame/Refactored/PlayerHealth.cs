using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodClass.Refactored {

    /* In this cleaned-up version of the Player class
     * there's a lot more going on. It handles collisions
     * and health just like the original class, but I've added a few
     * more features, like a simple health bar. Once again, imagine
     * if you had to copy all of this code into every level of the
     * original Game Manager class.
     * 
     * I've also renamed it PlayerHealth to represent exactly 
     * what it's doing.
     */

    public class PlayerHealth : MonoBehaviour {

        [SerializeField]
        int health = 10;

        int initialHealth = 10;
        int meteorDamage = 3;

        GameManager theGameManagerScript;
        GameObject damageOverlay;
        ParticleSystem sparks;

        GameObject healthBar;
        RectTransform healthBarTransform;
        float healthBarInitWidth;
        float healthBarWidth;

        void Start() {
            theGameManagerScript = FindObjectOfType<GameManager>();

            //GameObject.Find is usually not the best way to get a reference
            //to something. In the next iteration/cleanup this would probably change.
            healthBar = GameObject.Find("Health Bar");
            sparks = gameObject.transform.Find("Sparks").GetComponent<ParticleSystem>();

            healthBarTransform = healthBar.GetComponent<RectTransform>();
            healthBarInitWidth = healthBarTransform.rect.width;

            damageOverlay = gameObject.transform.Find("Damage Overlay").gameObject;

        }

        void OnCollisionEnter2D(Collision2D collision) {
            //Debug.Log("collided with " + collision.gameObject.name);
            Destroy(collision.gameObject);
            health -= meteorDamage;
            sparks.Play();

            healthBarWidth = ((float)health / initialHealth) * healthBarInitWidth;
            healthBarTransform.SetSizeWithCurrentAnchors(
                RectTransform.Axis.Horizontal,
                healthBarWidth
            );

            if (health <= 0) {
                theGameManagerScript.GameOver();
            } else if (health <= 5) {
                damageOverlay.SetActive(true);
            }

        }
    }
}

