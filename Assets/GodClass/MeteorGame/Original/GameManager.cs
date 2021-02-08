using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GodClass.Original {

    /* This is an example of a god class – one script
     * controlling literally everything in the game. It's
     * an extreme/exaggerated example meant to illustrate
     * problems with copying and pasting code.
     * 
     * See the "Refactored" folder for a cleaner approach, where
     * the behavior of each object (player, meteors, the game itself)
     * has its own class.
     */

    public class GameManager : MonoBehaviour {

        public string currentSceneName;
        public GameObject player;
        GameObject damageOverlay;
        public GameObject[] grayMeteors;
        public GameObject[] brownMeteors;


        void Start() {
            DontDestroyOnLoad(gameObject);
            damageOverlay = player.transform.Find("Damage Overlay").gameObject;
        }

        void Update() {
            switch (currentSceneName) {
                case "GodClassLevel1": {
                        grayMeteors = GameObject.FindGameObjectsWithTag("MeteorGrey");
                        for (int i = 0; i < grayMeteors.Length; i++) {
                            GameObject meteor = grayMeteors[i];
                            meteor.transform.position += new Vector3(.02f, -.03f, 0f);
                        }
                        brownMeteors = GameObject.FindGameObjectsWithTag("MeteorBrown");
                        for (int i = 0; i < brownMeteors.Length; i++) {
                            GameObject meteor = brownMeteors[i];
                            meteor.transform.position += new Vector3(-.06f, -.04f, 0f);
                        }

                        if (player.GetComponent<Player>().health <= 0) {
                            Destroy(player);
                            currentSceneName = "GameOver";
                            SceneManager.LoadScene("GameOver");
                        } else if (player.GetComponent<Player>().health <= 5) {
                            damageOverlay.SetActive(true);
                        }

                        //figure out how player gets to level 2

                        break;
                    }
                case "GodClassLevel2": {
                        grayMeteors = GameObject.FindGameObjectsWithTag("MeteorGrey");
                        for (int i = 0; i < grayMeteors.Length; i++) {
                            GameObject meteor = grayMeteors[i];
                            meteor.transform.position += new Vector3(.02f, -.03f, 0f);
                        }
                        brownMeteors = GameObject.FindGameObjectsWithTag("MeteorBrown");
                        for (int i = 0; i < brownMeteors.Length; i++) {
                            GameObject meteor = brownMeteors[i];
                            meteor.transform.position += new Vector3(-.06f, -.04f, 0f);
                        }

                        //add UFOs here

                        if (player.GetComponent<Player>().health <= 0) {
                            currentSceneName = "GameOver";
                            Destroy(player);
                            SceneManager.LoadScene("GameOver");
                        } else if (player.GetComponent<Player>().health <= 5) {

                            damageOverlay.SetActive(true);
                        }
                        break;
                    }
                case "GameOver": {
                        if (Input.GetKeyDown(KeyCode.Escape)) {
                            Application.Quit();
                        }
                        break;
                    }
            }

        }
    }
}