using UnityEngine;
using VRProj.CameraInternal;

namespace VRProj {

    public class CameraCore {

        CameraCoreContext ctx;

        public CameraCore() {
            ctx = new CameraCoreContext();
        }

        public void Inject(Camera mainCam) {
            ctx.Inject(mainCam);
        }

        // Tick
        public void Tick(Vector3 follow_targetPos, Vector2 follow_offset, float follow_distance, Vector3 face, float dt) {

            CameraVirualEntity virualEntity = ctx.virualEntity;
            virualEntity.targetPos = follow_targetPos;
            virualEntity.offset = follow_offset;
            virualEntity.distance = follow_distance;

            // 应用到相机
            Camera mainCam = ctx.mainCam;
            mainCam.transform.position = follow_targetPos + new Vector3(follow_offset.x, follow_offset.y, -follow_distance);
            mainCam.transform.forward = face;
        }

    }

}