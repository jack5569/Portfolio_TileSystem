using System;
using System.Text;
using UnityEngine.UIElements;

namespace J_Framework.Editor
{
    public static class UITransitionDataEditorUtils
    {
        public static HelpBox GetRequiredTypesHelpBox(UITransitionDataBase transitionData)
        {
            StringBuilder text = new StringBuilder("This ui transition data required following type on the game object:");
            foreach (Type requiredType in transitionData.Editor_GetRequiredTypes())
                text.Append($"\n- {requiredType.Name}");

            HelpBox helpBox = new HelpBox(text.ToString(), HelpBoxMessageType.Info);
            helpBox.style.fontSize = 20;
            return helpBox;
        }
    }
}
