using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VariableNames.TooConcrete {

    public class CountdownTimer : MonoBehaviour {

        /*
         * This is what it might look like if you wrote a script
         * to show "3...2...1...GO!" on the screen before a race.
         * 
         * It works, but it can only do one thing, and it's not
         * very easy to tell what's going on. See the "Arrays" 
         * folder for possible improvements.
         */


        Text textComponent;
        string three = "3...";
        string two = "2...";
        string one = "1...";
        string go = "GO!";

        float whenToShowText1 = 1f;
        float whenToShowText2 = 2f;
        float whenToShowText3 = 3f;
        float whenToShowText4 = 4f;

        float timeSinceCountdownStarted;

        void Start() {
            textComponent = gameObject.GetComponent<Text>();
            textComponent.text = three;
        }

        void Update() {

            timeSinceCountdownStarted += Time.deltaTime;

            if (timeSinceCountdownStarted > whenToShowText4) {
                textComponent.text = go;
            } else if (timeSinceCountdownStarted > whenToShowText3) {
                textComponent.text = one;
            } else if (timeSinceCountdownStarted > whenToShowText2) {
                textComponent.text = two;
            } else if (timeSinceCountdownStarted > whenToShowText1)
            {
                textComponent.text = three;
            }

        }
    }
}
