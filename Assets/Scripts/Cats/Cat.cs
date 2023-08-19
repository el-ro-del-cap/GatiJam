using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class Cat : MonoBehaviour {

    public event PositionDelegate DestinationReached;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
    }

    public float MaxPatience = 100;
    public float patienceModifier = 5;
    [Space]
    public FoodType[] foods;
    [Space]
    public float movementSpeed;

    private Vector3 moveStart;
    private Vector3 moveDestination;

    public void MoveCat(Vector3 destination) {
    }

    private IEnumerator MovementCR(Vector3 destination) {
        // Work in progress
        moveStart = transform.position;
        moveDestination = destination;
        yield return null;
    }

    /// <summary>
    /// Retorna True si la pila de comida dada tiene la misma comida que pide este gato, retorna False si la pila de comida no contiene elementos que pide el gato o es de otro tamaño
    /// </summary>
    /// <param name="foodPile">Array de comida a chequear</param>
    /// <returns></returns>
    public bool FoodValid(FoodType[] foodPile) {
        if (foodPile.Length != foods.Length) {
            return false;
        }
        foreach (FoodType reqFood in foods) {
            if (!foodPile.Contains(reqFood)) {
                return false;
            }
        }
        return true;
    }


}
