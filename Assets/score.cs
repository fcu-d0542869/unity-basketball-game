using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {

  public int mScore = 0;
  public float vSbarValue = 0;
  public int t_valueUpDown = 0;

  // Start is called before the first frame update
  void Start () {
    GetComponent<Rigidbody> ().isKinematic = true;
  }

  // Update is called once per frame
  void Update () {
    if (Input.GetButtonDown ("Fire1")) {
      GetComponent<Rigidbody> ().isKinematic = false;
      GetComponent<Rigidbody> ().AddForce (Vector3.up * 60);
      GetComponent<Rigidbody> ().AddForce (Vector3.forward * 16);
    }

    float translation = Time.deltaTime * 10;
    if (vSbarValue > 9f) {
      t_valueUpDown = 1;
    }
    if (vSbarValue < 0) {
      t_valueUpDown = 0;
    }
    if (t_valueUpDown == 0) {
      vSbarValue = vSbarValue + translation;
    } else {
      vSbarValue = vSbarValue - translation;
    }
  }

  void OnTriggerExit (Collider other) {
    mScore = mScore + 1;
    // Destroy (other.gameObject);
  }

  void OnGUI () {
    GUI.Label (new Rect (0, 0, 400, 400), "Score: " + mScore);
    GUI.VerticalScrollbar (new Rect (25, 20, 100, 120), vSbarValue, 1f, 10f, 0);
  }
}