using UnityEngine;

namespace VRProj.CameraInternal {

    public class CameraCoreContext {

        public Camera mainCam;

        public CameraVirualEntity virualEntity;

        public CameraCoreContext() {
            virualEntity = new CameraVirualEntity();
        }

        public void Inject(Camera mainCam) {
            this.mainCam = mainCam;
        }

    }

}