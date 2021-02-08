using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariableNames.Misnamed {

    /* Part of a class that used to crank out ghosts but now
     * makes zombies.
     * 
     * You would never write this code on purpose – this 
     * is what it might look like if you decided to
     * make all your ghosts into zombies but didn't finish
     * renaming your variables.
     * 
     * This code would still run, but it's pretty hard to read it
     * and see what it's doing.
     */

    public class ZombieFactory : MonoBehaviour {

        public Zombie zombiePrefab;
        public int maxDecayLevel;

        void Start() {
        }

        void Update() {
        }

        void InstantiateZombies(int ghostCount) {
            for (int i = 0; i < ghostCount; i++) {
                Zombie newGhost = Instantiate(zombiePrefab);
                newGhost.decayLevel = Random.Range(0, maxDecayLevel);
                newGhost.SetRandomMissingPart();
            }
        }
    }
}