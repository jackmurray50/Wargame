using UnityEngine;

namespace SLS.Widgets.Table {
  public class Spinner: MonoBehaviour {
    public float speed = 80f;
    void Update() {
      this.transform.Rotate(Vector3.back, this.speed * Time.smoothDeltaTime);
    }
  }
}