using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe qui gère le joueur
public class Player : MonoBehaviour
{
    private Vector3Int gridPosition;

    private BoxCollider2D boxCollider;

    [SerializeField]
    private float moveSpeed;

    private bool isMoving;
    private List<Vector2> path;
    private int tileIndex;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    private void Start()
    {
        UpdateGridPosition();
    }

    private void Update()
    {
        if (isMoving) 
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, path[tileIndex], moveSpeed*Time.deltaTime);
        Vector3 convertCoords = path[tileIndex];
        if (transform.position == convertCoords)
        {
            UpdateGridPosition();
            if (tileIndex == path.Count - 1)
            {
                isMoving = false;
                path.Clear();
                tileIndex = 1;
            }
            else
            {
                tileIndex += 1;
            }
        }
    }

    public void MoveTo(List<Vector2> path)
    {
        this.path = path;
        tileIndex = 1;
        isMoving = true;
    }

    private void UpdateGridPosition()
    {
        gridPosition = MapManager.instance.GetGridPosition(transform.position);
    }

    private void OnMouseDown()
    {
        if (!isMoving)
        {
            GameManager.instance.SelectPlayer(this);
        }
    }
}
