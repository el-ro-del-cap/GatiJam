using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{   
    public AudioClip SelectNoise;
    //public AudioSource audioJungle;
    public Consume Consumer;
    private Collider2D coll;
    public Canvas canvas;

    public List<FoodType> foods;

    private void Start() {
        coll = gameObject.GetComponent<BoxCollider2D>();
        //audioJungle = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    private void OnMouseDown() {
        //audioJungle.PlayOneShot(SelectNoise, 0.7f);
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        /*if (collision.tag == "Consumidor")
        {
            onMouth = true;
            Debug.Log("Food on mouth");
            Consumer = collision.GetComponent<Consume>();
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision) {
        /*if (collision.tag == "Consumidor")
        {
            onMouth = false;
            Debug.Log("Food left mouth");
            Consumer = null;
        }*/
    }

    public void OnMouseUp(BaseEventData data) {
        CheckMouth();
        GameObject.Destroy(gameObject);
        /*if (onMouth)
        {
            Consumer.StartCoroutine("Eat");
            GameObject.Destroy(gameObject);

        }*/
    }

    private void CheckMouth() {
        int layerMask = 1 << 6; //Layer de gatos

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 50f, layerMask);
        if (hit.transform != null) {
            Cat hitCat = hit.transform.GetComponent<Cat>();
            if (hitCat != null) {
                if (hitCat.FoodValid(foods.ToArray())) {
                    hitCat.FeedCat();
                }
            }
        }
    }

    public void DragThisThing(BaseEventData data) {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Input.mousePosition,
            canvas.worldCamera,
            out position);

        transform.position = canvas.transform.TransformPoint(position);
    }
    

    public void AddFood(FoodType toAdd) {
        //Codigo de cambiar el sprite de la imagen por acá
        if (!foods.Contains(toAdd)) {
            foods.Add(toAdd);
        }
    }
}
