using System;
using UnityEngine;

namespace VRProj {

    public class RoleInputComponent {

        public Vector2 moveAxis;
        public Vector2 rotateAxis;

        public RoleInputComponent() {
            moveAxis = Vector2.zero;
            rotateAxis = Vector2.zero;
        }

    }

}