using UnityEngine;
using UnityEditor;
#if TMP_PRESENT
using TMPro;
#endif

namespace SLS.Widgets.Table {

  [CustomEditor(typeof(Table))]
  public class TableEditor: Editor {

    protected static bool showGeneral = false;
    protected static bool showHeader = false;
    protected static bool showFooter = false;
    protected static bool showRow = false;
    protected static bool showExtraText = false;
    protected static bool showScrollbar = false;
    SerializedProperty font;
    SerializedProperty fontStyle;
    SerializedProperty use2DMask;
    SerializedProperty fillerSprite;

    // GENERAL SETTINGS
    SerializedProperty defaultFontSize;
    SerializedProperty scrollSensitivity;
    SerializedProperty leftMargin;
    SerializedProperty rightMargin;
    SerializedProperty horizontalSpacing;
    SerializedProperty bodyBackgroundColor;
    SerializedProperty columnLineColor;
    SerializedProperty columnLineWidth;
    SerializedProperty min100PercentWidth;
    SerializedProperty max100PercentWidth;
    SerializedProperty spinnerSprite;
    SerializedProperty spinnerColor;
    SerializedProperty rowAnimationDuration;
    SerializedProperty selectionMode;
    SerializedProperty alwaysMultiSelect;
    SerializedProperty multiSelectKey;
    SerializedProperty showHoverColors;
    SerializedProperty drawGizmos;
    SerializedProperty gizmoColor;

    // HEADER SETTINGS
    SerializedProperty minHeaderHeight;
    SerializedProperty headerTopMargin;
    SerializedProperty headerBottomMargin;
    SerializedProperty headerNormalColor;
    SerializedProperty headerHoverColor;
    SerializedProperty headerDownColor;
    SerializedProperty headerBorderColor;
    SerializedProperty headerTextColor;
    SerializedProperty headerIconWidth;
    SerializedProperty headerIconHeight;

    // FOOTER SETTINGS
    SerializedProperty minFooterHeight;
    SerializedProperty footerTopMargin;
    SerializedProperty footerBottomMargin;
    SerializedProperty footerBackgroundColor;
    SerializedProperty footerBorderColor;
    SerializedProperty footerTextColor;

    // ROW SETTINGS
    SerializedProperty minRowHeight;
    SerializedProperty rowVerticalSpacing;
    SerializedProperty rowLineColor;
    SerializedProperty rowLineHeight;
    SerializedProperty rowNormalColor;
    SerializedProperty rowAltColor;
    SerializedProperty rowHoverColor;
    SerializedProperty rowDownColor;
    SerializedProperty rowSelectColor;
    SerializedProperty rowTextColor;
    SerializedProperty cellHoverColor;
    SerializedProperty cellDownColor;
    SerializedProperty cellSelectColor;

    // EXTRA TEXT
    SerializedProperty extraTextWidthRatio;
    SerializedProperty extraTextBoxColor;
    SerializedProperty extraTextColor;

    // SCROLLBAR
    SerializedProperty scrollBarSize;
    SerializedProperty scrollBarBackround;
    SerializedProperty scrollBarForeground;

