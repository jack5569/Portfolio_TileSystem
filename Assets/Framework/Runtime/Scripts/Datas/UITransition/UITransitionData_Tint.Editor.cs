using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace J_Framework
{
    public partial class UITransitionData_Tint
    {
#if UNITY_EDITOR

        public override IEnumerable<Type> Editor_GetRequiredTypes()
        {
            return new Type[] {
                typeof(RectTransform),
                typeof(Image)
            };
        }

        public override void Editor_SetToEndState(GameObject ui)
        {
            Image image = ui.GetComponent<Image>();
            image.color = ResultTintColor;
        }

#endif
    }
}
