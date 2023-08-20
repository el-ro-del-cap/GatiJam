using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSingleton : MonoBehaviour {

    public Canvas canvas;

    private static CanvasSingleton _instance;
    public static CanvasSingleton Instance {
        get {
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
    }
}
