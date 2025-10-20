using UnityEngine;

namespace J_Framework
{
    public static class CustomMathfUtils
    {
        public static float RoundToDecimalPlaces(float input, int places)
        {
            int processedInput = Mathf.RoundToInt(input * Mathf.Pow(10.0f, places));
            return processedInput / Mathf.Pow(10.0f, places);
        }
    }
}