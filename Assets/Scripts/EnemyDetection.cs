using System;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask playerLayer;

    private Transform player;
    private bool playerDetected = false;

    public AudioClip audioClip;
    private AudioSource audioSource;

    public event Action PlayerDetected;



    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(player);
    }

    void Update()
    {

    }

    public void PlayerIsDetected()
    {
        Debug.Log("Player detected!");
        audioSource.Play();
        playerDetected = true;

        GameManager.instance.PlayerDectected(this);
    }

    void ResetDetection()
    {
        playerDetected = false;
    }

    void OnDrawGizmosSelected()
    {
        // Dessiner une boîte pour visualiser la zone de détection
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, detectionRadius, 0), new Vector3(detectionRadius * 4, detectionRadius * 2, 0));
    }
}
