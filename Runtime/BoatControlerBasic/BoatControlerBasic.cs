using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LieMathias
{
    public class BoatControlerBasic : MonoBehaviour
    {
        [ContextMenu("Teleport Forward")]
        public void TeleportFoward()
        {
            transform.position += transform.forward * 1;
        }
    }
}