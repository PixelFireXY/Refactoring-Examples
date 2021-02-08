using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GodClass.Refactored {

    public class RestartGame : MonoBehaviour {

        [SerializeField]
        KeyCode restartKey;

        void Update() {
            if (Input.GetKeyDown(restartKey)) {
                SceneManager.LoadScene("RefactoredLevel1");
            }
        }
    }
}