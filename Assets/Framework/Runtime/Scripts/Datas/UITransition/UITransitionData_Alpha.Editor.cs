using System;
using System.Collections.Generic;
using UnityEngine;

namespace J_Framework
{
    public partial class UITransitionData_Alpha : UITransitionDataBase
    {
#if UNITY_EDITOR

        public override IEnumerable<Type> Editor_GetRequiredTypes()
        {
            return new Type[] {
                typeof(RectTransform),
                typeof(CanvasGroup)
            };
        }

        public override void Editor_SetToEndState(GameObject ui)
        {
            CanvasGroup canvasGroup = ui.GetComponent<CanvasGroup>();
            canvasGroup.alpha = _targetAlpha;
        }

#endif
    }
}
