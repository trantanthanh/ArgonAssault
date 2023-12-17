using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{this.name} Collided with: {other.gameObject.name} with tag {other.gameObject.tag}");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{this.name} Triggered with: {other.gameObject.name} with tag {other.gameObject.tag}");
    }
}
