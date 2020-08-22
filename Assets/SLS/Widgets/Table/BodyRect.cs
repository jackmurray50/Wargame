using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SLS.Widgets.Table {
  public class BodyRect: UIBehaviour {

    private Table _table;
    private RectTransform _rt;
    public bool isMeasured;
    public float lastWidth;

    public Table table {
      get {
        return this._table;
      }
    }

    public RectTransform rt {
      get {
        return this._rt;
      }
    }

    public void Init(Table t, RectTransform rt) {
      this._table = t;
      this._rt = rt;
    }

    override protected void OnRectTransformDimensionsChange() {
      if(!this.isMeasured || this.lastWidth != this.rt.rect.width) {
        this.lastWidth = this.rt.rect.width;
        base.OnRectTransformDimensionsChange();
        this.table.DirtyLater();
      }
      this.isMeasured = true;
    }

  }
}