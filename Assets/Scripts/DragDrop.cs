using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{   
    public AudioClip SelectNoise;
    //public AudioSource audioJungle;
    public Image image;

    public Sprite sprtEmpty;
    public Sprite sprtWhite;
    public Sprite sprtBlack;
    public Sprite sprtOrange;
    public Sprite sprtWB;
    public Sprite sprtBO;
    public Sprite sprtOW;
    public Sprite sprtBOW;

    public List<FoodType> foods;

    private void Start() {
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
        Canvas canvas = CanvasSingleton.Instance.canvas;
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
            UpdateFoodGraphics();
        }
    }

    public void EmptyFood() {
        foods = new List<FoodType>();
        UpdateFoodGraphics();
    }

    public void UpdateFoodGraphics() {
        if (foods.Count < 1) {
            ChangeSprite(sprtEmpty);
            return;
        }
        bool white = foods.Contains(FoodType.white);
        bool orange = foods.Contains(FoodType.orange);
        bool black = foods.Contains(FoodType.black);

        if (white) {
            if (orange) {
                if (black) {
                    ChangeSprite(sprtBOW);
                } else {
                    ChangeSprite(sprtOW);
                }
            } else if (black) {
                ChangeSprite(sprtWB);
            } else {
                ChangeSprite(sprtWhite);
            }
        } else if (orange) {
            if (black) {
                ChangeSprite(sprtBO);
            } else {
                ChangeSprite(sprtOrange);
            }
        } else if (black) {
            ChangeSprite(sprtBlack);
        } else {
            ChangeSprite(sprtEmpty);
        }
    }

    private void ChangeSprite(Sprite newSprite) {
        image.sprite = newSprite;
    }


}
