using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;

public class CharcterController : MonoBehaviour
{
    private DefaultInput defaultInput;
    public Vector2 input_Movement;
    public Vector2 input_View;

    private Vector3 newCameraRotation;

    [Header("References")]
    public Transform cameraHolder;

    [Header("Settings")]
    public PlayerSettingsModel playerSettings;
    public float viewClampYMin = -70.0f;
        public float viewClampYMax = 80.0f;

    private void Awake()
    {
        defaultInput = new DefaultInput();

        defaultInput.Character.Movement.performed += context => input_Movement = context.ReadValue<Vector2>();
        defaultInput.Character.View.performed += context => input_View = context.ReadValue<Vector2>();

        defaultInput.Enable();

        newCameraRotation = cameraHolder.localRotation.eulerAngles;
    }

    private void Update()
    {
        CalculateView();
        //CalculateMovement();
    }

    private void CalculateView()
    {
        newCameraRotation.x += playerSettings.ViewYSensitivity * input_View.y * Time.deltaTime;

        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, viewClampYMin, viewClampYMax);

        cameraHolder.localRotation = Quaternion.Euler(newCameraRotation);
    }

  

}