    virtual protected void OnEnable() {

      this.font = this.serializedObject.FindProperty("font");
      this.fontStyle = this.serializedObject.FindProperty("fontStyle");
      this.use2DMask = this.serializedObject.FindProperty("use2DMask");
      this.fillerSprite = this.serializedObject.FindProperty("fillerSprite");

      // GENERAL SETTINGS
      this.defaultFontSize = this.serializedObject.FindProperty("defaultFontSize");
      this.scrollSensitivity = this.serializedObject.FindProperty("scrollSensitivity");
      this.leftMargin = this.serializedObject.FindProperty("leftMargin");
      this.rightMargin = this.serializedObject.FindProperty("rightMargin");
      this.horizontalSpacing = this.serializedObject.FindProperty("horizontalSpacing");
      this.bodyBackgroundColor = this.serializedObject.FindProperty("bodyBackgroundColor");
      this.columnLineColor = this.serializedObject.FindProperty("columnLineColor");
      this.columnLineWidth = this.serializedObject.FindProperty("columnLineWidth");
      this.min100PercentWidth = this.serializedObject.FindProperty("min100PercentWidth");
      this.max100PercentWidth = this.serializedObject.FindProperty("max100PercentWidth");
      this.spinnerSprite = this.serializedObject.FindProperty("spinnerSprite");
      this.spinnerColor = this.serializedObject.FindProperty("spinnerColor");
      this.rowAnimationDuration = this.serializedObject.FindProperty("rowAnimationDuration");
      this.selectionMode = this.serializedObject.FindProperty("selectionMode");
      this.alwaysMultiSelect = this.serializedObject.FindProperty("alwaysMultiSelect");
      this.multiSelectKey = this.serializedObject.FindProperty("multiSelectKey");
      this.showHoverColors = this.serializedObject.FindProperty("showHoverColors");
      this.drawGizmos = this.serializedObject.FindProperty("drawGizmos");
      this.gizmoColor = this.serializedObject.FindProperty("gizmoColor");
      // HEADER SETTINGS
      this.minHeaderHeight = this.serializedObject.FindProperty("minHeaderHeight");
      this.headerTopMargin = this.serializedObject.FindProperty("headerTopMargin");
      this.headerBottomMargin = this.serializedObject.FindProperty("headerBottomMargin");
      this.headerNormalColor = this.serializedObject.FindProperty("headerNormalColor");
      this.headerHoverColor = this.serializedObject.FindProperty("headerHoverColor");
      this.headerDownColor = this.serializedObject.FindProperty("headerDownColor");
      this.headerBorderColor = this.serializedObject.FindProperty("headerBorderColor");
      this.headerTextColor = this.serializedObject.FindProperty("headerTextColor");
      this.headerIconHeight = this.serializedObject.FindProperty("headerIconHeight");
      this.headerIconWidth = this.serializedObject.FindProperty("headerIconWidth");
      // FOOTER SETTINGS
      this.minFooterHeight = this.serializedObject.FindProperty("minFooterHeight");
      this.footerTopMargin = this.serializedObject.FindProperty("footerTopMargin");
      this.footerBottomMargin = this.serializedObject.FindProperty("footerBottomMargin");
      this.footerBackgroundColor = this.serializedObject.FindProperty("footerBackgroundColor");
      this.footerBorderColor = this.serializedObject.FindProperty("footerBorderColor");
      this.footerTextColor = this.serializedObject.FindProperty("footerTextColor");
      // ROW SETTINGS
      this.minRowHeight = this.serializedObject.FindProperty("minRowHeight");
      this.rowVerticalSpacing = this.serializedObject.FindProperty("rowVerticalSpacing");
      this.rowLineColor = this.serializedObject.FindProperty("rowLineColor");
      this.rowLineHeight = this.serializedObject.FindProperty("rowLineHeight");
      this.rowNormalColor = this.serializedObject.FindProperty("rowNormalColor");
      this.rowAltColor = this.serializedObject.FindProperty("rowAltColor");
      this.rowHoverColor = this.serializedObject.FindProperty("rowHoverColor");
      this.rowDownColor = this.serializedObject.FindProperty("rowDownColor");
      this.rowSelectColor = this.serializedObject.FindProperty("rowSelectColor");
      this.rowTextColor = this.serializedObject.FindProperty("rowTextColor");
      this.cellHoverColor = this.serializedObject.FindProperty("cellHoverColor");
      this.cellDownColor = this.serializedObject.FindProperty("cellDownColor");
      this.cellSelectColor = this.serializedObject.FindProperty("cellSelectColor");
      // EXTRA TEXT
      this.extraTextWidthRatio = this.serializedObject.FindProperty("extraTextWidthRatio");
      this.extraTextBoxColor = this.serializedObject.FindProperty("extraTextBoxColor");
      this.extraTextColor = this.serializedObject.FindProperty("extraTextColor");
      // SCROLLBAR
      this.scrollBarSize = this.serializedObject.FindProperty("scrollBarSize");
      this.scrollBarBackround = this.serializedObject.FindProperty("scrollBarBackround");
      this.scrollBarForeground = this.serializedObject.FindProperty("scrollBarForeground");
    }

