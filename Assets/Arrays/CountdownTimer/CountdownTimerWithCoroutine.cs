using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountdownTimer {

    /*
     * This is the more "Unity-native" way to do something on a specific
     * time interval, using a code structure called coroutines. Coroutines
     * are powerful but not very beginner-friendly. This is a nice simple
     * working example when you are ready to learn about them.
     * 
     * Coroutines only run when they're needed, rather than every frame like
     * things you do in Update.
     * 
     * Extra stuff in your Update methods can make your game run more slowly.
     * Coroutines can help you speed things up. But beginners should not worry about
     * optimization – your goal is working, legible code.
     * 
     * Advantages:
     *      A little faster
     *      Doesn't clutter up Update method
     * 
     * Disadvantages:
     *      Much harder to write
     *      Much harder to read, unless you are familiar with coroutines
     *      More bug-prone because it's harder to read
     * 
     */

    public class CountdownTimerWithCoroutine : MonoBehaviour {

        Text textComponent;
        float howManySecondsToShowText = 1f;
        string[] countdownStages = { "5...", "4...", "3...", "2...", "1...", "GO!" };
        int currentStageIndex = 0;
        bool keepRunningCountdown = true;

        Coroutine updateText;

        void Start() {
            textComponent = gameObject.GetComponent<Text>();
            StartCoroutine(UpdateText());
        }

        void Update() {
            //this code pauses the timer. Can you figure out how to
            //restart it at "5..."?
            if (Input.GetKeyDown(KeyCode.Space)) {
                keepRunningCountdown = !keepRunningCountdown;
                if (keepRunningCountdown) {
                    StartCoroutine(UpdateText());
                }
            }
        }

        IEnumerator UpdateText() {
            while (keepRunningCountdown) {

                //this line is what creates the pause between each number.
                //using "yield return" is also why this function needs to have
                //the special IEnumerator return type.
                yield return new WaitForSeconds(howManySecondsToShowText);

                //Everything after WaitForSeconds doesn't happen until the
                //delay is over, that is, the game has waited for 
                //howManySecondsToShowText seconds.
                currentStageIndex++;
                if (currentStageIndex >= countdownStages.Length) {
                    //when we have shown all of the strings, turn the script
                    //off. The last text shown ("GO!") will stay on screen.
                    this.enabled = false;
                } else {
                    textComponent.text = countdownStages[currentStageIndex];
                }
            }
        }

    }
}