using System;

namespace GestureSystem
{
    public static class FingerComparer
    {
        public static double qPoint = 0.25; 
        public static double hPoint = 0.5;
        public static double lPoint = 0.75;

        /// <returns>True if the given curl data matches the given conditions.</returns>
        public static bool FingersMatch(FingerState[] _conditions, float[] _curlData)
        {
            for (int i = 0; i < _conditions.Length; i++)
            {
                //  If there are no conditions for a finger, skip the iteration, as the finger does not matter.
                if (_conditions[i].HasFlag(FingerState.None)) continue;

                //  If a condtion does not have the flag of the current finger state, the gesture is incorrect.
                if (!_conditions[i].HasFlag(GetFingerStateFromCurl(_curlData[i]))) return false;
            }
            return true;
        }

        private static bool CurlMatchesFingerState(FingerState _condition, float _curl)
        {
            var curl = Math.Round((double)_curl);

            return _condition switch
            {
                FingerState.Straight    => curl < qPoint,
                FingerState.SlightBend  => curl >= qPoint   && curl < hPoint,
                FingerState.HalfBend    => curl >= hPoint   && curl < lPoint,
                FingerState.FullBend    => curl >= lPoint,
                _                       => false,
            };
        }

        private static FingerState GetFingerStateFromCurl(float _curl)
        {
            var curl = Math.Round((double)_curl);

            if (curl < qPoint)                      return FingerState.Straight;
            if (curl >= qPoint && curl < hPoint)    return FingerState.SlightBend;
            if (curl >= hPoint && curl < lPoint)    return FingerState.HalfBend;
            if (curl >= lPoint)                     return FingerState.FullBend;

            return FingerState.None;
        }
    }
}
