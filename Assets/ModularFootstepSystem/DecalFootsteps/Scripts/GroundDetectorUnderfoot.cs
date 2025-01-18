namespace ModularFootstepSystem
{
    using UnityEngine;

    /// <summary>
    /// Surface detector under the foot. 
    /// Provides surface type and point of contact between foot and ground.
    /// </summary>
    public class GroundDetectorUnderfoot : MonoBehaviour
    {
        protected const float MIN_DETECTING_DISTANCE_TO_GROUND = 0.01f;

        protected const int MIN_FOOT_UP_POSITION_SHIFT = 0;

        /// <summary>
        /// Type of surface underfoot.
        /// </summary>
        public virtual string SurfaceType => surfaceType;

        /// <summary>
        /// Component "Transform" of the foot.
        /// </summary>
        public virtual Transform FootTranform => footTranform;

        /// <summary>
        /// A point on the surface of the earth under the foot.
        /// </summary>
        public virtual RaycastHit GroundHit => hit;

        /// <summary>
        /// Foot on the ground?
        /// </summary>
        public virtual bool IsGrounded => isGrounded;

        [SerializeField]
        protected Transform footTranform = default;

        [SerializeField, Min(MIN_DETECTING_DISTANCE_TO_GROUND)]
        protected float detectingDistanceToGround = 0.4f;
        [SerializeField, Min(MIN_FOOT_UP_POSITION_SHIFT)]
        protected float footUpPositionShift = 0.1f;

        protected Vector3 positionOfGroundUnderfoot = Vector3.zero;
        protected Vector3 stepDirection = Vector3.zero;
        protected Vector3 shiftedFootPosition = Vector3.zero;

        protected RaycastHit hit = default;

        protected string surfaceType = string.Empty;

        protected AbstractSurface surface = default;

        protected bool isGrounded = false;

        /// <summary>
        /// Find the ground under your foot.
        /// </summary>
        /// <remarks>
        /// Performs a raycast perpendicular to the ground. 
        /// If the surface contains the "AbstractSurface" component, 
        /// then the foot is considered to be on the surface.
        /// A point on the surface from the raycast is copied, 
        /// the surface type and a flag that the step was successful
        /// </remarks>
        public virtual void DetectGround()
        {
            shiftedFootPosition = footTranform.position;
            shiftedFootPosition.y += footUpPositionShift;

            if (Physics.Raycast(shiftedFootPosition, Vector3.down, out hit, detectingDistanceToGround))
            {
                if(hit.transform.TryGetComponent(out surface))
                {
                    positionOfGroundUnderfoot = hit.point;
                    surfaceType = surface.GetSurfaceType(positionOfGroundUnderfoot);
                    isGrounded = surfaceType != null;
                }
                else
                {
                    isGrounded = false;
                }
            }
            else
            {
                isGrounded = false;
            }
        }
    }
}