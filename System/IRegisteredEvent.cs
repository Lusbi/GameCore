using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public interface IRegisteredEvent
    {
        void Registered();

        void UnRegistered();
    }
}