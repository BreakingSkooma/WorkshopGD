using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Référence au transform du joueur
    public Transform enemy;  // Référence au transform de l'ennemi

    public float smoothSpeed = 0.125f; // Vitesse de lissage du mouvement de la caméra

    private void FixedUpdate()
    {
        // Vérifier si l'ennemi est repéré (par exemple, avec un rayon de détection)
        if (EnemyDetected())
        {
            // Si l'ennemi est repéré, centrer la caméra sur lui pendant un court instant
            FocusOnEnemy();
        }
        else
        {
            // Sinon, revenir au suivi du joueur
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Calculer la nouvelle position de la caméra en suivant le joueur
        Vector3 desiredPosition = player.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }

    void FocusOnEnemy()
    {
        // Centrer la caméra sur l'ennemi pendant un court instant
        Vector3 desiredPosition = enemy.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }

    bool EnemyDetected()
    {
        // Implémenter la logique pour détecter l'ennemi (par exemple, utiliser des rayons, des collisions, etc.)
        // Renvoie true si l'ennemi est détecté, sinon false
        // Assurez-vous d'adapter cette fonction selon vos besoins spécifiques
        return false;
    }
}
