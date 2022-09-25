using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStats : MonoBehaviour
{
    [SerializeField]private Animator animator;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            animator.SetTrigger("statsClose");
        }
    }
}