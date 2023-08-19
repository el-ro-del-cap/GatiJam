using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        CatManager.AddSpawn(this);
    }
}
