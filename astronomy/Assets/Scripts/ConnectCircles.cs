using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ConnectCircles : MonoBehaviour, IDragHandler, IEndDragHandler
{
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.2F;
        lineRenderer.endWidth = 0.2F;
        lineRenderer.positionCount = 2;
    }

    public void OnDrag(PointerEventData data)
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, this.gameObject.transform.position);
        lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(new Vector3(data.position.x, data.position.y, 10)));
        if (data.hovered.Count == 1)
        {
            lineRenderer.SetPosition(0, this.gameObject.transform.position);
            lineRenderer.SetPosition(1, data.hovered[0].transform.position);
            return;
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (data.hovered.Count == 1)
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, this.gameObject.transform.position);
            lineRenderer.SetPosition(1, data.hovered[0].transform.position);
        }
    }
}