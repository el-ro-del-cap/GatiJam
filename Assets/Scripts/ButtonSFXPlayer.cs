using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFXPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void PlaySFXOnClick()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
