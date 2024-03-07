﻿// realvirtual (R) Framework for Automation Concept Design, Virtual Commissioning and 3D-HMI
// (c) 2019 realvirtual GmbH - Usage of this source code only allowed based on License conditions see https://realvirtual.io/en/company/license

using realvirtual;
using UnityEngine;

namespace realvirtual
{
    [RequireComponent(typeof(Lamp))]
    //! PLC Inputs and Outputs for a Lamp. Can be added to the Lamp component
    public class Lamp_Connection : BehaviorInterface
    {
       
     

        [Header("PLC IOs")] 
        public PLCOutputBool LampOn; //!< Lamp On
        public PLCOutputBool FlashingOn; //!< Lamp fleshing on
        public PLCOutputFloat Period; //!< Fleshing period in seconds of the lamp

        private Lamp Lamp; 
        
        // Use this for initialization
        void Start()
        {
            Lamp = GetComponent<Lamp>();
        }

        // Update is called once per frame
        void Update()
        {
            // Get external PLC Outputs
            if (LampOn != null)
                Lamp.LampOn= LampOn.Value;
            if (FlashingOn != null)
                Lamp.Flashing = FlashingOn.Value;
            if (Period != null)
                Lamp.Period = Period.Value;
            
            
        }
    }
}