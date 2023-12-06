using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    [SerializeField]
    private EnemyDetection enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("wait a minute.... who are you?");
        if (collision.CompareTag("Player"))
        {
            enemy.PlayerIsDetected();
        }
    }
}
