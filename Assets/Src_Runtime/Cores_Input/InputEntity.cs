using System;
using UnityEngine;

namespace VRProj.InputInterval {

    public class InputEntity {

        public int id; // 左手还是右手

        public Vector2 moveAxis;
        public Vector2 rotateAxis;

        public InputEntity() {
            moveAxis = Vector2.zero;
            rotateAxis = Vector2.zero;
        }

    }

}