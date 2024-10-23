using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mathias
{

    public class MovingScriptTestMono : MonoBehaviour
    {
        [Range(-1, 1)]
        [SerializeField] float m_percentHorizontalAxis;
        [Range(-1, 1)]
        [SerializeField] float m_percentVerticalAxis;

        /// <summary>
        /// This is the rotation of the boat in agnle left to right
        /// </summary>
        [Tooltip("This rotation is in angle around Y axis")]
        public float m_rotationLeftRight = 90f;
        [Tooltip("This is speed in meter to go foward")]
        public float m_frontalSpeed = 10f;
        [Tooltip("This is speed in meter to go backward")]
        public float m_backSpeed = 5f;

        public Transform m_whatToMove;

        private void Update()
        {
            // Mise à jour des mouvements
            float horizontalInput = Input.GetAxis("Horizontal") * m_percentHorizontalAxis;
            float verticalInput = Input.GetAxis("Vertical") * m_percentVerticalAxis;

            // Rotation du bateau
            m_whatToMove.Rotate(0, horizontalInput * m_rotationLeftRight * Time.deltaTime, 0);

            // Mouvement du bateau
            Vector3 forwardMovement = m_whatToMove.forward * verticalInput * (verticalInput > 0 ? m_frontalSpeed : -m_backSpeed) * Time.deltaTime;
            m_whatToMove.position += forwardMovement;
        }

        public void SetHorizontal(float percent)
        {
            m_percentHorizontalAxis = Mathf.Clamp(percent, -1f, 1f);
        }

        public void SetVertical(float percent) => m_percentVerticalAxis = Mathf.Clamp(percent, -1f, 1f);
    }
}