    public override void OnInspectorGUI() {

      if(Application.isPlaying) {
        EditorGUILayout.HelpBox("Edit disabled in Play mode.",
                                MessageType.Info, true);
        return;
      }

      this.serializedObject.Update();

      //Table table = (Table)target;

      EditorGUILayout.Space();

      GUILayout.BeginHorizontal();
      GUILayout.Label("Load Preset");
      if(GUILayout.Button("Light") &&
         EditorUtility.DisplayDialog("Load Light Preset?",
                                     "All current table settings will be overwritten!",
                                     "Continue", "Cancel")) {
        Debug.Log("Applying 'Light' Table Preset");
        this.applyLightTheme();
      }
      if(GUILayout.Button("Dark") &&
         EditorUtility.DisplayDialog("Load Dark Preset?",
                                     "All current table settings will be overwritten!",
                                     "Continue", "Cancel")) {
        Debug.Log("Applying 'Dark' Table Preset");
        this.applyDarkTheme();
      }
      GUILayout.EndHorizontal();

      EditorGUILayout.Space();

      EditorGUILayout.PropertyField
        (this.font, new GUIContent("Font"));
      EditorGUILayout.PropertyField
        (this.fontStyle, new GUIContent("Font Style"));
      EditorGUILayout.PropertyField
        (this.use2DMask, new GUIContent("Use 2D Mask"));
      EditorGUILayout.PropertyField
        (this.fillerSprite, new GUIContent("Filler Sprite"));

      EditorGUILayout.Space();

      showGeneral = EditorGUILayout.Foldout
                      (showGeneral, "General Settings");

      if(showGeneral) {
        EditorGUILayout.PropertyField
          (this.defaultFontSize, new GUIContent("Font Size"));
        EditorGUILayout.PropertyField
          (this.scrollSensitivity, new GUIContent("Scroll Sensitivity"));
        EditorGUILayout.PropertyField
          (this.leftMargin, new GUIContent("Left Margin"));
        EditorGUILayout.PropertyField
          (this.rightMargin, new GUIContent("Right Margin"));
        EditorGUILayout.PropertyField
          (this.horizontalSpacing, new GUIContent("Horizontal Spacing"));
        EditorGUILayout.PropertyField
          (this.bodyBackgroundColor, new GUIContent("Background"));
        EditorGUILayout.PropertyField
          (this.columnLineColor, new GUIContent("Column Line Color"));
        EditorGUILayout.PropertyField
          (this.columnLineWidth, new GUIContent("Column Line Width"));
        EditorGUILayout.PropertyField
          (this.min100PercentWidth, new GUIContent("Force 100% Width Min"));
        EditorGUILayout.PropertyField
          (this.max100PercentWidth, new GUIContent("Restrict 100% Width Max"));
        EditorGUILayout.PropertyField
          (this.spinnerSprite, new GUIContent("Spinner Sprite"));
        EditorGUILayout.PropertyField
          (this.spinnerColor, new GUIContent("Spinner Sprite Color"));
        EditorGUILayout.PropertyField
          (this.rowAnimationDuration, new GUIContent("Row Animation Duration"));
        EditorGUILayout.PropertyField
          (this.selectionMode, new GUIContent("Table Selection UI Mode"));
        if(this.selectionMode.enumValueIndex == 2 ||
            this.selectionMode.enumValueIndex == 3) {
          EditorGUILayout.PropertyField
            (this.alwaysMultiSelect, new GUIContent("Always Multi Select"));
          if(!this.alwaysMultiSelect.boolValue) {
            EditorGUILayout.PropertyField
              (this.multiSelectKey, new GUIContent("Multi Select Key"));
          }
        }
        EditorGUILayout.PropertyField
          (this.showHoverColors, new GUIContent("Show Hover Colors"));
        EditorGUILayout.PropertyField
          (this.drawGizmos, new GUIContent("Draw Editor Gizmo"));
        EditorGUILayout.PropertyField
          (this.gizmoColor, new GUIContent("Gizmo Color"));
      }

      showHeader = EditorGUILayout.Foldout
                     (showHeader, "Header Settings");

      if(showHeader) {
        EditorGUILayout.PropertyField
          (this.minHeaderHeight, new GUIContent("Minimum Height"));
        EditorGUILayout.PropertyField
          (this.headerTopMargin, new GUIContent("Top Margin"));
        EditorGUILayout.PropertyField
          (this.headerBottomMargin, new GUIContent("Bottom Margin"));
        EditorGUILayout.PropertyField
          (this.headerNormalColor, new GUIContent("Normal Background"));
        EditorGUILayout.PropertyField
          (this.headerHoverColor, new GUIContent("Hover Background"));
        EditorGUILayout.PropertyField
          (this.headerDownColor, new GUIContent("Down Background"));
        EditorGUILayout.PropertyField
          (this.headerBorderColor, new GUIContent("Border Line"));
        EditorGUILayout.PropertyField
          (this.headerTextColor, new GUIContent("Text"));
        EditorGUILayout.PropertyField
          (this.headerIconHeight, new GUIContent("Icon Height"));
        EditorGUILayout.PropertyField
          (this.headerIconWidth, new GUIContent("Icon Width"));
      }

      showFooter = EditorGUILayout.Foldout
                     (showFooter, "Footer Settings");

      if(showFooter) {
        EditorGUILayout.PropertyField
          (this.minFooterHeight, new GUIContent("Minimum Height"));
        EditorGUILayout.PropertyField
          (this.footerTopMargin, new GUIContent("Top Margin"));
        EditorGUILayout.PropertyField
          (this.footerBottomMargin, new GUIContent("Bottom Margin"));
        EditorGUILayout.PropertyField
          (this.footerBackgroundColor, new GUIContent("Background"));
        EditorGUILayout.PropertyField
          (this.footerBorderColor, new GUIContent("Border Line"));
        EditorGUILayout.PropertyField
          (this.footerTextColor, new GUIContent("Text"));
      }

      showRow = EditorGUILayout.Foldout
                  (showRow, "Data Row Settings");

      if(showRow) {
        EditorGUILayout.PropertyField
          (this.minRowHeight, new GUIContent("Minimum Height"));
        EditorGUILayout.PropertyField
          (this.rowVerticalSpacing, new GUIContent("Vertical Spacing"));
        EditorGUILayout.PropertyField
          (this.rowLineColor, new GUIContent("Line Color"));
        EditorGUILayout.PropertyField
          (this.rowLineHeight, new GUIContent("Line Height"));
        EditorGUILayout.PropertyField
          (this.rowNormalColor, new GUIContent("Normal Background"));
        EditorGUILayout.PropertyField
          (this.rowAltColor, new GUIContent("Alt Normal Background"));
        EditorGUILayout.PropertyField
          (this.rowHoverColor, new GUIContent("Hover Background"));
        EditorGUILayout.PropertyField
          (this.rowDownColor, new GUIContent("Down Background"));
        EditorGUILayout.PropertyField
          (this.rowSelectColor, new GUIContent("Select Background"));
        EditorGUILayout.PropertyField
          (this.rowTextColor, new GUIContent("Text"));
        EditorGUILayout.PropertyField
          (this.cellHoverColor, new GUIContent("Cell Hover Background"));
        EditorGUILayout.PropertyField
          (this.cellDownColor, new GUIContent("Cell Down Background"));
        EditorGUILayout.PropertyField
          (this.cellSelectColor, new GUIContent("Cell Select Background"));
      }

      showExtraText = EditorGUILayout.Foldout
                        (showExtraText, "Extra Text Settings");

      if(showExtraText) {
        EditorGUILayout.HelpBox("Datum objects contains an optional" +
                                " extraText attribute.  If assigned, this data will display" +
                                " outside the normal column layout.", MessageType.Info, true);
        EditorGUILayout.HelpBox("The 'Width Ratio' should be a value" +
                                " between 0 and 1 and corresponds to the normalized percent" +
                                " width we should consume.", MessageType.Info, true);
        EditorGUILayout.PropertyField
          (this.extraTextWidthRatio, new GUIContent("Width Ratio"));
        EditorGUILayout.PropertyField
          (this.extraTextBoxColor, new GUIContent("Background"));
        EditorGUILayout.PropertyField
          (this.extraTextColor, new GUIContent("Text"));
      }

      showScrollbar = EditorGUILayout.Foldout
                        (showScrollbar, "Scrollbar Settings");

      if(showScrollbar) {
        EditorGUILayout.PropertyField
          (this.scrollBarSize, new GUIContent("Bar Size"));
        EditorGUILayout.PropertyField
          (this.scrollBarForeground, new GUIContent("Foreground"));
        EditorGUILayout.PropertyField
          (this.scrollBarBackround, new GUIContent("Background"));
      }

      /*
          table.defaultFontSize =
            EditorGUILayout.IntField("Default Font Size",
              table.defaultFontSize);
          EditorGUILayout.LabelField("Something", table.font.ToString());


          GUILayout.BeginHorizontal();
          GUILayout.Label("Scroll Sensitivity");
          table.scrollSensitivity =
            EditorGUILayout.IntField
              (table.scrollSensitivity, GUILayout.Width(50));
          GUILayout.EndHorizontal();

          GUILayout.BeginHorizontal();
          GUILayout.Label("Text Color");
          table.rowTextColor =
            EditorGUILayout.ColorField
              (table.rowTextColor, GUILayout.Width(50));
          GUILayout.EndHorizontal();

          if (Application.isPlaying) {
            if (GUILayout.Button("Apply to Running Table")) {
              Debug.Log("something");
            }
          }
       */

      this.serializedObject.ApplyModifiedProperties();

    } // OnInspectorGUI


