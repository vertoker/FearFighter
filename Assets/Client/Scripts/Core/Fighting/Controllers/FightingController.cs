using System.Collections;
using System.Collections.Generic;
using Core.Entities.Controllers;
using Core.Input.Keys;
using UnityEngine;

namespace Core.Fighting.Controllers
{
    public class FightingController : InputBlock
    {
        private Transform _self;

        private void Awake()
        {
            _self = transform;
        }
        public virtual void SetFlip(bool flip)
        {
            _self.localScale = new Vector3(flip ? -1 : 1, 1, 1);
        }
    }
}