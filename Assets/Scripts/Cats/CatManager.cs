using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour {

    private static CatManager _instance;
    public static CatManager Instance {
        get {
            return _instance;        
        }
    }

    public GameObject catPrefab;

    List<CatSpawn> catSpawns;
    List<CatDestination> catDestinations;
    List<Cat> currentCats;

    private void Awake() {
        if (_instance == null) {
            _instance = this;
        } else {
            Debug.LogError("Ya hay un un manager de gatos, no creen otro");
            Destroy(this);
        }
        catSpawns = new List<CatSpawn>();
        catDestinations = new List<CatDestination>();   
        currentCats = new List<Cat>();

    }


    // Start is called before the first frame update
    void Start() {
        


    }

    // Update is called once per frame
    void Update() {



    }

    [ContextMenu("Spawn Cat")]
    public void SpawnCat() {
        int randStart = Random.Range(0, catSpawns.Count);
        int randEnd = Random.Range(0, catDestinations.Count);
        GameObject newCatObj = GameObject.Instantiate(catPrefab, catSpawns[randStart].transform.position, catPrefab.transform.rotation);
        Cat newCat = newCatObj.GetComponent<Cat>();
        currentCats.Add(newCat);
        newCat.MoveCat(catDestinations[randEnd].transform.position);
    }

    public void RemoveCatFromList(Cat toRemove) {
        currentCats.Remove(toRemove);
    }

    public static void AddSpawn(CatSpawn toAdd) {
        Instance.catSpawns.Add(toAdd);
    }

    public static void AddDestination(CatDestination toAdd) {
        Instance.catDestinations.Add(toAdd);
    }


}
