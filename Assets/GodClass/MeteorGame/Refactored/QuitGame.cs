using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodClass.Refactored {

    /* This seems like it belongs in the GameManager. It's in its 
     * own class here because
     * 
     * (1) I want to be able to use it in both the game scene 
     *      and the restart-game scene, but
     * (2) I don't need the whole GameManager script in the
     *      restart-game scene.
     */

    public class QuitGame : MonoBehaviour {

        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }
    }
}