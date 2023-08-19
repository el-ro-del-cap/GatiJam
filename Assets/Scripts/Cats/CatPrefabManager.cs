using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPrefabManager : MonoBehaviour {

    private static CatPrefabManager _instance;
    public static CatPrefabManager Instance {
        get {
            return _instance;
        }
    }

    [SerializeField]
    public CatPrefabArray[] catArrays;

    private void Start() {
        if (_instance == null) {
            _instance = this;
        } else {
            Debug.LogError("Ya hay un un manager de prefabs de gatos, no creen otro");
            Destroy(this);
        }
    }





    public GameObject GetRandomCat() {
        int randArray = Random.Range(0, catArrays.Length);
        if (catArrays[randArray].variations.Length > 0) {
            int randCat = Random.Range(0, catArrays[randArray].variations.Length);
            return catArrays[randArray].variations[randCat];
        }
        return null;
    }

}

[System.Serializable]
public class CatPrefabArray {
    public string name;
    public GameObject[] variations;
}
