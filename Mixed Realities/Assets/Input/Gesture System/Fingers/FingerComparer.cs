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
                if (_conditions[i] == 0) continue;

                //  If a condtion does not have the flag of the current finger state, the gesture is incorrect.
                if (!_conditions[i].HasFlag(GetFingerStateFromCurl(_curlData[i]))) return false;
            }
            return true;
        }

        private static bool CurlMatchesFingerState(FingerState _condition, float _curl)
        {
            return _condition switch
            {
                FingerState.Straight    => _curl < qPoint,
                FingerState.SlightBend  => _curl >= qPoint  && _curl < hPoint,
                FingerState.HalfBend    => _curl >= hPoint  && _curl < lPoint,
                FingerState.FullBend    => _curl >= lPoint,
                _                       => false,
            };
        }

        private static FingerState GetFingerStateFromCurl(float _curl)
        {
            if (_curl < qPoint)                     return FingerState.Straight;
            if (_curl >= qPoint && _curl < hPoint)  return FingerState.SlightBend;
            if (_curl >= hPoint && _curl < lPoint)  return FingerState.HalfBend;
            if (_curl >= lPoint)                    return FingerState.FullBend;

            return FingerState.None;
        }
    }
}
