using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform stick;
    public float range = 30;
    public float speed = 500f;
    public float power = 20f;

    private bool m_isDown = false;
    private Vector3 m_position;

    public void Update()
    {
        m_isDown = Input.GetMouseButtonDown(0);

        Quaternion rot = transform.rotation;
        Quaternion toRot = Quaternion.Euler(0f, 0f, m_isDown ? range : - range);
        rot = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);

        stick.localRotation = rot;
    }

    public void OnCollisionStick(Collider collider)
    {
        if (collider.TryGetComponent(out Rigidbody stone))
        {
            //stone.AddForce()
        }
    }
}
