using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace J_Framework
{
    public class UITransitionPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject _ui;

        public bool IsPlaying => _tweens != null;
        public float Progress
        {
            get
            {
                // Return -1 if no tweens playing
                if (_tweens.Length <= 0)
                    return -1.0f;

                // Return the lowest progress out of all tweens
                float result = 1.0f;
                foreach (Tween tween in _tweens)
                {
                    if (tween.ElapsedPercentage() < result)
                        result = tween.ElapsedPercentage();
                }
                return result;
            }
        }

        private Tween[] _tweens;

        public void Play(CompositeUITransitionData transitionData, TweenCallback onCompleted = null)
        {
            // Kill active tween if there is
            Kill();

            // Return if no transition data
            if (!transitionData)
                return;

            // Reset once completed
            onCompleted += Reset;

            _tweens = transitionData.GetTweens(_ui, onCompleted).ToArray();
            foreach (Tween tween in _tweens)
                tween.Play();
        }

        public void Play(UITransitionDataBase transitionData, TweenCallback onCompleted = null)
        {
            // Kill active tween if there is
            Kill();

            // Return if no transition data
            if (!transitionData)
                return;

            // Reset once completed
            onCompleted += Reset;

            _tweens = new Tween[] { transitionData.GetTween(_ui, onCompleted) };
            foreach (Tween tween in _tweens)
                tween.Play();
        }

        public void Kill(bool complete = false)
        {
            // Return if no tweens ongoing
            if (_tweens == null || _tweens.Length <= 0)
                return;

            foreach (Tween tween in _tweens)
                tween.Kill(complete);

            // Manually reset in case complete boolean is false causing Reset not being triggered
            Reset();
        }

        public void GoTo(float progress)
        {
            // Return if currently no tween ongoing
            if (_tweens == null)
                return;

            // Pick longest duration
            float duration = 0.0f;
            foreach (Tween tween in _tweens)
            {
                if (tween.Duration() > duration)
                    duration = tween.Duration();
            }

            // Get elapsed time & apply
            float elapsedTime = duration * progress;
            foreach (Tween tween in _tweens)
                tween.Goto(elapsedTime, true);
        }

        private void Reset()
        {
            _tweens = null;
        }
    }
}
