using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject MessageLose;


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
            MessageLose.SetActive(true);
            animator.SetTrigger("isDeath");
            isDeath = false;
        }

    }
}
