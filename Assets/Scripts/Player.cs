using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe qui gère le joueur
public class Player : MonoBehaviour
{
    private Vector3Int gridPosition;

    private BoxCollider2D boxCollider;

    [SerializeField]
    private GameObject outliner;

    [SerializeField]
    private float moveSpeed;

    private bool isMoving;
    private List<Vector2> path;
    private int tileIndex;

    [SerializeField]
    private GameObject visualObject;
    private PlayerAnimator animator;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = visualObject.GetComponent<PlayerAnimator>();
        
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
                CameraSwitcher.instance.ZoomOut();
                isMoving = false;
                path.Clear();
                tileIndex = 0;
                GameManager.instance.ClearPathMakerList();
                animator.StopMoveAnim();
            }
            else
            {
                GameManager.instance.RemoveMarker(tileIndex);
                tileIndex += 1;
                
            }
        }
    }

    public void MoveTo(List<Vector2> path)
    {
        animator.LaunchMoveAnim();
        CameraSwitcher.instance.ZoomIn(transform);
        this.path = path;
        tileIndex = 0;
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
            Selected();
        }
    }

    public void Selected()
    {
        GameManager.instance.SelectPlayer(this);
        animator.SelectedAnim();
    }

    public void UnSelected()
    {
        outliner.SetActive(false);
        animator.StopSelectedAnim();
    }

    private void OnMouseOver()
    {
        if (!isMoving)
        {
            outliner.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (GameManager.instance.getSelectedPlayer() != this)
        {
            outliner.SetActive(false);
        }
        
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}
