using System.Collections;
using System.Collections.Generic;
using Core.Input.Keys;
using UnityEngine;

namespace Core.Fighting.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private Transform _self;
        [SerializeField] private GameObject _fistLeftObject;
        [SerializeField] private GameObject _fistRightObject;
        private Transform _fistLeft, fistRight;

        private void Awake()
        {
            _self = transform;
        }
        public void SetFlip(bool flip)
        {
            _self.localScale = new Vector3(flip ? -1 : 1, 1, 1);
        }
    }
}