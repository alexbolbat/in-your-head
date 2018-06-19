using System;
using UnityEngine;

namespace ZSG.Controller
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action FireStart;
        public event Action FireEnd;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireStart.Call();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                FireEnd.Call();
            }
        }
    }
}
