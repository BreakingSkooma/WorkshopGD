using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3Int gridPosition;

    private void Awake()
    {
        UpdateGridPosition();
    }

    public void Move(Vector3 position)
    {
        transform.position = position;
        UpdateGridPosition();

    }

    private void UpdateGridPosition()
    {
        gridPosition = MapManager.instance.GetGridPosition(transform.position);
    }
}
