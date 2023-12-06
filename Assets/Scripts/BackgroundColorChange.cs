using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField]
    private float transitionTime = 2;
    [SerializeField]
    private float alarmTime = 1;
    private float timeLeft;

    private Color targetColor;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (timeLeft <= Time.deltaTime)
        {
            // transition complete
            // assign the target color
            mainCamera.backgroundColor = targetColor;

            // start a new transition
            targetColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = transitionTime;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, targetColor, Time.deltaTime / timeLeft);

            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }

    public void detected()
    {
        transitionTime = alarmTime;
    }
}
