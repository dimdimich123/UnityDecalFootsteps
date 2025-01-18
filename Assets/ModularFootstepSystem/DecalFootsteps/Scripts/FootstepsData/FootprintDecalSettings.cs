namespace ModularFootstepSystem
{
    using UnityEngine;

    /// <summary>
    /// Footprint decal settings.
    /// </summary>
    [CreateAssetMenu(fileName = nameof(FootprintDecalSettings), menuName = "ModularFootstepSystem/" + nameof(FootprintDecalSettings))]
    public class FootprintDecalSettings : ScriptableObject
    {
        /// <summary>
        /// The "NearClipPlane" parameter of the <see cref="Projector"/> component.
        /// </summary>
        public virtual float NearClipPlane => nearClipPlane;

        /// <summary>
        /// The "FarClipPlane" parameter of the <see cref="Projector"/> component.
        /// </summary>
        public virtual float FarClipPlane => farClipPlane;

        /// <summary>
        /// The "FieldOfView" parameter of the <see cref="Projector"/> component.
        /// </summary>
        public virtual float FieldOfView => fieldOfView;

        /// <summary>
        /// The "AspectRatio" parameter of the <see cref="Projector"/> component.
        /// </summary>
        public virtual float AspectRatio => aspectRatio;

        /// <summary>
        /// The "Orthographic" parameter of the <see cref="Projector"/> component.
        /// </summary>
        public virtual bool Orthographic => orthographic;

        /// <summary>
        /// The "OrthographicSize" parameter of the <see cref="Projector"/> component.
        /// </summary>
        public virtual float OrthographicSize => orthographicSize;

        /// <summary>
        /// Footprint decal material. Contains an image of the footprint and a normal if available.
        /// </summary>
        public virtual Material Material => material;

        /// <summary>
        /// Ignored layers when displaying decals.
        /// </summary>
        public virtual LayerMask IgnoreLayers => ignoreLayers;

        [SerializeField]
        protected float nearClipPlane = 0f;
        [SerializeField]
        protected float farClipPlane = 0f;
        [SerializeField]
        protected float fieldOfView = 0f;
        [SerializeField]
        protected float aspectRatio = 0f;
        [SerializeField]
        protected bool orthographic = true;
        [SerializeField]
        protected float orthographicSize = 0f;

        [SerializeField]
        protected Material material = default;

        [SerializeField]
        protected LayerMask ignoreLayers = default;
    }
}