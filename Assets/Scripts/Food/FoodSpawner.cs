using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject spawneePrefab;
    public Transform spawnParent;
    GameObject foodBowl;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (foodBowl == null) {
            foodBowl = GameObject.Instantiate(spawneePrefab, spawnParent); //Crea el bowl en el parent de este spawner
            foodBowl.transform.position = transform.position;
        }
    }
}
