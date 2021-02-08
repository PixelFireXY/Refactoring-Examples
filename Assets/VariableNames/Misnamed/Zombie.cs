using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariableNames.Misnamed {

    /* Part of a Zombie class, showing the sorts of things
     * a zombie might do that are noticeably different
     * from ghosts.
     */

    public class Zombie : MonoBehaviour {

        public enum BodyPart {
            Head,
            LeftArm,
            RightArm,
            LeftLeg,
            RightLeg,
            Torso,
            COUNT
        }

        public float decayLevel;
        public List<BodyPart> missingParts;

        void Awake() {
            SetRandomMissingPart();
        }

        void Update() {
        }

        public void SetRandomMissingPart() {
            missingParts = new List<BodyPart>() { ChooseRandomPart() };
        }

        BodyPart ChooseRandomPart() {
            BodyPart randomPart = (BodyPart)Random.Range(0, (int)BodyPart.COUNT);
            //Debug.Log(randomPart.ToString());
            return randomPart;
        }
    }
}