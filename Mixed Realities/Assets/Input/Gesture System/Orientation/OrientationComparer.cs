using UnityEngine;

namespace GestureSystem
{
    public static class OrientationComparer
    {
        public const float degreesMargin = Mathf.Rad2Deg;

        public static bool MatchesDirection(Orientation _desiredDirection, Vector3 _direction)
        {
            //  If there are no conditions, disregard the condition.
            if (_desiredDirection == 0) return true;

            //  If there are conditions. Check if the desired orientation matches the current.
            if (_desiredDirection.HasFlag(GetOrientationFromDirection(_direction))) return true;

            //  If not, return false.
            return false;
        }

        /// <summary>
        /// Transforms a direction vector into an orientation enum.
        /// </summary>
        private static Orientation GetOrientationFromDirection(Vector3 _direction)
        {
            if (Vector3.Angle(Vector3.forward,  _direction) < degreesMargin) return Orientation.Forward;
            if (Vector3.Angle(Vector3.left,     _direction) < degreesMargin) return Orientation.Left;
            if (Vector3.Angle(Vector3.right,    _direction) < degreesMargin) return Orientation.Right;
            if (Vector3.Angle(Vector3.up,       _direction) < degreesMargin) return Orientation.Upward;
            if (Vector3.Angle(Vector3.down,     _direction) < degreesMargin) return Orientation.Downward;
            if (Vector3.Angle(Vector3.back,     _direction) < degreesMargin) return Orientation.Backward;
            return Orientation.None;
        }
    }
}
