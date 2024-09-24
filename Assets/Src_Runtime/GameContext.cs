using UnityEngine;

namespace VRProj {

    public class GameContext {

        // ==== Entities ====
        public GameUniqueEntity gameUniqueEntity;
        public RoleRepo roleRepo;

        // ==== Infrastructure ====
        public CameraCore cameraCore;
        public AssetsCore assetsCore;
        public InputCore inputCore;

        // ==== Services ====
        public IDService idService;

        public GameContext() {

            gameUniqueEntity = new GameUniqueEntity();
            roleRepo = new RoleRepo();

            cameraCore = new CameraCore();
            assetsCore = new AssetsCore();
            inputCore = new InputCore();

            idService = new IDService();

        }

        // 所有函数只 Get
        public RoleEntity Role_GetOwner() {
            bool has = roleRepo.TryGet(gameUniqueEntity.roleOwnerID, out RoleEntity entity);
            if (!has) {
                Debug.LogError("GameContext.Role_GetOwner: roleOwnerID not found");
                return null;
            }
            return entity;
        }

    }
}