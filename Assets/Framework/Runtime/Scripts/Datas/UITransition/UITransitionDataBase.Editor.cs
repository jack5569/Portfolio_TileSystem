using System;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework
{
    public abstract partial class UITransitionDataBase
    {
#if UNITY_EDITOR

        public abstract IEnumerable<Type> Editor_GetRequiredTypes();

        public abstract void Editor_SetToEndState(GameObject ui);

#endif
    }
}
