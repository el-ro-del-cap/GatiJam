using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimations : MonoBehaviour
{

    [SerializeField] AnimationCurve bounceCurve;
    [Space]
    [SerializeField] AnimationCurve vanishCurve;
    [Space]
    [SerializeField] AnimationCurve meowCurve;

    private Vector3 baseScale;

    // Start is called before the first frame update
    void Start() {
        baseScale = transform.localScale;
    }

    public void ScaleBounceCat(Vector3 scale, float time) {

        
    }

    public void ScaleBounceCatCR(Vector3 scale, float time) {
        
    }


    /*
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
    */
}
