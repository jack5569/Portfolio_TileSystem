using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace J_Framework.Editor
{
    [CustomEditor(typeof(UITransitionData_Tint))]
    public class UITransitionData_TintEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();
            InspectorElement.FillDefaultInspector(root, serializedObject, this);

            UITransitionDataBase transitionData = target as UITransitionDataBase;
            root.Add(UITransitionDataEditorUtils.GetRequiredTypesHelpBox(transitionData));

            return root;
        }
    }
}
