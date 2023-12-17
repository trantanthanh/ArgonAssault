using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("How fast the player moves up and down")]
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 5f;

    [Header("Rotation Settings")]
    [Tooltip("How fast the player turns")]
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 1f;
    [SerializeField] float controlRollFactor = 10f;
    [SerializeField] float positionRollFactor = -1f;
    float yThrow, xThrow;

    [Header("Firing Settings")]
    [Tooltip("Left right lasers")]
    [SerializeField] GameObject[] lasers;

    // [SerializeField] InputAction movementInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // void OnEnable()
    // {
    //     movementInput.Enable();
    // }

    // void OnDisable()
    // {
    //     movementInput.Disable();
    // }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetActiveLasers(true);
        }
        else
        {
            SetActiveLasers(false);
        }
    }

    void SetActiveLasers(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = transform.localPosition.z * positionRollFactor + xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        // float horizontalThrow = movementInput.ReadValue<Vector2>().x;

        yThrow = Input.GetAxis("Vertical");
        // float verticalThrow = movementInput.ReadValue<Vector2>().y;

        float xOffset = movementSpeed * xThrow * Time.deltaTime * 5f;
        float newPositionX = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float yOffset = movementSpeed * yThrow * Time.deltaTime * 5f;
        float newPositionY = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, 2 * yRange);
        transform.localPosition = new Vector3(newPositionX, newPositionY, transform.localPosition.z);
    }
}
