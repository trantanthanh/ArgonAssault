using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movementInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        movementInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // float horizontalThrow = Input.GetAxis("Horizontal");
        float horizontalThrow = movementInput.ReadValue<Vector2>().x;
        Debug.Log("🚀 ~ file: PlayerControls.cs:17 ~ horizontalThrow: " + horizontalThrow);

        // float verticalThrow = Input.GetAxis("Vertical");
        float verticalThrow = movementInput.ReadValue<Vector2>().y;
        Debug.Log("🚀 ~ file: PlayerControls.cs:29 ~ verticalThrow: " + verticalThrow);
    }
}
