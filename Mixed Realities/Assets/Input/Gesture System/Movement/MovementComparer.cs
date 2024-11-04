using UnityEngine;

namespace GestureSystem
{
    public static class MovementComparer
    {
        public static bool MatchesVelocity(Vector3 _desiredVelocity, Vector3 _velocity)
        {
            if (_desiredVelocity == Vector3.zero) return true;

            if (!ExceedsAxis(_desiredVelocity.x, _velocity.x)) return false;
            if (!ExceedsAxis(_desiredVelocity.y, _velocity.y)) return false;
            if (!ExceedsAxis(_desiredVelocity.z, _velocity.z)) return false;
            return true;
        }

        private static bool ExceedsAxis(float _axis, float _velocity)
        {
            if (_axis == 0f) return true;
            if (_axis > 0f && _velocity > _axis) return true;
            if (_axis < 0f && _velocity < _axis) return true;
            return false;
        }
    }
}
