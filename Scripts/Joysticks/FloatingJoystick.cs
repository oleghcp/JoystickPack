using UnityEngine.EventSystems;

namespace JoystickPack.Joysticks
{
    public class FloatingJoystick : Joystick
    {
        protected override void Start()
        {
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
    }
}
