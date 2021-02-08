using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DRY {

    public class BlinkParameter : MonoBehaviour {

        [SerializeField]
        Color red;
        int redColorCode = 0;

        [SerializeField]
        Color blue;
        int blueColorCode = 1;

        bool isBlinking = false;

        Image playerImage;

        void Awake() {
            playerImage = GetComponent<Image>();
        }

        /* This is the same function with more improvements:
         *  it can blink between any two colors, at any rate,
         *    for any number of blinks
         *  it sets a boolean to keep track of whether it's
         *    already blinking, so you won't get weird
         *    overlapping blinks
         * 
         * See https://docs.unity3d.com/ScriptReference/MonoBehaviour.StopCoroutine.html to
         * learn how to interrupt a coroutine on purpose.
         */

        public IEnumerator Blink(Color onColor, Color offColor, float waitTime, int numberOfBlinks) {
            isBlinking = true;
            for (int i = 0; i < numberOfBlinks; i++) {
                playerImage.color = onColor;
                yield return new WaitForSeconds(waitTime);
                playerImage.color = offColor;
                yield return new WaitForSeconds(waitTime);
            }
            isBlinking = false;
        }

        
        /* This (along with the buttons in the UI) is just a way to test the function above.
         * The "color codes" have no particular meaning.
         */

        public void TestBlink(int colorCode) {
            if (!isBlinking) {
                if (colorCode == redColorCode) {
                    StartCoroutine(Blink(red, Color.white, .4f, 4));
                } else if (colorCode == blueColorCode) {
                    StartCoroutine(Blink(blue, Color.white, .2f, 6));
                }
            }
        }
    }
}