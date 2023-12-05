using UnityEngine;

public class EnemyController : MonoBehaviour
{
   [field: SerializeField]
   public bool PlayerInArea { get; private set; }
   public Transform Player {  get; private set; }

    [SerializeField]
    private string detectionTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(detectionTag))
        {
            PlayerInArea = true;
            Player = collision.gameObject.transform;
            Debug.Log("joueur detecté");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
        {
            PlayerInArea = false;
            Player = null;
        }
    }
}
