using System;
using UnityEngine;

namespace VRProj {

    public class RoleEntity : MonoBehaviour {

        public int id;

        public RoleInputComponent inputComponent;

        public void Ctor() {
            inputComponent = new RoleInputComponent();
        }

    }

}