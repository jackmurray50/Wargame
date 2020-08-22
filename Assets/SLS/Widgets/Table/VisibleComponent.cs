using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SLS.Widgets.Table {
  public abstract class VisibleComponent: MonoBehaviour {
    protected RectTransform _rt;
    public RectTransform rt { get { return this._rt; } }

#if !TABLE_PRO_DISABLE_VISIBILITY_TEST
    protected bool _isFirstUpdate = true;
    protected bool _isVisible;
    public bool IsVisible { get { return this._isVisible; } }

    Canvas ParentCanvas {
      get {
        return this._parentCanvas ?? (this._parentCanvas = this.gameObject.GetComponentInParent<Canvas>());
      }
    }
    private Canvas _parentCanvas;

    private IEnumerator OnRectTransformDimensionsChange() {
      if(this._rt == null || this.ParentCanvas == null || this.ParentCanvas.renderMode == RenderMode.WorldSpace)
        yield break;

      if(CanvasUpdateRegistry.IsRebuildingLayout())
        yield return null;

      bool oldVisible = this._isVisible;
      this._isVisible = !this.ParentCanvas.pixelPerfect || VisibleComponent.IsRectVisible(this._rt);

      if(!oldVisible && this._isVisible)
        this.BecameVisible();
    }

    protected abstract void BecameVisible();

    protected virtual bool ShouldPostponeUpdate() {
      return (!this._isVisible &&
              !this._isFirstUpdate &&
              this.ParentCanvas != null &&
              this.ParentCanvas.renderMode == RenderMode.ScreenSpaceOverlay &&
              this.ParentCanvas.pixelPerfect);
    }

    public static Rect AsScreenSpace(RectTransform rectTransform) {
      Vector2 size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
      Vector2 pivot = rectTransform.pivot;

      return new Rect(rectTransform.position - new Vector3(size.x * pivot.x, size.y * pivot.y), size);
    }

    public static bool IsRectVisible(RectTransform rectTransform) {
      Rect screenBounds = new Rect(0f, 0f, Screen.width, Screen.height);

      Rect screenSpaces = AsScreenSpace(rectTransform);
      bool overlaps = screenSpaces.Overlaps(screenBounds);

      //Debug.LogFormat(rectTransform, "IsVisible ({0}) - pos: {1} size: {2} screenSpace: {3} overlaps: {4}",
      //    rectTransform.name, rectTransform.position, rectTransform.rect.size, screenSpaces, overlaps);

      return overlaps;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Rect screenSpaces = AsScreenSpace(this.rt);
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawCube(screenSpaces.center, screenSpaces.size);
    //
    //    Rect screenBounds = new Rect(0f, 0f, Screen.width, Screen.height);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawCube(screenBounds.center, screenBounds.size);
    //}
#endif
  }
}