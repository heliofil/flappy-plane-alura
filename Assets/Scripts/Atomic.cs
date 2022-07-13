using System.Collections;
using UnityEngine;

public class Atomic {
    
    public class PlayerOne {

        private static PlayerController instance = null;
        public static PlayerController GetInstance() {
            if(instance == null) {
                instance = GameObject.FindWithTag(Utils.PLAYER_TAG).GetComponent<PlayerController>();
            }

            return instance;
        }


        public class Plane:MonoBehaviour {
            private static PlaneController instance = null;
            public static PlaneController GetInstance() {
                if(instance == null) {
                    instance = GameObject.FindWithTag(Utils.PLANE_TAG).GetComponent<PlaneController>();
                }

                return instance;
            }

        }
        public class BarriersGenerator:MonoBehaviour {

            private static BarriersGeneratorController instance = null;

            public static BarriersGeneratorController GetInstance() {
                if(instance == null) {
                    instance = GameObject.FindWithTag(Utils.BARRIERS_GENERATOR_TAG).GetComponent<BarriersGeneratorController>();
                }

                return instance;

            }
        }

    }

    public class PlayerTwo {

        private static PlayerController instance = null;
        public static PlayerController GetInstance() {
            if(instance == null) {
                instance = GameObject.FindWithTag(Utils.PLAYER2_TAG).GetComponent<PlayerController>();
            }

            return instance;
        }


        public class Plane:MonoBehaviour {
            private static PlaneController instance = null;
            public static PlaneController GetInstance() {
                if(instance == null) {
                    instance = GameObject.FindWithTag(Utils.PLANE2_TAG).GetComponent<PlaneController>();
                }

                return instance;
            }

        }

        public class BarriersGenerator:MonoBehaviour {

            private static BarriersGeneratorController instance = null;

            public static BarriersGeneratorController GetInstance() {
                if(instance == null) {
                    instance = GameObject.FindWithTag(Utils.BARRIERS_GENERATOR2_TAG).GetComponent<BarriersGeneratorController>();
                }

                return instance;

            }
        }

    }
    public class UI:MonoBehaviour {
        private static UIController instance = null;
        public static UIController GetInstance() {
            if(instance == null) {
                instance = FindObjectOfType<UIController>();
            }

            return instance;

        }
    }

    public class StopPlayer:MonoBehaviour {
        private static StopPlayerController instance = null;
        public static StopPlayerController GetInstance() {
            if(instance == null) {
                instance = FindObjectOfType<StopPlayerController>();
            }

            return instance;

        }
    }


}

