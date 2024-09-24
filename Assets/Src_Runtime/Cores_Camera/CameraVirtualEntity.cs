using UnityEngine;

namespace VRProj.CameraInternal {

    public class CameraVirualEntity {

        public Vector3 targetPos;
        public Vector2 offset;
        public float distance;

        public CameraVirualEntity() {
            targetPos = Vector3.zero;
            offset = Vector2.zero;
            distance = 0;
        }

    }

}