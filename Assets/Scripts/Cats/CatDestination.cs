using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDestination : MonoBehaviour {
    public Cat currentCat;
    // Start is called before the first frame update
    void Start() {
        CatManager.AddDestination(this);
    }
}
