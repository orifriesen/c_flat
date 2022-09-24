using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    Vector3 initMousePos, finalMousePos;
    public LineRenderer line;
    public EdgeCollider2D collider;
    public List<LineRenderer> musicLines = new List<LineRenderer>();
    public List<EdgeCollider2D> musicLineColliders = new List<EdgeCollider2D>();
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            initMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initMousePos.z = Camera.main.nearClipPlane;
            musicLines.Add(Instantiate(line));
            musicLineColliders.Add(Instantiate(collider));
            Debug.Log("click");
        }

        if(Input.GetMouseButton(0)) {
            finalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            finalMousePos.z = Camera.main.nearClipPlane;
            musicLines.Last().SetPosition(0, initMousePos);
            musicLineColliders.Last().SetPoints(new List<Vector2>(){initMousePos, finalMousePos});
            musicLines.Last().SetPosition(1, finalMousePos);
        }
    }
}
