using System;
using UnityEngine;

namespace VRProj {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx, int typeID, Vector3 pos, Quaternion rot) {

            GameObject prefab = ctx.assetsCore.Entity_GetRole();
            if (prefab == null) {
                Debug.LogError("RoleDomain.Spawn: prefab is null");
                return null;
            }

            GameObject go = GameObject.Instantiate(prefab, pos, rot);
            RoleEntity role = go.GetComponent<RoleEntity>();
            role.Ctor();

            role.id = ctx.idService.PickRoleID();

            ctx.roleRepo.Add(role);

            return role;

        }

        public static void Unspawn(GameContext ctx, RoleEntity role) {
            ctx.roleRepo.Remove(role.id);
            GameObject.Destroy(role.gameObject);
        }

        public static void Move(GameContext ctx, RoleEntity role, float dt) {
            RoleInputComponent inputComponent = role.inputComponent;
            Vector3 moveDir = new Vector3(inputComponent.moveAxis.x, 0, inputComponent.moveAxis.y);
            moveDir.Normalize();
            moveDir = role.transform.rotation * moveDir;
            float moveSpeed = 5.5f;
            moveDir = moveDir * moveSpeed * dt;
            // RB
            role.transform.position += moveDir;
        }

        public static void RotateFace(GameContext ctx, RoleEntity role, float dt) {
            RoleInputComponent inputComponent = role.inputComponent;
            float upDown = inputComponent.rotateAxis.y;
            // TODO: 限制上下旋转角度
            Vector3 rotateDir = new Vector3(upDown, inputComponent.rotateAxis.x, 0);
            float rotateSpeed = 100;
            rotateDir = rotateDir * rotateSpeed * dt;
            role.transform.Rotate(rotateDir);
        }

    }

}