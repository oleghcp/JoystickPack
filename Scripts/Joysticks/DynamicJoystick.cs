using UnityEngine;
using UnityEngine.EventSystems;

namespace JoystickPack.Joysticks
{
    public class DynamicJoystick : Joystick
    {
        [SerializeField]
        private float moveThreshold = 1f;

        public float MoveThreshold
        {
            get => moveThreshold;
            set => moveThreshold = Mathf.Abs(value);
        }

        protected override void Start()
        {
            MoveThreshold = moveThreshold;
            base.Start();
            Background.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            Background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            Background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            Background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }

        protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            if (magnitude > moveThreshold)
            {
                Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
                Background.anchoredPosition += difference;
            }
            base.HandleInput(magnitude, normalised, radius, cam);
        }
    }
}
