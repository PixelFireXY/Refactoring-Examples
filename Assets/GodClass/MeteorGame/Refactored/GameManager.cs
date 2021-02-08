using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GodClass.Refactored {

    /* This is the simplified GameManager class. It's only
     * responsible for stuff that affects the whole game,
     * like what level the player is on and whether the game is over.
     */

    public class GameManager : MonoBehaviour {

        //these variables are for illustration purposes
        enum GameMode {
            NORMAL,
            FRENZY
        }

        int currentLevel;
        GameMode gameMode;


        public void GameOver() {
            SceneManager.LoadScene("RefactoredGameOver");
        }

    }
}