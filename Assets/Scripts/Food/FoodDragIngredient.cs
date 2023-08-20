using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodDragIngredient : MonoBehaviour {
    [Header("Cursor Settings")]
    public Texture2D Hover;
    public Texture2D Grab;
    public Vector2 NormalCursorHotSpot;
    public Vector2 GrabCursorHotSpot;

    [SerializeField]
    public FoodType foodType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DragThisThing(BaseEventData data)
    {
        Cursor.SetCursor(Grab, GrabCursorHotSpot, CursorMode.Auto);
        Vector2 position;
        Canvas canvas = CanvasSingleton.Instance.canvas;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Input.mousePosition,
            canvas.worldCamera,
            out position);

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void OnMouseUp(BaseEventData data)
    {
        Cursor.SetCursor(Hover, NormalCursorHotSpot, CursorMode.Auto);
        AddFood();
        GameObject.Destroy(gameObject);
    }


    private void AddFood() {
        int layerMask = 1 << 7; //Layer de gatos

        Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, ray.direction, 50f, layerMask);
        if (hit.transform != null) {
            DragDrop hitBowl = hit.transform.GetComponent<DragDrop>();
            if (hitBowl != null) {
                hitBowl.AddFood(foodType);
            }
        }
    }

}