    private void applyLightTheme() {

      Table table = (Table)this.target;

#if TMP_PRESENT
      table.fontStyle = FontStyles.Bold;
#else
      table.fontStyle = FontStyle.Bold;
#endif

      // GENERAL SETTINGS
      table.defaultFontSize = 12;
      table.scrollSensitivity = 5;
      table.leftMargin = 8;
      table.rightMargin = 8;
      table.horizontalSpacing = 8;
      table.bodyBackgroundColor = new Color(1, 1, 1, 1);
      table.columnLineColor = new Color(0, 0, 0, .5f);
      table.columnLineWidth = 2;
      table.spinnerColor = new Color(0.8f, 0.8f, 0.8f, 1f);
      table.min100PercentWidth = true;
      table.max100PercentWidth = false;
      table.rowAnimationDuration = 0.5f;
      table.selectionMode = Table.SelectionMode.CELL;
      table.multiSelectKey = Table.MultiSelectKey.SHIFT;
      table.alwaysMultiSelect = false;
      table.showHoverColors = true;
      table.drawGizmos = false;
      table.gizmoColor = new Color(0.4f, 0.4f, 0f, 0.6f);

      // HEADER SETTINGS
      table.minHeaderHeight = 30;
      table.headerTopMargin = 10;
      table.headerBottomMargin = 10;
      table.headerNormalColor = new Color(.8f, .8f, .8f, 1f);
      table.headerHoverColor = new Color(.9f, .9f, .9f, 1f);
      table.headerDownColor = new Color(.8f, .8f, .8f, 1f);
      table.headerBorderColor = new Color(0, 0, 0, .5f);
      table.headerTextColor = new Color(0, 0, 0, 1f);
      table.headerIconHeight = 16;
      table.headerIconWidth = 8;

      // FOOTER SETTINGS
      table.minFooterHeight = 20;
      table.footerTopMargin = 8;
      table.footerBottomMargin = 8;
      table.footerBackgroundColor = new Color(.9f, .9f, .9f, .9f);
      table.footerBorderColor = new Color(0, 0, 0, .5f);
      table.footerTextColor = new Color(0, 0, 0, 1f);

      // ROW SETTINGS
      table.minRowHeight = 20;
      table.rowVerticalSpacing = 10;
      table.rowLineColor = new Color(0, 0, 0, .5f);
      table.rowLineHeight = 2;
      table.rowNormalColor = new Color(1, 1, 1, 1f);
      table.rowAltColor = new Color(0.90f, 0.90f, 0.90f, 1f);
      table.rowHoverColor = new Color(.8f, .8f, .8f, 1f);
      table.rowDownColor = new Color(1f, 1f, 1f, 1f);
      table.rowSelectColor = new Color(.7f, .7f, .7f, 1f);
      table.rowTextColor = new Color(0, 0, 0, 1f);
      table.cellHoverColor = new Color(.95f, .95f, .95f, 1f);
      table.cellDownColor = new Color(1f, 1f, 1f, 9f);
      table.cellSelectColor = new Color(.95f, .95f, .95f, 1f);

      // EXTRA TEXT
      table.extraTextWidthRatio = 0.9f;
      table.extraTextBoxColor = new Color(1, 1, 1, 1f);
      table.extraTextColor = new Color(0, 0, 0, 1f);

      // SCROLLBAR
      table.scrollBarSize = 10;
      table.scrollBarBackround = new Color(.5f, .5f, .5f, .1f);
      table.scrollBarForeground = new Color(.5f, .5f, .5f, .5f);

      this.serializedObject.Update();
    }

