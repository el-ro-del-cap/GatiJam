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



    public void ScaleBounceCat(Vector3 newScale, float time, AnimationCurve curve = null) {
        StartCoroutine(ScaleBounceCatCR(newScale, time, curve = null));
    }

    public IEnumerator ScaleBounceCatCR(Vector3 newScale, float time, AnimationCurve curve = null) {
        float startTime = Time.time;
        float halfTime = time * 0.5f;
        float maxHalfTime = startTime + halfTime;
        while (Time.time < maxHalfTime) {
            float normalizedProgress = (Time.time - startTime) / maxHalfTime;
            float easing;
            if (curve != null) {
                easing = curve.Evaluate(normalizedProgress);
            } else {
                easing = normalizedProgress;
            }
            Vector3 lerpScale = Vector3.Lerp(baseScale, newScale, easing);
            transform.localScale = lerpScale;
            yield return null;
        }
        startTime = Time.time;
        maxHalfTime = startTime + halfTime;
        while (Time.time < maxHalfTime) {
            float normalizedProgress = (Time.time - startTime) / maxHalfTime;
            float easing;
            if (curve != null) {
                easing = curve.Evaluate(normalizedProgress);
            } else {
                easing = normalizedProgress;
            }
            Vector3 lerpScale = Vector3.Lerp(newScale, baseScale, easing);
            transform.localScale = lerpScale;
            yield return null;
        }
        transform.localScale = baseScale;
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
