using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DRY {

    public class BlinkLoop : MonoBehaviour {

        Image playerImage;

        void Awake() {
            playerImage = GetComponent<Image>();
            StartCoroutine(Blink());
        }

        /* This is the same function with two improvements:
         *    the hard-coded colors and numbers are now variables
         *      (although the variables are still set here in the script)
         *    the repetitive code was turned into a for loop
         */

        IEnumerator Blink() {
            Color onColor = new Color(1f, .5f, .5f);
            float waitTime = 0.35f;
            int numberOfBlinks = 4;
            for (int i = 0; i < numberOfBlinks; i++) {
                playerImage.color = onColor;
                yield return new WaitForSeconds(waitTime);
                playerImage.color = Color.white;
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}