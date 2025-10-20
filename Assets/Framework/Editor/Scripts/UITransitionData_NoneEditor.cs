using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace J_Framework.Editor
{
    [CustomEditor(typeof(UITransitionData_None))]
    public class UITransitionData_NoneEditor : UnityEditor.Editor
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
