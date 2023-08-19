using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consume : MonoBehaviour
{
    public AudioClip Chew;
    public AudioSource audioConcrete;
    private void Start()
    {
    audioConcrete = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    public IEnumerator Eat()
    {
        audioConcrete.PlayOneShot(Chew, 0.7f);
        Debug.Log("QUE RICA");
        yield return new WaitForSeconds(0.15f);
        GameObject.Destroy(gameObject);
    }

    public void Comer()
    {
        Debug.Log("KE RICA");
    }
}
