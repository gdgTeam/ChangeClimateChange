using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        public bool MoveRight;
        public bool MoveLeft;
        public bool Move;
        public bool Running;
        public bool Jump;
        public bool Pushing;
        public bool MoveUp;
        public bool MoveDown;
        public bool Shielding;
        public bool Picking;
        public bool PickingDown;
        public bool Spiderman;

        public bool LookRight;
        public bool LookLeft;
    }
}
