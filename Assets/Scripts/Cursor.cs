using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private void Update()
    {
        Vector3 newPosition = MapManager.instance.GetGridPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition)) + new Vector3(0.5f, 0.5f, 0.5f);
        transform.position = newPosition;
    }
}
