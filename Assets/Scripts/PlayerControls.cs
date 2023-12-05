using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
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
    }
}
