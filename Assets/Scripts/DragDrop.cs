using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{   
    public AudioClip SelectNoise;
    public AudioSource audioJungle;
    public Consume Consumer;
    private Collider2D coll;
    private bool onMouth;

    private void Start()
    {
        onMouth = false;
        coll = gameObject.GetComponent<BoxCollider2D>();
        audioJungle = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        audioJungle.PlayOneShot(SelectNoise, 0.7f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Consumidor")
        {
            onMouth = true;
            Debug.Log("Food on mouth");
            Consumer = collision.GetComponent<Consume>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Consumidor")
        {
            onMouth = false;
            Debug.Log("Food left mouth");
            Consumer = null;
        }
    }

    private void OnMouseUp()
    {
        if (onMouth)
        {
            Consumer.StartCoroutine("Eat");
            GameObject.Destroy(gameObject);
        }
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePos);
    }    
}
