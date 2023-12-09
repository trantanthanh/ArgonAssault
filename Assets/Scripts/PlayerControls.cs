using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 5f;
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
        float xThrow = Input.GetAxis("Horizontal");
        // float horizontalThrow = movementInput.ReadValue<Vector2>().x;

        float yThrow = Input.GetAxis("Vertical");
        // float verticalThrow = movementInput.ReadValue<Vector2>().y;

        float xOffset = movementSpeed * xThrow * Time.deltaTime * 5f;
        float newPositionX = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);
        float yOffset = movementSpeed * yThrow * Time.deltaTime * 5f;
        float newPositionY = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, 2 * yRange);
        transform.localPosition = new Vector3(newPositionX, newPositionY, transform.localPosition.z);
    }
}
