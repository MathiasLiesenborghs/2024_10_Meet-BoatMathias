using UnityEditor;
using UnityEngine;

namespace LieMathias
{
    [CustomEditor(typeof(BoatControlerBasic))]
    public class BoatControlerBasicEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            BoatControlerBasic t = (BoatControlerBasic)target;
            if (GUILayout.Button("Teleport Forward"))
            {
                t.TeleportFoward();
            }
        }
    }
}