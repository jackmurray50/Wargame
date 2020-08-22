using System.Collections.Generic;
using UnityEngine;

namespace SLS.Widgets.Table {
  public class KitchenSink: MonoBehaviour {

    public Table table;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    private bool started;
    private int colCount;
    private int rowCount;
    private Dictionary<string, Sprite> spriteDict;

    void Start() {

      MakeDefaults.Set();
      this.spriteDict = new Dictionary<string, Sprite>();
      this.spriteDict.Add("1", this.sprite1);
      this.spriteDict.Add("2", this.sprite2);
      this.spriteDict.Add("3", this.sprite3);
      this.spriteDict.Add("4", this.sprite4);
      this.spriteDict.Add("5", this.sprite5);

      this.DoTable(30, 1000, true);
    }

    private void DoTable(int numCols, int numRows, bool initial = false) {

      this.colCount = numCols;
      this.rowCount = numRows;

      this.table.ResetTable();

      System.Random rand = new System.Random();
      Datum d;

      for(int i = 0; i < this.colCount; i++) {
        Column c;
        if(initial) {
          if(i == 0 || i == 1) {
            c = this.table.AddImageColumn("ICON_" + i.ToString(),
                                          "Foot" + i.ToString(), 50, 50);
          }
          else {
            c = this.table.AddTextColumn("TEXT_" + i.ToString(),
                                    "Foot" + i.ToString());
            if(i == 2)
              c.horAlignment = Column.HorAlignment.CENTER;
            if(i == 3)
              c.horAlignment = Column.HorAlignment.RIGHT;
          }
        }
      }

      this.table.Initialize(this.SelectionCallback, this.spriteDict);

      char[] cnames = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

      List<string> keyList = new List<string>
                               (this.spriteDict.Keys);

      for(int i = 0; i < this.rowCount; i++) {
        d = Datum.Body(i.ToString());
        for(int j = 0; j < this.table.columns.Count; j++) {
          if(j == 0 || j == 1)
            d.elements.Add(keyList[rand.Next(keyList.Count)]);
          else if(j == 3)
            d.elements.Add(rand.Next(9).ToString());
          else
            d.elements.Add
              (i.ToString() + ":" + cnames[j].ToString());
        }
        this.table.data.Add(d);
      }

      this.table.StartRenderEngine();

    }

    private void SelectionCallback(Datum d) {
      print(d.uid);
    }

  }
}