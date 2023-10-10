using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stick : MonoBehaviour
{
    public UnityEvent<Collider> onCollision;
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
