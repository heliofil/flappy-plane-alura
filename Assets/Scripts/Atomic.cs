using System.Collections;
using UnityEngine;

public class Atomic {

    public class PlayerOne {

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





}

