using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "ScriptableObjects/CameraSettings", order = 1)]
    public class CameraSettings : ScriptableObject
    {
        private Transform target;
        public float edgePanSpeed = 20f;
        public float edgePanBorder = 10f;
        public Vector2 edgePanLimit;
        public float zoomSpeed = 15f;
        public float zoomMiny = 20f;
        public float zoomMaxy = 120f;
        public KeyCode cameraCenterPlayerKey;
        public KeyCode cameraLockToPlayerKey;
    }
}


