using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // R�f�rence au transform du joueur
    public Transform enemy;  // R�f�rence au transform de l'ennemi

    public float smoothSpeed = 0.125f; // Vitesse de lissage du mouvement de la cam�ra

    private void FixedUpdate()
    {
        // V�rifier si l'ennemi est rep�r� (par exemple, avec un rayon de d�tection)
        if (EnemyDetected())
        {
            // Si l'ennemi est rep�r�, centrer la cam�ra sur lui pendant un court instant
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
        // Calculer la nouvelle position de la cam�ra en suivant le joueur
        Vector3 desiredPosition = player.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }

    void FocusOnEnemy()
    {
        // Centrer la cam�ra sur l'ennemi pendant un court instant
        Vector3 desiredPosition = enemy.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }

    bool EnemyDetected()
    {
        // Impl�menter la logique pour d�tecter l'ennemi (par exemple, utiliser des rayons, des collisions, etc.)
        // Renvoie true si l'ennemi est d�tect�, sinon false
        // Assurez-vous d'adapter cette fonction selon vos besoins sp�cifiques
        return false;
    }
}
