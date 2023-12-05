using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDetection : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask playerLayer;

    private Transform player;
    private bool playerDetected = false;

    public AudioClip audioClip;
    private AudioSource audioSource;

    public UnityEvent onDetected;



    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (onDetected == null) onDetected = new UnityEvent();
        Debug.Log(player);
    }

    void Update()
    {
        if (!playerDetected)
        {
            // Obtenir la direction du joueur par rapport � l'ennemi
            Vector2 directionToPlayer = player.position - transform.position;

            // V�rifier si le joueur est dans la zone de vision de l'ennemi
            if (Vector2.Angle(transform.up, directionToPlayer) < 45f)
            {
                // Effectuer un OverlapBox Cast pour d�tecter le joueur
                Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(detectionRadius * 2, detectionRadius), 0f, playerLayer);

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Player"))
                    {
                        Debug.Log("Player detected!");
                        audioSource.Play();
                        playerDetected = true;
                        onDetected.Invoke(); // D�clenche l'�v�nement lorsque l'ennemi est d�tect�
                        // Ajoutez une ligne pour r�initialiser la d�tection
                        Invoke("ResetDetection", 2f); // R�initialise apr�s 2 secondes, ajustez selon vos besoins
                        break;
                    }
                }
            }
        }
    }

    void ResetDetection()
    {
        playerDetected = false;
    }

    void OnDrawGizmosSelected()
    {
        // Dessiner une bo�te pour visualiser la zone de d�tection
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, detectionRadius, 0), new Vector3(detectionRadius * 4, detectionRadius * 2, 0));
    }
}
