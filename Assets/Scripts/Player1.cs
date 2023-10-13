using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform stick;
        public Transform helper;
        public float range = 30f;
        public float speed = 500f;
        public float power = 20f;

        private bool m_isDown = false;
        private Vector3 m_lastPosition;

        public delegate void PointsCounter();
        public PointsCounter _pointsCounter;
        public event PointsCounter HitStone;
        private int Count;

        private void Start()
        {
            HitStone += Counter;
        }
        private void Update()
        {
            m_lastPosition = helper.position;

            m_isDown = Input.GetMouseButton(0);

            Quaternion rot = stick.localRotation;
            Quaternion toRot = Quaternion.Euler(0, 0, m_isDown ? range : -range);
            stick.localRotation = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);
        }

        public void OnCollisonStick(Collider collider)
        {
            if (collider.TryGetComponent(out Rigidbody body))
            {
                var dir = (helper.position - m_lastPosition).normalized;
                body.AddForce(dir * power, ForceMode.Impulse);
                HitStone();


                if (collider.TryGetComponent(out Stone stone))
                {
                    stone.isAfect = true;
                }
            }
        }
        public void Counter()
        {
            Count++;
            Debug.Log(Count);
        }
    }

}