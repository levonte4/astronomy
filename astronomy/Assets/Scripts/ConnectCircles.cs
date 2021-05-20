using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ConnectCircles : MonoBehaviour, IDragHandler, IEndDragHandler
{
    void Update()
    {
        if (!gameObject.TryGetComponent(out LineRenderer x))
        { 
            LineRenderer line = gameObject.AddComponent<LineRenderer>();
            line.startWidth = 0.2F;
            line.endWidth = 0.2F;
            line.positionCount = 2;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.SetPosition(0, this.gameObject.transform.position);
        line.SetPosition(1, Camera.main.ScreenToWorldPoint(new Vector3(data.position.x, data.position.y, 1)));
        if (data.hovered.Count == 1)
        {
            line.SetPosition(0, this.gameObject.transform.position);
            line.SetPosition(1, data.hovered[0].transform.position);
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (data.hovered.Count == 1)
        {
            LineRenderer line = GetComponent<LineRenderer>();
            line.SetPosition(0, this.gameObject.transform.position);
            line.SetPosition(1, data.hovered[0].transform.position);
        }
        else
        {
            LineRenderer line = GetComponent<LineRenderer>();
            Destroy(line);
        }
    }
}