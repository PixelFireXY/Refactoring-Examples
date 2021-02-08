using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountdownTimer {

    /*
     * Here is a somewhat more powerful approach to showing a
     * countdown timer. It is able to show any series of strings
     * at any interval. This is an example of rewriting code to
     * make it more abstract and flexible.
     * 
     * Advantages:
     *      WORKS
     *      More flexible
     *      Reasonably clear what it's doing and how
     *      Turns itself off when it's done
     * 
     * Disadvantages:
     *      A little harder to write
     *      A little harder to read, if you're not familiar with arrays
     * 
     */

    public class CountdownTimerBetter : MonoBehaviour {

        Text textComponent;
        float howManySecondsToShowText = 1f;
        float howLongTextHasShown = 0f;

        //this is how you create an array with an initial set of values. Depending
        //on how this script will be used, you could instead make this array public 
        //so that you could type these strings directly in the Inspector in the Unity editor.
        string[] countdownStages = { "5...", "4...", "3...", "2...", "1...", "GO!" };
        int currentStageIndex = 0;

        void Start() {
            textComponent = gameObject.GetComponent<Text>();
            textComponent.text = countdownStages[currentStageIndex];
        }

        void Update() {

            howLongTextHasShown += Time.deltaTime;

            if (howLongTextHasShown > howManySecondsToShowText) {
                //add one to currentStageIndex
                currentStageIndex++;
                //then immediately check that we haven't gone past the end of the 
                //array, e.g. looking for the seventh element in an array that only
                //has six strings
                if (currentStageIndex >= countdownStages.Length) {
                    //if we are at the end of the array, turn off this script, 
                    //since it's finished doing its thing
                    this.enabled = false;
                } else {
                    //otherwise, use the new value of currentStageIndex to get the 
                    //next string
                    textComponent.text = countdownStages[currentStageIndex];
                    //and reset the timer
                    howLongTextHasShown = 0f;
                }
            }

        }
    }
}