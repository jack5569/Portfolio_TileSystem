using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace J_Framework
{
    [CreateAssetMenu(menuName = "Data/UI Transition/Composite", order = 11)]
    public class CompositeUITransitionData : ScriptableObject
    {
        [SerializeField] private UITransitionDataBase[] _transitionDatas;

        public IEnumerable<Tween> GetTweens(GameObject ui, TweenCallback onCompleted = null)
        {
            UITransitionDataBase transitionDataWithLongestDuration = GetTransitionDataWithLongestDuration(ui);

            List<Tween> listTweens = new List<Tween>();
            foreach (UITransitionDataBase transitionData in _transitionDatas)
            {
                // Binds onCompleted callback on the tween with longest duration
                if (transitionData == transitionDataWithLongestDuration)
                    listTweens.Add(transitionData.GetTween(ui, onCompleted));
                else
                    listTweens.Add(transitionData.GetTween(ui));
            }

            return listTweens;
        }

        public float GetDuration(GameObject ui) { return GetTransitionDataWithLongestDuration(ui).GetDuration(ui); }

        private UITransitionDataBase GetTransitionDataWithLongestDuration(GameObject ui)
        {
            UITransitionDataBase result = null;
            float longestDuration = 0.0f;
            foreach (UITransitionDataBase transitionData in _transitionDatas)
            {
                if (!result)
                {
                    // If null, simply set it to the target
                    result = transitionData;
                    longestDuration = transitionData.GetDuration(ui);
                    continue;
                }

                if (transitionData.GetDuration(ui) > longestDuration)
                {
                    // Replace result with the new longest duration transition data
                    result = transitionData;
                    longestDuration = transitionData.GetDuration(ui);
                }
            }

            return result;
        }
    }
}
