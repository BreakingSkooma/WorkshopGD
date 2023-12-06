using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private AudioSource m_Source;

    [SerializeField]
    private Player player;

    private void Awake()
    {
        m_Source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 newPosition = MapManager.instance.GetGridPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition)) + new Vector3(0.5f, 0.5f, 0.5f);
        if (newPosition != transform.position && !player.IsMoving())
        {
            m_Source.Play();
        }
        transform.position = newPosition;
    }
}
