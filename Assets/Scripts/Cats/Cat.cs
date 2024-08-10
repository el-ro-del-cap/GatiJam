using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;

public class Cat : MonoBehaviour {

    public CatCounter counter;
    public event PositionDelegate DestinationReached;
    public CatSpriteStuff spriteScript;
    private CatAnimations catAnims;
    [Space]

    public float maxPatience = 100;
    public float patienceDelta = 5f;
    public float damage = 5f;
    private float patience = -1f;
    public float damageCooldown = 5f;
    private float angryCooldown;
    private float currentCooldown = 0f;
    private float screenXCenter = -20f;
    public AudioClip[] meows;
    private AudioSource audioSource;
    [Space]
    public FoodType[] foods;
    [Space]
    [SerializeField] AnimationCurve moveEasing;

    CatState catState = CatState.noneStand;

    // Start is called before the first frame update
    void Start() {
        counter = FindObjectOfType<CatCounter>();
        audioSource = GetComponent<AudioSource>();
        catAnims = GetComponent<CatAnimations>();
        DestinationReached += DestinationReachedHandler;
        UpdateCatState(CatState.noneStand);
        UpdateCatRotation();
        patience = maxPatience;
        angryCooldown = damageCooldown * 0.75f;
        float pitchRandom = Random.Range(-0.15f,0.15f);
        audioSource.pitch = audioSource.pitch + pitchRandom;
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
            if ((catState == CatState.neutral && currentCooldown > damageCooldown) || (catState == CatState.angry && currentCooldown > angryCooldown)) {
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
        transform.position = new Vector3(destination.x, destination.y, 1);
        RaiseDestinationReached(transform.position);
    }

    private void RaiseDestinationReached(Vector3 destination) {
        if (DestinationReached != null) {
            DestinationReached(transform.position);
        }
    }

    private void DoMeow() {
        HealthController.Instance.TakeDamage(damage);
        spriteScript.DoMeow();
        if (audioSource != null && meows.Length != 0) {
            int randMeow = Random.Range(0, meows.Length);
            audioSource.PlayOneShot(meows[randMeow]);
        }
        catAnims.ScaleBounceCat(new Vector3(0.9f,1.1f,1f), 0.4f);
    }

    /// <summary>
    /// Retorna True si la pila de comida dada tiene la misma comida que pide este gato, retorna False si la pila de comida no contiene elementos que pide el gato o es de otro tamaño
    /// </summary>
    /// <param name="foodPile">Array de comida a chequear</param>
    /// <returns></returns>
    public bool FoodValid(FoodType[] foodPile) {
        if (catState != CatState.happy && foodPile.Length != foods.Length) {
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
        if (transform.position.x < screenXCenter) {
            spriteScript.spriteRenderer.flipX = true;
        } else {
            spriteScript.spriteRenderer.flipX = false;
        }
    }

    public void FeedCat() {
        StartCoroutine(FeedCatCR());
        catAnims.ScaleBounceCat(new Vector3(1.2f, 0.8f, 1f), 1.5f);
    }

    public IEnumerator FeedCatCR() {
        UpdateCatState(CatState.happy);
        counter.counterAdd();
        yield return new WaitForSeconds(1f);
        // Vanish graphic hooked here
        CatManager.RemoveCatFromList(this);
        Destroy(gameObject);
    }
}

public enum CatState {
    noneStand,
    neutral,
    angry,
    happy
}
