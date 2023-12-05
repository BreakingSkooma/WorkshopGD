using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SelectedAnim()
    {
        animator.SetBool("Selected", true);
    }

    public void StopSelectedAnim()
    {
        animator.SetBool("Selected", false);
    }

    public void LaunchMoveAnim()
    {
        animator.SetBool("IsMoving", true);
    }

    public void StopMoveAnim()
    {
        animator.SetBool("IsMoving", false);
    }
}
