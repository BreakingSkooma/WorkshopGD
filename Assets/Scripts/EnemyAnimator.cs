using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void LaunchDetectionAnimation()
    {
        animator.SetTrigger("Detected");
        animator.SetBool("IsDetected", true);
        
    }
}
