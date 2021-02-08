using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountdownTimer {

    /*
     * 
     * This is a simple approach to showing a countdown timer. It is able to
     * show 3... 2... 1... GO! at 1-second intervals when it is attached to 
     * a game object with a Text component.
     * 
     * Like every solution you might come up with, it has advantages and
     * disadvantages.
     * Advantages:
     *      WORKS
     *      Relatively easy to write
     *      Reasonably clear what it's doing and how
     * 
     * Disadvantages:
     *      Could be clearer; looks like it's counting in the opposite
     *          direction of what it's actually doing
     *      Only knows how to count down from 3
     *      Once it gets to "GO!" it will keep re-setting the
     *          text to "GO!" every frame forever
     */
    public class CountdownTimer : MonoBehaviour {

        Text textComponent;
        float whenToShow2 = 1f;
        float whenToShow1 = 2f;
        float whenToShowGo = 3f;
        float timeSinceCountdownStarted;

        void Start() {
            textComponent = gameObject.GetComponent<Text>();
            textComponent.text = "3...";
        }

        void Update() {

            timeSinceCountdownStarted += Time.deltaTime;

            if (timeSinceCountdownStarted > whenToShowGo) {
                textComponent.text = "GO!";
            } else if (timeSinceCountdownStarted > whenToShow1) {
                textComponent.text = "1...";
            } else if (timeSinceCountdownStarted > whenToShow2) {
                textComponent.text = "2...";
            }

        }
    }
}
