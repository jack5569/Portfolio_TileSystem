using System;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework
{
    public partial class UITransitionData_None
    {
#if UNITY_EDITOR

        public override IEnumerable<Type> Editor_GetRequiredTypes()
        {
            return new Type[] {
                typeof(RectTransform),
            };
        }

        public override void Editor_SetToEndState(GameObject ui)
        {
            ui.transform.localScale = _show ? Vector3.one : Vector3.zero;
        }

#endif
    }
}
