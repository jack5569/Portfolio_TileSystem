using System;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework
{
    public partial class UITransitionData_Scale
    {
#if UNITY_EDITOR

        public override IEnumerable<Type> Editor_GetRequiredTypes()
        {
            return new Type[] {
                typeof(RectTransform)
            };
        }

        public override void Editor_SetToEndState(GameObject ui)
        {
            RectTransform rectTransform = (RectTransform)ui.transform;
            rectTransform.localScale = Vector3.one * _targetScale;
        }

#endif
    }
}
