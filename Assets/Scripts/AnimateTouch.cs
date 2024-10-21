using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimateTouch : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    public static bool isTouch = false;

    private void Update()
    {
        //play partical when touch the item
        if(isTouch == true)
        {
            particle.Play();
        }
        isTouch = false;
    }
}
