using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace SLS.Widgets.Table {
  public class ResizePanel: MonoBehaviour, IPointerDownHandler, IDragHandler {

    public Vector2 minSize;
    public Vector2 maxSize;

    private RectTransform rectTransform;
    private Vector2 currentPointerPosition;
    private Vector2 previousPointerPosition;

    void Awake() {
      //rectTransform = transform.parent.GetComponent<RectTransform>();
      this.rectTransform = this.transform.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData data) {
      this.rectTransform.SetAsLastSibling();
      RectTransformUtility.ScreenPointToLocalPointInRectangle(this.rectTransform, data.position, data.pressEventCamera,
                                                               out this.previousPointerPosition);
    }

    public void OnDrag(PointerEventData data) {
      if(this.rectTransform == null)
        return;

      Vector2 sizeDelta = this.rectTransform.sizeDelta;

      RectTransformUtility.ScreenPointToLocalPointInRectangle(this.rectTransform, data.position, data.pressEventCamera,
                                                               out this.currentPointerPosition);
      Vector2 resizeValue = this.currentPointerPosition - this.previousPointerPosition;

      sizeDelta += new Vector2(-resizeValue.x, -resizeValue.y);
      sizeDelta = new Vector2(
        Mathf.Clamp(sizeDelta.x, this.minSize.x, this.maxSize.x),
        Mathf.Clamp(sizeDelta.y, this.minSize.y, this.maxSize.y)
        );

      this.rectTransform.sizeDelta = sizeDelta;

      this.previousPointerPosition = this.currentPointerPosition;
    }
  }
}