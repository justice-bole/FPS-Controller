using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Models;

public class WeaponController : MonoBehaviour
{
    private CharcterController characterController;

    [Header("Settings")]
    public WeaponSettingsModel settings;

    private bool isInitialized;

    Vector3 newWeaponRotation;
    Vector3 newWeaponRotationVelocity;

    private void Start()
    {
        newWeaponRotation = transform.localRotation.eulerAngles;
    }

    public void Initialize(CharcterController CharacterController)
    {
        characterController = CharacterController;
        isInitialized = true;
    }

    private void Update()
    {
        if(!isInitialized) return;

        newWeaponRotation.y += settings.SwayAmount * (settings.SwayXInverted ? -characterController.input_View.x : characterController.input_View.x) * Time.deltaTime;
        newWeaponRotation.x += settings.SwayAmount * (settings.SwayYInverted ? characterController.input_View.y : -characterController.input_View.y) * Time.deltaTime;
        //newWeaponRotation.x = Mathf.Clamp(newWeaponRotation.x, viewClampYMin, viewClampYMax);

        transform.localRotation = Quaternion.Euler(newWeaponRotation);
    }



}
