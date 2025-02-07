﻿using HelicopterPhysics.Inputs;
using UnityEngine;
namespace HelicopterPhysics.Mechanics.Rotors
{
    public class HeliMainRotor : BaseRotor
    {

        public float MinRotationRPM = 40f;
        public override void UpdateRotor(float dps, InputController inputController)
        {
            //base.UpdateRotor(dps, inputController);
            dps = Mathf.Clamp(dps, 0f, MinRotationRPM);
            transform.Rotate(Vector3.up, dps);

            // pitch the blades up and down
            //Debug.Log(dps);
            if (LeftRotor && RightRotor)
            {
                LeftRotor.localRotation = Quaternion.Euler(
                    inputController.CurrentInput.StickyCollective * MaxPitch, 0f, 0f);
                RightRotor.localRotation = Quaternion.Euler(
                    -inputController.CurrentInput.StickyCollective * MaxPitch, 0f, 0f);

            }

        }
    }
}