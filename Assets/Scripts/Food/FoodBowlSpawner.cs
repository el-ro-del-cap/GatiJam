using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBowlSpawner : MonoBehaviour
{
    public GameObject foodBowlPrefab;
    public Canvas canvas;
    GameObject foodBowl;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (foodBowl == null) {
            foodBowl = GameObject.Instantiate(foodBowlPrefab, transform.parent); //Crea el bowl en el parent de este spawner
            foodBowl.transform.position = transform.position;
            foodBowl.GetComponent<DragDrop>().canvas = canvas;
        }
    }
}
