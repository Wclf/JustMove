using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public static bool isDeath;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isDeath)
        {
            animator.SetTrigger("isDeath");
            isDeath = false;
        }

    }
}
