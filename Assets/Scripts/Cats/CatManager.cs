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


    List<CatSpawn> catSpawns;
    List<CatDestination> catDestinations;
    List<CatDestination> emptyDestinations;
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
        UpdateDestinations();
    }


    // Start is called before the first frame update
    void Start() {
        


    }

    // Update is called once per frame
    void Update() {



    }

    void UpdateDestinations() {
        emptyDestinations = new List<CatDestination>();
        foreach (CatDestination cd in catDestinations) { 
            if (cd.currentCat == null) {
                emptyDestinations.Add(cd);
            }
        }
    }

    [ContextMenu("Spawn Cat")]
    public void SpawnCat() {
        if (emptyDestinations.Count < 1) {
            UpdateDestinations();
            if (emptyDestinations.Count < 1) {
                Debug.Log("Se intentó crear un gato, no hay más espacio para gatos");
                return;
            }
        }
        GameObject catPrefab = CatPrefabManager.Instance.GetRandomCat();
        if (catPrefab == null) {
            Debug.LogError("Error creando gato, prefab no encontrado");
            return;
        }
        int randStart = Random.Range(0, catSpawns.Count);
        int randEnd = Random.Range(0, emptyDestinations.Count);
        GameObject newCatObj = GameObject.Instantiate(catPrefab, catSpawns[randStart].transform.position, catPrefab.transform.rotation);
        Cat newCat = newCatObj.GetComponent<Cat>();
        currentCats.Add(newCat);
        newCat.MoveCat(emptyDestinations[randEnd].transform.position);
        emptyDestinations[randEnd].currentCat = newCat;
        UpdateDestinations();
    }

    public static void RemoveCatFromList(Cat toRemove) {
        Instance.currentCats.Remove(toRemove); 
        Instance.UpdateDestinations();
    }

    public static void AddSpawn(CatSpawn toAdd) {
        Instance.catSpawns.Add(toAdd);
    }

    public static void AddDestination(CatDestination toAdd) {
        Instance.catDestinations.Add(toAdd);
        Instance.UpdateDestinations();
    }


}
