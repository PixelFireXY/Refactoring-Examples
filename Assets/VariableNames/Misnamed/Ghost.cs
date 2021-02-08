using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariableNames.Misnamed {

    /* Part of a Ghost class, showing the sorts of things
     * a ghost might do that are noticeably different
     * from zombies.
     */

    public class Ghost : MonoBehaviour {

        public float translucency;
        public float floatiness;
        public AudioClip wailingLow;
        public AudioClip wailingHigh;

        Vector2 waft;

        void Start() {
            StartCoroutine(Waft());
        }

        void Update() {
            transform.Translate(waft * floatiness / 100f);
        }

        public IEnumerator Waft() {
            while (true) {
                waft = Random.insideUnitCircle;
                yield return new WaitForSeconds(2f);
            }
        }
    }
}