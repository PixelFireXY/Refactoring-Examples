using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DRY {

    public class BlinkSimple : MonoBehaviour {

        Image playerImage;

        void Awake() {
            playerImage = GetComponent<Image>();
            StartCoroutine(Blink());
        }

        /* This is how you might write this function the
         * first time through, when you just want it to work.
         */

        IEnumerator Blink() {
            playerImage.color = new Color(1f, .5f, .5f);
            yield return new WaitForSeconds(.35f);
            playerImage.color = Color.white;
            yield return new WaitForSeconds(.35f);
            playerImage.color = new Color(1f, .5f, .5f);
            yield return new WaitForSeconds(.35f);
            playerImage.color = Color.white;
            yield return new WaitForSeconds(.35f);
            playerImage.color = new Color(1f, .5f, .5f);
            yield return new WaitForSeconds(.35f);
            playerImage.color = Color.white;
            yield return new WaitForSeconds(.35f);
            playerImage.color = new Color(1f, .5f, .5f);
            yield return new WaitForSeconds(.35f);
            playerImage.color = Color.white;
        }

    }
}