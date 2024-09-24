using System;
using UnityEngine;
using UnityEngine.XR;
using VRProj.InputInterval;

namespace VRProj {

    public class InputCore {

        InputCoreContext ctx;

        public InputCore() {
            ctx = new InputCoreContext();

            ctx.inputActions.Enable();
        }

        public void Tick(float dt) {

            // 处理输入
            InputEntity rightHand = ctx.rightHand;
            {
                Vector2 moveAixs = ctx.inputActions.Game.Move.ReadValue<Vector2>();
                rightHand.moveAxis = moveAixs;
            }

            {
                // RotateAxis
                Vector2 rotateAxis = Vector2.zero;
                if (Input.GetMouseButton(1)) {
                    rotateAxis = Input.mousePositionDelta;
                }

                rightHand.rotateAxis = rotateAxis;
            }
        }

        public Vector2 GetMoveAxis() {
            return ctx.rightHand.moveAxis;
        }

        public Vector2 GetRotateAxis() {
            return ctx.rightHand.rotateAxis;
        }

    }

}