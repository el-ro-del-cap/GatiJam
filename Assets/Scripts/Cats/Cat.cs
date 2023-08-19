using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;

public class Cat : MonoBehaviour {

    public event PositionDelegate DestinationReached;
    public SpriteRenderer spriteRenderer;


    public float MaxPatience = 100;
    public float patienceModifier = 5;
    [Space]
    public FoodType[] foods;
    [Space]
    [SerializeField] AnimationCurve moveEasing;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    /// <summary>
    /// Tiempo que demora el gato en ir desde fuera de pantalla hasta destino
    /// </summary>
    public float speedUnitsPerSecond = 15f;
    /// <summary>
    /// Al ser menos de esta distancia warpea a la posición final
    /// </summary>
    public float minDistance = 0.01f;


    public void MoveCat(Vector3 destination) {
        StartCoroutine(MovementCR(destination));
    }

    private IEnumerator MovementCR(Vector3 destination) {
        yield return new WaitForSeconds(0.1f); //Si no hay espera hace cosas raras el sprite
        Debug.Log("test move");
        // Work in progress
        Vector3 moveStart = transform.position;
        float startTime = Time.time;
        float currentDistance = Vector3.Distance(moveStart, destination);
        float thisMoveTime = currentDistance / speedUnitsPerSecond;
        while (currentDistance > minDistance) {
            Debug.Log("inside: " + Time.time + " " + startTime);
            float normalizedProgress = (Time.time - startTime) / thisMoveTime;
            Debug.Log(normalizedProgress);
            if (normalizedProgress > 1) {
                break;
            }
            float easing = moveEasing.Evaluate(normalizedProgress);
            Debug.Log(easing);
            Vector3 oldPos = transform.position;
            Vector3 newPos = Vector3.Lerp(moveStart, destination, easing);
            transform.position = newPos;
            Debug.Log("PreviousPos " + oldPos + " newPos " + transform.position);
            yield return null;
            currentDistance = Vector3.Distance(transform.position, destination);
        }
        transform.position = destination;
        RaiseDestinationReached(transform.position);
    }

    private void RaiseDestinationReached(Vector3 destination) {
        if (DestinationReached != null) {
            DestinationReached(transform.position);
        }
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
