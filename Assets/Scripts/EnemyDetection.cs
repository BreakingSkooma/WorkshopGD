using System;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    private bool playerDetected = false;


    [SerializeField]
    private AudioSource defaultSource;
    [SerializeField]
    private AudioSource detectedSource;
    [SerializeField]
    private AudioSource alarmeSource;

    [SerializeField]
    private EnemyAnimator enemyAnimator;



    public void PlayerIsDetected()
    {
        Debug.Log("Player detected!");
        playerDetected = true;

        GameManager.instance.PlayerDectected(this);
        enemyAnimator.LaunchDetectionAnimation();
        defaultSource.Stop();
        detectedSource.Play();
        alarmeSource.Play();
    }

    void ResetDetection()
    {
        playerDetected = false;
    }

}
