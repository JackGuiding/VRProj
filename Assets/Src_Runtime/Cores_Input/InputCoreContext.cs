using System;
using UnityEngine;

namespace VRProj.InputInterval {

    public class InputCoreContext {

        public InputEntity rightHand;
        public InputActions inputActions;

        public InputCoreContext() {

            rightHand = new InputEntity();
            rightHand.id = 1;

            inputActions = new InputActions();

        }

    }

}