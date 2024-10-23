using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mathias
{
    public class BoatControlDirection : MonoBehaviour
    {
        /// <summary>
        /// This is the rotation of the boat in angle left to right.
        /// </summary>
        [Tooltip("This rotation is in angle around Y axis")]
        public float m_rotationLeftRight = 90f;

        [Tooltip("This is speed in meter to go forward")]
        public float m_frontalSpeed = 10f;

        [Tooltip("This is speed in meter to go backward")]
        public float m_backSpeed = 5f;

        public Transform m_whatToMove;

        // Added fields for movement and rotation input
        [Range(-1f, 1f)]
        [SerializeField] float m_rotateHorizontal;
        [Range(-1f, 1f)]
        [SerializeField] float m_moveVertical;


        public void SetHorizontal(float percent)
        {
            percent = Mathf.Clamp(percent, -1f, 1f);
            m_rotateHorizontal = percent;

        }
        public void SetVertical(float percent)
        {
            percent = Mathf.Clamp(percent, -1f, 1f);
            m_moveVertical = percent;
        }
        private void Update()
        {
            MoveBoat();
        }

        private void MoveBoat()
        {
            // Calculate forward/backward movement
            float speed = m_moveVertical > 0 ? m_frontalSpeed : m_backSpeed;
            Vector3 forwardMovement = m_whatToMove.forward * m_moveVertical * speed * Time.deltaTime;

            // Apply movement
            m_whatToMove.position += forwardMovement;

            // Calculate left/right rotation
            float rotation = m_rotateHorizontal * m_rotationLeftRight * Time.deltaTime;

            // Apply rotation
            m_whatToMove.Rotate(0, rotation, 0);
        }

        
    }
}
