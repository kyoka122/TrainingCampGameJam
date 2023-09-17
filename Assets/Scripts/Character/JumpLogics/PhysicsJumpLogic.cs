using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.JumpLogics
{
    public class PhysicsJumpLogic: IJumpLogic
    {
        private float _acceleration;
        private float _speed;

        public PhysicsJumpLogic()
        {
            _acceleration = Physics.gravity.y;
            _speed = 0;
        }

        public void Jump(float power)
        {
            _speed = power;
        }

        public float GetDeltaHeight(float deltaTime)
        {
            _speed += _acceleration * deltaTime;
            return _speed * deltaTime;
        }
    }
}
