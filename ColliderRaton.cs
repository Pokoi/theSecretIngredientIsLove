using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRaton : MonoBehaviour
{
    [HideInInspector]
    public static Vector2 MouseColliderPos;
    void Update () {

        MouseColliderPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = MouseColliderPos;
        FileteManager.Cuchillo.transform.position = ColliderRaton.MouseColliderPos - new Vector2(FileteManager.Cuchillo.transform.GetChild(0).localPosition.x, FileteManager.Cuchillo.transform.GetChild(0).localPosition.y);
        FileteManager.Cuchillo.transform.position = new Vector3(FileteManager.Cuchillo.transform.position.x, FileteManager.Cuchillo.transform.position.y, -10);

    }
}