    private void applyDarkTheme() {

      Table table = (Table)this.target;

#if TMP_PRESENT
      table.fontStyle = FontStyles.Bold;
#else
      table.fontStyle = FontStyle.Bold;
#endif

      // GENERAL SETTINGS
      table.defaultFontSize = 12;
      table.scrollSensitivity = 5;
      table.leftMargin = 8;
      table.rightMargin = 8;
      table.horizontalSpacing = 8;
      table.bodyBackgroundColor = new Color(0, 0, 0, 1);
      table.columnLineColor = new Color(1, 1, 1, .2f);
      table.columnLineWidth = 2;
      table.spinnerColor = new Color(0.15f, 0.15f, 0.15f, 1f);
      table.min100PercentWidth = true;
      table.max100PercentWidth = false;
      table.rowAnimationDuration = 0.5f;
      table.selectionMode = Table.SelectionMode.CELL;
      table.multiSelectKey = Table.MultiSelectKey.SHIFT;
      table.alwaysMultiSelect = false;
      table.showHoverColors = true;
      table.drawGizmos = false;
      table.gizmoColor = new Color(0.4f, 0.4f, 0f, 0.6f);

      // HEADER SETTINGS
      table.minHeaderHeight = 30;
      table.headerTopMargin = 10;
      table.headerBottomMargin = 10;
      table.headerNormalColor = new Color(.15f, .15f, .15f, 1f);
      table.headerHoverColor = new Color(.25f, .25f, .25f, 1f);
      table.headerDownColor = new Color(.10f, .10f, .10f, 1f);
      table.headerBorderColor = new Color(1, 1, 1, .5f);
      table.headerTextColor = new Color(1, 1, 1, 1f);
      table.headerIconHeight = 16;
      table.headerIconWidth = 8;

      // FOOTER SETTINGS
      table.minFooterHeight = 20;
      table.footerTopMargin = 8;
      table.footerBottomMargin = 8;
      table.footerBackgroundColor = new Color(.15f, .15f, .15f, 1f);
      table.footerBorderColor = new Color(1, 1, 1, .5f);
      table.footerTextColor = new Color(1, 1, 1, 1f);

      // ROW SETTINGS
      table.minRowHeight = 20;
      table.rowVerticalSpacing = 10;
      table.rowLineColor = new Color(1, 1, 1, .2f);
      table.rowLineHeight = 2;
      table.rowNormalColor = new Color(0.05f, 0.05f, 0.05f, 1f);
      table.rowAltColor = new Color(0.1f, 0.1f, 0.1f, 1f);
      table.rowHoverColor = new Color(.2f, .2f, .2f, 1f);
      table.rowDownColor = new Color(.0f, .0f, .0f, 1f);
      table.rowSelectColor = new Color(.3f, .3f, .3f, 1f);
      table.rowTextColor = new Color(1, 1, 1, 1f);
      table.cellHoverColor = new Color(.3f, .3f, .3f, 1f);
      table.cellDownColor = new Color(.1f, .1f, .1f, 1f);
      table.cellSelectColor = new Color(.5f, .5f, .5f, 1f);

      // EXTRA TEXT
      table.extraTextWidthRatio = 0.9f;
      table.extraTextBoxColor = new Color(0, 0, 0, 1f);
      table.extraTextColor = new Color(1, 1, 1, 1f);

      // SCROLLBAR
      table.scrollBarSize = 10;
      table.scrollBarBackround = new Color(.5f, .5f, .5f, .1f);
      table.scrollBarForeground = new Color(.5f, .5f, .5f, .5f);

      this.serializedObject.Update();
    }

  }
}