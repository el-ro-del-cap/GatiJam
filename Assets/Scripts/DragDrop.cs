using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private AudioSource audioJungle;

    private void Start()
    {
        audioJungle = gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        audioJungle.Play();
    }

    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePos);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
