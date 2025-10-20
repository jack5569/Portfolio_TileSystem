using System;
using System.Collections.Generic;

namespace J_Framework
{
    public static class EnumUtils
    {
        /// <summary>
        /// Return the next enum value. If it is out of range, it will return back the first value of the enum. <br/>
        /// Notes: The numeric value needs to be of int type or any numeric type that has less range than int. 
        /// </summary>
        public static TEnum GetNextValue<TEnum>(TEnum input) where TEnum : Enum
        {
            // Index locating
            int resultIndex = 0;
            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                // Break if same value detected
                if (EqualityComparer<TEnum>.Default.Equals(input, value))
                    break;

                resultIndex++;
            }

            // Move to next
            resultIndex++;

            // Out of range handling
            if (resultIndex >= Enum.GetValues(typeof(TEnum)).Length)
                resultIndex = 0;

            return (TEnum)Enum.GetValues(typeof(TEnum)).GetValue(resultIndex);
        }

        /// <summary>
        /// Return the previous enum value. If it is out of range, it will return back the last value of the enum. <br/>
        /// Notes: The numeric value needs to be of int type or any numeric type that has less range than int. 
        /// </summary>
        public static TEnum GetPreviousValue<TEnum>(TEnum input) where TEnum : Enum
        {
            // Index locating
            int resultIndex = 0;
            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                // Break if same value detected
                if (EqualityComparer<TEnum>.Default.Equals(input, value))
                    break;

                resultIndex++;
            }

            // Move to previous
            resultIndex--;

            // Out of range handling
            if (resultIndex < 0)
                resultIndex = Enum.GetValues(typeof(TEnum)).Length - 1;

            return (TEnum)Enum.GetValues(typeof(TEnum)).GetValue(resultIndex);
        }
    }
}
