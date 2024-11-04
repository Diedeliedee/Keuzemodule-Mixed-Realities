using UnityEngine;

namespace GestureSystem
{
    [System.Serializable]
    public class MovementConditions
    {
                        public Vector3 requiredMovement = new(0f, 0f, 0.3f);
        [Min(0.01f)]    public float movementSpan       = 0.2f;

        public Vector3 velocity
        {
            get
            {
                if (movementSpan == 0f)
                {
                    Debug.LogWarning("You can't divide by zero!! Set 'movementSpan' variable to at least a positive number");
                    return Vector3.zero;
                }

                return requiredMovement / movementSpan;
            }
        }
    }
}
