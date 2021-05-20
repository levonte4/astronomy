using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DeleteLines : MonoBehaviour
{
    int time = 0;
    void Update()
    {
        if (gameObject.TryGetComponent(out LineRenderer x))
        {
            LineRenderer line = GetComponent<LineRenderer>();
            var pos1 = line.GetPosition(0);
            var pos2 = line.GetPosition(1);
            var pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var delta = 0.3;
            if ((Math.Abs(pointerPos.x - (pos1.x + pos2.x) / 2) < delta) &
                (Math.Abs(pointerPos.y - (pos1.y + pos2.y) / 2) < delta) &
                Input.GetMouseButton(0)) //Input.touchCount > 0 for mobiles
            {
                time++;
                if (time > 200)
                    Destroy(line);
            }
            if (Input.GetMouseButtonUp(0))
            {
                time = 0;
            }
        }
    }
}
