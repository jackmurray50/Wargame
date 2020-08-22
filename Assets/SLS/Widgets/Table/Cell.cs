using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Globalization;
#if TMP_PRESENT
using TMPro;
#endif

namespace SLS.Widgets.Table {
  public class Cell: VisibleComponent, IPointerEnterHandler,
    IPointerExitHandler, IPointerDownHandler, IPointerUpHandler,
    IPointerClickHandler {

    public Column column { protected set; get; }

    public RectTransform crt;
#if TMP_PRESENT
    public TextMeshProUGUI text;
#else
    public Text text;
#endif
    public Image image;
    public Image background;
    protected bool isDown;

    //public Cell preceedingCell;

    protected Table table;

    public Row row { protected set; get; }

    private Action<Datum, Column> clickCallback;
    private Action<Datum, Column, PointerEventData> clickCallbackWithData;

#if !TABLE_PRO_DISABLE_VISIBILITY_TEST
    protected bool _isRefreshPending;
    protected bool _isSetColorPending;
#endif

    public void SetContentSizeDelta(Vector2 size) {
      if(this.text != null)
        this.text.rectTransform.sizeDelta = size;
      /* we don't want to adjust the size of our image, it's set staticly in the factory
         if (this.image != null)
         this.image.rectTransform.sizeDelta = size;
       */
    }

    public void SetContentLocalPosition(float x, float y) {
      if(this.text != null)
        this.text.rectTransform.localPosition = new Vector2(x, y);
      if(this.image != null) {
        this.image.rectTransform.localPosition = new Vector2(this.image.rectTransform.localPosition.x,
                                                             (this.table.rowVerticalSpacing * -0.5f) -
                                                             (this.row.datum.SafeCellHeight() * 0.5f));
      }
    }

#if !TABLE_PRO_DISABLE_VISIBILITY_TEST
    protected override void BecameVisible() {
      if(this._isRefreshPending) {
        this._isRefreshPending = false;
        this.AttachElement();
      }

      if(this._isSetColorPending) {
        this._isSetColorPending = false;
        this.SetColor();
      }
    }
#endif

    // reset UI state if table is deactivated and reactivated
    private void OnEnable() {
      if(this.table == null)
        return;
      this.isDown = false;
      this.SetColor();
    }

#if TMP_PRESENT
    public bool Initialize(Table table, Row row, Column column, int idx,
                           RectTransform rt, RectTransform guts, TextMeshProUGUI text) {
#else
    public bool Initialize(Table table, Row row, Column column, int idx,
                           RectTransform rt, RectTransform guts, Text text) {
#endif
      this.text = text;
      return this.FinishInit(table, row, column, idx, rt, guts);
    }

    public bool Initialize(Table table, Row row, Column column, int idx,
                           RectTransform rt, RectTransform guts, Image image) {
      this.image = image;
      return this.FinishInit(table, row, column, idx, rt, guts);
    }

    private bool FinishInit(Table table, Row row, Column column, int idx,
                            RectTransform rt, RectTransform guts) {
      this.table = table;
      this.row = row;
      this.column = column;
      this._rt = rt;
      this.crt = guts;
      if(idx >= row.cells.Count)
        row.cells.Add(this);
      else {
        row.cells[idx] = this;
      }
      // we do this here to handle initial render after a 'redraw'
      if(this._element != null)
        this.AttachElement();
      return true;
    }

    private Element _element;

    public Element element {
      set {
        this.doingDirtyLater = false;
        this._element = value;
        this.AttachElement();
      }
      get {
        return this._element;
      }
    }

    private void AttachElement() {
#if !TABLE_PRO_DISABLE_VISIBILITY_TEST
      if(this.ShouldPostponeUpdate()) {
        this._isRefreshPending = true;
        return;
      }
      this._isFirstUpdate = false;
#endif

      if(this.column.columnType == Column.ColumnType.TEXT ||
         this.row.datum.isHeader || this.row.datum.isFooter) {
        if(this._element != null && !string.IsNullOrEmpty(this._element.value))
          this.text.text = this._element.value;
        else
          this.text.text = "";
        if(this._element != null && this._element.color.HasValue) {
          this.text.color = this._element.color.Value;
        }
        else {
          if(!this.row.datum.isHeader && !this.row.datum.isFooter) {
            this.text.color = this.table.rowTextColor;
          }
          else if(this.row.datum.isHeader) {
            this.text.color = this.table.headerTextColor;
          }
          else {
            this.text.color = this.table.footerTextColor;
          }
        }
        if(this._element != null && this._element.backgroundColor.HasValue)
          this.background.color = this._element.backgroundColor.Value;
      }
      else {
        if(this._element != null &&
           !string.IsNullOrEmpty(this._element.value) &&
           this.table.sprites.ContainsKey(this._element.value))
          this.image.sprite = this.table.sprites[this._element.value];
        else
          this.image.sprite = null;
        if(this._element != null && this._element.color.HasValue) {
          if(this.image.color != this._element.color.Value) {
            this.image.color = this._element.color.Value;
            this.DirtyLater();
          }
        }
        else {
          if(this.image.color != Color.white) {
            this.image.color = Color.white;
            this.DirtyLater();
          }
        }
      }
      // The header color can be overridden through the column's 'headerTextColorOverride' property
      if(this._element.datum.isHeader)
        this.text.color = this.column.headerTextColorOverride;

      this.SetColor();
    }

    private bool doingDirtyLater;

    private void DirtyLater() {
      if(!this.doingDirtyLater)
        this.StartCoroutine(this.DoDirtyLater());
    }

    // our icon's dont color on first draw for some reason.
    //  Use this little hack to check them later
    IEnumerator DoDirtyLater() {
      this.doingDirtyLater = true;
      yield return Table.WaitForEndOfFrame;
      this.doingDirtyLater = false;
      if(this.image != null && this._element != null) {
        if(this._element.color.HasValue) {
          if(this._element.color.Value != this.image.color)
            this.image.color = this._element.color.Value;
        }
        else {
          if(Color.white != this.image.color)
            this.image.color = Color.white;
        }
      }
    }

    virtual public void HandleClick(PointerEventData data) {
      if(this.table.selectionMode == Table.SelectionMode.CELL || this.table.selectionMode == Table.SelectionMode.ROW) {
        this.table.SetSelected(this.row.datum, this.column);
      }
      else {

        // do a range selection in this specific case
        if(!this.table.alwaysMultiSelect && this.table.lastSelectedDatum != null && this.table.lastSelectedColumn != null &&
            this.table.multiSelectKey == Table.MultiSelectKey.CONTROL &&
            (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) {
          this.table.selectedDatumSet.Clear();
          this.table.selectedDatumColumnDict.Clear();

          int lastColIdx = this.table.lastSelectedColumn.idx;
          int thisColIdx = this.column.idx;

          int lastRowIdx = this.table.data.IndexOf(this.table.lastSelectedDatum);
          int thisRowIdx = this.table.data.IndexOf(this.row.datum);

          int minRowIdx = Math.Min(lastRowIdx, thisRowIdx);
          int maxRowIdx = Math.Max(lastRowIdx, thisRowIdx);

          for(int i = minRowIdx; i < this.table.data.Count; i++) {
            Datum d = this.table.data[i];
            if(i == minRowIdx && minRowIdx != maxRowIdx) {
              if(lastRowIdx < thisRowIdx)
                for(int j = lastColIdx; j < this.table.columns.Count; j++) {
                  this.table.SetSelected(d, this.table.columns[j]);
                }
              else
                for(int j = thisColIdx; j < this.table.columns.Count; j++) {
                  this.table.SetSelected(d, this.table.columns[j]);
                }
            }
            else if(i == maxRowIdx) {
              if(minRowIdx == maxRowIdx) {
                int minColIdx = Math.Min(lastColIdx, thisColIdx);
                int maxColIdx = Math.Max(lastColIdx, thisColIdx);
                for(int j = minColIdx; j <= maxColIdx; j++) {
                  this.table.SetSelected(d, this.table.columns[j]);
                }
              }
              else {
                if(lastRowIdx > thisRowIdx)
                  for(int j = 0; j <= lastColIdx; j++) {
                    this.table.SetSelected(d, this.table.columns[j]);
                  }
                else
                  for(int j = 0; j <= thisColIdx; j++) {
                    this.table.SetSelected(d, this.table.columns[j]);
                  }
              }
              break;
            }
            else {
              for(int j = 0; j < this.table.columns.Count; j++) {
                this.table.SetSelected(d, this.table.columns[j]);
              }
            }
          }
        }

        // add selection if shift down
        else if(this.table.alwaysMultiSelect ||
            (this.table.multiSelectKey == Table.MultiSelectKey.SHIFT &&
             (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) ||
            (this.table.multiSelectKey == Table.MultiSelectKey.CONTROL &&
             (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))) {
          // remove selection if we clicked something already selected w/ shift
          if(this.table.selectedDatumColumnDict.ContainsKey(this.row.datum) &&
              this.table.selectedDatumColumnDict[this.row.datum].Contains(this.column)) {
            this.table.selectedDatumColumnDict[this.row.datum].Remove(this.column);
            if(this.table.selectedDatumColumnDict[this.row.datum].Count == 0) {
              if(this.table.selectedDatumSet.Contains(this.row.datum)) {
                this.table.selectedDatumSet.Remove(this.row.datum);
              }
            }
            this.row.SetColor();
            this.table.SetDeselected(this.row.datum, this.column);
          }
          else {
            this.table.SetSelected(this.row.datum, this.column);
          }
        }

        else {
          //print("HANDLE CLICK! " + this.row.datum.uid);
          // remove EXISTING selection if we clicked something w/o shift
          this.table.selectedDatumSet.Clear();
          this.table.selectedDatumColumnDict.Clear();
          // if the thing we clicked wasn't already selected, select it now
          if(!this.table.selectedDatumColumnDict.ContainsKey(this.row.datum) ||
              !this.table.selectedDatumColumnDict[this.row.datum].Contains(this.column)) {
            this.table.SetSelected(this.row.datum, this.column);
          }
        }

      }
    }

    virtual public void SetColor() {
#if !TABLE_PRO_DISABLE_VISIBILITY_TEST
      if(this.ShouldPostponeUpdate()) {
        this._isSetColorPending = true;
        return;
      }
#endif

      if(this.row.datum != null && this.row.datum.isFooter) {
        this.background.color = this.table.footerBackgroundColor;
        return;
      }
      if(this.table.bodyScrollWatcher.isDragging) {
        if(this.row.datum != null && this.table.selectedDatumSet.Contains(this.row.datum)) {
          if(this.table.selectedDatumColumnDict[this.row.datum].Contains(this.column))
            this.background.color = this.table.cellSelectColor;
          else if(this.table.selectionMode == Table.SelectionMode.ROW || this.table.selectionMode == Table.SelectionMode.MULTIROW)
            this.background.color = this.table.rowSelectColor;
          else {
            if(this.row.datum != null && this.row.datum.isEvenRow)
              this.background.color = this.table.rowAltColor;
            else
              this.background.color = this.table.rowNormalColor;
          }
        }
        else {
          if(this._element != null && this._element.backgroundColor.HasValue)
            this.background.color = this._element.backgroundColor.Value;
          else {
            if(this.row.datum != null && this.row.datum.isEvenRow)
              this.background.color = this.table.rowAltColor;
            else
              this.background.color = this.table.rowNormalColor;
          }
        }
      }
      else if(this.table.IsPointerOver(this) && (this.table.selectionMode == Table.SelectionMode.CELL ||
                                                  this.table.selectionMode == Table.SelectionMode.MULTICELL)) {
        if(this.isDown)
          this.background.color = this.table.cellDownColor;
        else {
          if(this.row.datum != null && this.table.selectedDatumSet.Contains(this.row.datum)) {
            //print(this.column.idx + ": " + (this.column == this.table.selectedColumn).ToString());
            //print(this.table.selectedColumn);
            if(this.table.selectedDatumColumnDict[this.row.datum].Contains(this.column))
              this.background.color = this.table.cellSelectColor;
            else
              this.background.color = this.table.cellHoverColor;
          }
          else
            this.background.color = this.table.cellHoverColor;
        }
      }
      else if(this.table.IsPointerOver(this.row)) {
        if(this.row.isDown)
          this.background.color = this.table.rowDownColor;
        else {
          if(this.row.datum != null && this.table.selectedDatumSet.Contains(this.row.datum)) {
            //print(this.column.idx + ": " + (this.column == this.table.selectedColumn).ToString());
            //print(this.table.selectedColumn);
            if(this.table.selectionMode == Table.SelectionMode.ROW ||
                this.table.selectionMode == Table.SelectionMode.MULTIROW) {
              this.background.color = this.table.cellSelectColor;
            }
            else {
              if(this.table.selectedDatumColumnDict[this.row.datum].Contains(this.column))
                this.background.color = this.table.cellSelectColor;
              else
                this.background.color = this.table.rowHoverColor;
            }
          }
          else
            this.background.color = this.table.rowHoverColor;
        }
      }
      else {
        if(this.row.datum != null && this.table.selectedDatumSet.Contains(this.row.datum)) {
          //print(this.column.idx + ": " + (this.column == this.table.selectedColumn).ToString());
          //print(this.table.selectedColumn);
          if(this.table.selectedDatumColumnDict[this.row.datum].Contains(this.column))
            this.background.color = this.table.cellSelectColor;
          else if(this.table.selectionMode == Table.SelectionMode.ROW ||
                   this.table.selectionMode == Table.SelectionMode.MULTIROW)
            this.background.color = this.table.rowSelectColor;
          else {
            if(this.row.datum != null && this.row.datum.isEvenRow)
              this.background.color = this.table.rowAltColor;
            else
              this.background.color = this.table.rowNormalColor;
          }
        }
        else {
          if(this._element != null && this._element.backgroundColor.HasValue)
            this.background.color = this._element.backgroundColor.Value;
          else {
            if(this.row.datum != null && this.row.datum.isEvenRow)
              this.background.color = this.table.rowAltColor;
            else
              this.background.color = this.table.rowNormalColor;
          }
        }
      }
    }

    public void OnPointerEnter(PointerEventData data) {
      if(this._element != null && this._element.datum.isHeader && this.table.headerActiveCallback != null)
        if(!this.table.headerActiveCallback(this.column))
          return;
      this.table.SetPointerOverCell(this);
      if(this.table.tooltipHandler != null && this._element != null &&
         !string.IsNullOrEmpty(this._element.tooltip))
        this.table.tooltipHandler(this.rt, this._element.tooltip);
      this.row.ColorCells();
    }

    public void OnPointerExit(PointerEventData data) {
      if(this._element != null && this._element.datum.isHeader && this.table.headerActiveCallback != null)
        if(!this.table.headerActiveCallback(this.column))
          return;
      this.table.SetPointerOverCell(null);
      this.row.ColorCells();
    }

    public void OnPointerDown(PointerEventData data) {
      if(this._element != null && this._element.datum.isHeader && this.table.headerActiveCallback != null) {
        if(!this.table.headerActiveCallback(this.column)) {
          return;
        }
      }
      if(this.table.pointerDownHandler != null) {
        this.table.pointerDownHandler(data, this.element.datum);
      }
      this.isDown = true;
      this.row.isDown = true;
      this.row.ColorCells();
      this.Invoke("TriggerLongPressEvent", this.longPressWait);
    }

    public void OnPointerUp(PointerEventData data) {
      if(this._element != null && this._element.datum.isHeader && this.table.headerActiveCallback != null) {
        if(!this.table.headerActiveCallback(this.column)) {
          return;
        }
      }
      if(this.table.pointerUpHandler != null) {
        this.table.pointerUpHandler(data, this.element.datum);
      }
      this.CancelInvoke("TriggerLongPressEvent");
      this.isDown = false;
      this.row.isDown = false;
      this.row.ColorCells();
    }

    private float longPressWait = 1f;
    private void TriggerLongPressEvent() {
      if(this.table.onCellLongPress != null && this.element != null && !this.element.datum.isHeader &&
          !this.element.datum.isFooter) {
        this.table.onCellLongPress(this.element, this.text != null ? this.text.text : "");
      }
    }

    public void OnPointerClick(PointerEventData data) {
      if(this._element != null && this._element.datum.isHeader && this.table.headerActiveCallback != null)
        if(!this.table.headerActiveCallback(this.column))
          return;
      this.HandleClick(data);
    }
  }
}