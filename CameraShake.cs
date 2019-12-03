using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    public float shakeAmount;
    private float shakeAmountCopy;
    //public float shakeLength;
    //public float decreaseRate;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = camTransform.localPosition;
        shakeAmountCopy = shakeAmount;
    }
    // Update is called once per frame
    void Update()
    { 
        if(Time.timeScale != 1)
        {
            shakeAmount = shakeAmountCopy / 8f;
        }
        else
        {
            shakeAmount = shakeAmountCopy;
        }
        camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
    }
}
