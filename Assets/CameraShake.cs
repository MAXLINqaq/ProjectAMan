using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public  float shakeAmount = 0;
    private float decreaseFactor = 1.0f;
    private Vector3 originalPos;
    public bool startShake;
    public float shake;

    private void Awake()
    {
        originalPos = transform.localPosition;


    }
    void Update()
    {
        if(shakeAmount>0){
            Shake();
        }
        

    }
    private void Shake()
    {
        transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        shakeAmount -= Time.deltaTime * decreaseFactor;
        if (shakeAmount <= 0)
        {
            startShake = false;
            transform.localPosition = originalPos;
        }

    }
    public void SetBigShakeAmount()
    {
        shakeAmount += 0.5f;
    }
    public void SetSmallShakeAmount()
    {
        if(shakeAmount < 0.3){
            shakeAmount += 0.1f;
        }
    }

}
