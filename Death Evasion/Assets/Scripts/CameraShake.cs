using System;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0.1f;
    public float shakeMagnitude = 0.1f;
    public float dampingSpeed = 0.5f;

    private Vector3 initialPosition;
    private float shakeTimer = 0f;

    private void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void OnEnable()
    {
        initialPosition = cameraTransform.localPosition;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            cameraTransform.localPosition = initialPosition + UnityEngine.Random.insideUnitSphere * shakeMagnitude;

            shakeTimer -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeTimer = 0f;
            cameraTransform.localPosition = initialPosition;
        }
    }

    public void ShakeCamera()
    {
        shakeTimer = shakeDuration;
    }
}


