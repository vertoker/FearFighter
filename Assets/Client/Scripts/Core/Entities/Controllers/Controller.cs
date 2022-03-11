using Core.Entities.Interfaces;
using Core.Input.Keys;
using UnityEngine;

namespace Core.Entities.Controllers
{
    public class Controller : MonoBehaviour, IInput
    {
        [System.Serializable]
        class ControllerBlock
        {
            [SerializeField] private InputBlock _block;
            [SerializeField] private bool movement = false;
            [SerializeField] private bool worldInteraction = false;
            [SerializeField] private bool fighting = false;
            [SerializeField] private bool switchWeapon = false;

            public InputBlock Block => _block;
            public bool Movement => movement;
            public bool WorldInteraction => worldInteraction;
            public bool Fighting => fighting;
            public bool SwitchWeapon => switchWeapon;
        }

        [SerializeField] private ControllerBlock[] _blocks;

        public void Move(Vector2 direction)
        {
            foreach (var block in _blocks)
                if (block.Movement)
                    block.Block.Move(direction);
        }
        public void Press(KeyWorldInteraction key)
        {
            foreach (var block in _blocks)
                if (block.WorldInteraction)
                    block.Block.Press(key);
        }
        public void Press(KeyFighting key)
        {
            foreach (var block in _blocks)
                if (block.Fighting)
                    block.Block.Press(key);
        }
        public void Press(KeySwitchWeapon key)
        {
            foreach (var block in _blocks)
                if (block.SwitchWeapon)
                    block.Block.Press(key);
        }
    }
}