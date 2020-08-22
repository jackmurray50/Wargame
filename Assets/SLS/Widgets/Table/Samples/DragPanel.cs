using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace SLS.Widgets.Table {
  public class DragPanel: MonoBehaviour, IPointerDownHandler, IDragHandler {

    private Vector2 originalLocalPointerPosition;
    private Vector3 originalPanelLocalPosition;
    private RectTransform panelRectTransform;
    private RectTransform parentRectTransform;

    void Start() {
      this.panelRectTransform = this.transform.parent as RectTransform;
      this.parentRectTransform = this.panelRectTransform.parent as RectTransform;
    }

    public void OnPointerDown(PointerEventData data) {
      this.originalPanelLocalPosition = this.panelRectTransform.anchoredPosition;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(this.parentRectTransform, data.position, data.pressEventCamera,
                                                              out this.originalLocalPointerPosition);
    }

    public void OnDrag(PointerEventData data) {
      if(this.panelRectTransform == null || this.parentRectTransform == null)
        return;

      Vector2 localPointerPosition;
      if(RectTransformUtility.ScreenPointToLocalPointInRectangle(this.parentRectTransform, data.position, data.pressEventCamera,
                                                                 out localPointerPosition)) {
        Vector3 offsetToOriginal = localPointerPosition - this.originalLocalPointerPosition;
        this.panelRectTransform.anchoredPosition = this.originalPanelLocalPosition + offsetToOriginal;
      }

      this.ClampToWindow();
    }

    // Clamp panel to area of parent
    void ClampToWindow() {
      Vector3 pos = this.panelRectTransform.anchoredPosition;

      Vector3 minPosition = this.parentRectTransform.rect.min - this.panelRectTransform.rect.min;
      Vector3 maxPosition = this.parentRectTransform.rect.max - this.panelRectTransform.rect.max;

      pos.x = Mathf.Clamp(this.panelRectTransform.anchoredPosition.x, minPosition.x, maxPosition.x);
      pos.y = Mathf.Clamp(this.panelRectTransform.anchoredPosition.y, minPosition.y, maxPosition.y);

      this.panelRectTransform.anchoredPosition = pos;
    }
  }
}