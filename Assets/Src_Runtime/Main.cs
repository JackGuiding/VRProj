using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRProj {

    public class Main : MonoBehaviour {

        [SerializeField] Camera mainCam;

        GameContext ctx;

        bool isInit;
        bool isTearDown;

        void Awake() {

            // ==== Ctor ====
            ctx = new GameContext();

            // ==== Inject ====
            ctx.cameraCore.Inject(mainCam);

            // ==== Init ====
            Action action = async () => {
                await ctx.assetsCore.LoadAll();
                isInit = true;

                // ==== Enter ====
                RoleDomain.Spawn(ctx, 0, Vector3.zero, Quaternion.identity);

            };
            action.Invoke();

        }

        void Update() {

            if (!isInit) {
                return;
            }

            float dt = Time.deltaTime;
            Business_Game.Tick(ctx, dt);

        }

        void LateUpdate() {

            if (!isInit) {
                return;
            }

            float dt = Time.deltaTime;
            Business_Game.LateTick(ctx, dt);

        }

        void OnApplicationQuit() {
            TearDown();
        }

        void OnDestroy() {
            TearDown();
        }

        void TearDown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;

            ctx.assetsCore.UnloadAll();
        }

    }

}
