using System;
using UnityEngine;

namespace VRProj {

    public static class Business_Game {

        public static void Enter(GameContext ctx) {
            RoleEntity owner = RoleDomain.Spawn(ctx, 0, Vector3.zero, Quaternion.identity);
            ctx.gameUniqueEntity.roleOwnerID = owner.id;
        }

        public static void Tick(GameContext ctx, float dt) {

            GameUniqueEntity game = ctx.gameUniqueEntity;

            // ProcessInput
            PreTick(ctx, dt);

            // DoLogic
            ref float restTime = ref game.restTime;
            restTime += dt;
            const float FIX_INTERVAL = 0.01f;
            if (restTime < FIX_INTERVAL) {
                FixTick(ctx, restTime);
                restTime = 0;
            } else {
                while (restTime >= FIX_INTERVAL) {
                    FixTick(ctx, FIX_INTERVAL);
                    restTime -= FIX_INTERVAL;
                }
            }

            // UI, 相机, 特效, Audio
            LateTick(ctx, dt);

        }

        static void PreTick(GameContext ctx, float dt) {
            // 输入
            InputCore input = ctx.inputCore;
            input.Tick(dt);

            // 赋值给主角
            var owner = ctx.Role_GetOwner();
            RoleInputComponent inputComponent = owner.inputComponent;
            inputComponent.moveAxis = input.GetMoveAxis();
            inputComponent.rotateAxis = input.GetRotateAxis();
        }

        static void FixTick(GameContext ctx, float fixdt) {
            // 移动
            var owner = ctx.Role_GetOwner();
            RoleDomain.Move(ctx, owner, fixdt);
            RoleDomain.RotateFace(ctx, owner, fixdt);
        }

        public static void LateTick(GameContext ctx, float dt) {
            // 相机
            var owner = ctx.Role_GetOwner();
            Vector2 offset = new Vector2(0, 0);
            ctx.cameraCore.Tick(owner.transform.position, offset, 0, owner.transform.forward, dt);
        }

    }
}