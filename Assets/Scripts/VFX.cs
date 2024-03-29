using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VFX : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    [SerializeField] GameObject Vfx;
    Vector2 mouse;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        Vfx.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Mouse();   
    }

    private void Mouse()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vfx.SetActive(true);
            Vfx.transform.position = new Vector3(mouse.x, mouse.y, 0f);
            audioSource.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vfx.SetActive(false);
        }
    }
}
