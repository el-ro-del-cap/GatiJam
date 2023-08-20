using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpriteStuff : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    [Space]

    //Cada array es un estado de sprites de gato, el 0 del array es el sprite normal, 1 es maullando

    public Sprite[] parado;

    public Sprite[] neutro;

    public Sprite[] feliz;

    public Sprite[] sad;

    public Sprite[] angery;

    private CatState state = CatState.noneStand;
    private bool sadNotAngry = false;
    public float meowTime = 0.3f;

    // Start is called before the first frame update
    void Start() {
        

    }

    // Update is called once per frame
    void Update() {
        

    }


    public void SetState(CatState newState) {
        state = newState;
        switch (newState) {
            case CatState.neutral:
                spriteRenderer.sprite = neutro[0];
                break;
            case CatState.noneStand:
                spriteRenderer.sprite = parado[0];
                break;
            case CatState.angry:
                if (Random.Range(0, 2) > 0) {
                    spriteRenderer.sprite = sad[0];
                    sadNotAngry = true;
                } else {
                    spriteRenderer.sprite = angery[0];
                    sadNotAngry = false;
                }
                break;
            case CatState.happy:
                spriteRenderer.sprite = feliz[0];
                break;
        }
    }

    public void DoMeow() {
        StartCoroutine(DoMeowCR());
    }

    public IEnumerator DoMeowCR() {
        switch (state) {
            case CatState.neutral:
                spriteRenderer.sprite = neutro[1];
                yield return new WaitForSeconds(meowTime);
                spriteRenderer.sprite = neutro[0];
                break;
            case CatState.noneStand:
                spriteRenderer.sprite = parado[1];
                yield return new WaitForSeconds(meowTime);
                spriteRenderer.sprite = parado[0];
                break;
            case CatState.angry:
                if (sadNotAngry) {
                    spriteRenderer.sprite = sad[1];
                    yield return new WaitForSeconds(meowTime);
                    spriteRenderer.sprite = sad[0];
                } else {
                    spriteRenderer.sprite = angery[1];
                    yield return new WaitForSeconds(meowTime);
                    spriteRenderer.sprite = angery[0];
                }
                break;
            case CatState.happy:
                spriteRenderer.sprite = feliz[1];
                yield return new WaitForSeconds(meowTime);
                spriteRenderer.sprite = feliz[0];
                break;
        }
    }
    //parado
    //sentado
    //sad
    //neutro
    //enojado
    //feliz
}
