using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;

public class Cat : MonoBehaviour {

    public event PositionDelegate DestinationReached;

    public CatSpriteStuff spriteScript;
    [Space]

    public float maxPatience = 100;
    public float patienceDelta = 5f;
    public float damage = 5f;
    private float patience = -1f;
    public float damageCooldown = 5f;
    private float halfCooldown;
    private float currentCooldown = 0f;
    [Space]
    public FoodType[] foods;
    [Space]
    [SerializeField] AnimationCurve moveEasing;

    CatState catState = CatState.noneStand;

    // Start is called before the first frame update
    void Start() {
        DestinationReached += DestinationReachedHandler;
        UpdateCatState(CatState.noneStand);
        UpdateCatRotation();
        patience = maxPatience;
        halfCooldown = damageCooldown * 0.5f;
    }


    // Update is called once per frame
    void Update() {
        //Ifs ultra desprolijos, w/e
        if (catState == CatState.neutral || catState == CatState.angry) {
            if (catState == CatState.neutral) {
                patience = patience - Time.deltaTime * patienceDelta;
                if (patience < 0f) {
                    UpdateCatState(CatState.angry);
                }
            }
            currentCooldown = currentCooldown + Time.deltaTime;
            if ((catState == CatState.neutral && currentCooldown > damageCooldown) || (catState == CatState.angry && currentCooldown > halfCooldown)) {
                currentCooldown = 0f;
                DoMeow();
            }
        }
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
        // Work in progress
        Vector3 moveStart = transform.position;
        float startTime = Time.time;
        float currentDistance = Vector3.Distance(moveStart, destination);
        float thisMoveTime = currentDistance / speedUnitsPerSecond;
        while (currentDistance > minDistance) {
            float normalizedProgress = (Time.time - startTime) / thisMoveTime;
            if (normalizedProgress > 1) {
                break;
            }
            float easing = moveEasing.Evaluate(normalizedProgress);
            Vector3 oldPos = transform.position;
            Vector3 newPos = Vector3.Lerp(moveStart, destination, easing);
            transform.position = newPos;
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

    private void DoMeow() {
        Debug.Log("Meow");
        spriteScript.DoMeow();
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

    private void DestinationReachedHandler(Vector3 position) {
        UpdateCatState(CatState.neutral);
        UpdateCatRotation();
    }

    public void UpdateCatState(CatState newState) {
        catState = newState;
        spriteScript.SetState(catState);
    }

    public void UpdateCatRotation() {
        if (transform.position.x < 0) {
            spriteScript.spriteRenderer.flipX = true;
        } else {
            spriteScript.spriteRenderer.flipX = false;
        }
    }
}

public enum CatState {
    noneStand,
    neutral,
    angry,
    happy
}
