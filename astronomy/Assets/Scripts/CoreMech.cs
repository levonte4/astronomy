using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class CoreMech : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public CompleteScene complete;
    public bool CorrectlyConnected = false;
    public Material mat;
    public int Time = 0;
    public bool LineDrawn = false;

    void Update()
    {
        if (!gameObject.TryGetComponent(out LineRenderer x))
        {
            LineRenderer line = gameObject.AddComponent<LineRenderer>();
            line.material = mat;
            line.startWidth = 0.2F;
            line.endWidth = 0.2F;
            line.positionCount = 2;
        }
        else
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
                Time++;
                if (Time > 200)
                {
                    Destroy(line);
                    LineDrawn = false;
                    CorrectlyConnected = false;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                Time = 0;
            }
        }
        if (complete.Completed)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (!LineDrawn)
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
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (data.hovered.Count == 1 & !LineDrawn)
        {
            LineRenderer line = GetComponent<LineRenderer>();
            var pos1 = this.gameObject.transform.position;
            var pos2 = data.hovered[0].transform.position;
            line.SetPosition(0, pos1);
            line.SetPosition(1, pos2);
            LineDrawn = true;
            if (!IsLineCorrect(pos1, pos2))
            {
                line.startColor = Color.red;
                line.endColor = Color.red;
            }
            else
                CorrectlyConnected = true;
            Debug.Log(CorrectlyConnected);
        }
        else if (!LineDrawn)
        {
            LineRenderer line = GetComponent<LineRenderer>();
            Destroy(line);
            LineDrawn = false;
        }
    }

    public bool IsLineCorrect(Vector3 pos1, Vector3 pos2)
    {
        if ((pos1 == new Vector3(7f, 0f, 1f)) & (pos2 == new Vector3(4.5f, -2.5f, 1f) | pos2 == new Vector3(2.5f, 0.5f, 1f)))
            return true;
        else if ((pos1 == new Vector3(4.5f, -2.5f, 1f)) & (pos2 == new Vector3(7f, 0f, 1f)))
            return true;
        else if ((pos1 == new Vector3(2.5f, 0.5f, 1f)) & (pos2 == new Vector3(-1.5f, 2f, 1f) | pos2 == new Vector3(-3.5f, -2f, 1f) | pos2 == new Vector3(7f, 0f, 1f)))
            return true;
        else if ((pos1 == new Vector3(-1.5f, 2f, 1f)) & (pos2 == new Vector3(2.5f, 0.5f, 1f) | pos2 == new Vector3(-4f, 4f, 1f) | pos2 == new Vector3(-6.5f, 3f, 1f)))
            return true;
        else if ((pos1 == new Vector3(-4f, 4f, 1f)) & (pos2 == new Vector3(-1.5f, 2f, 1f) | pos2 == new Vector3(-6.5f, 3f, 1f)))
            return true;
        else if ((pos1 == new Vector3(-6.5f, 3f, 1f)) & (pos2 == new Vector3(-4f, 4f, 1f) | pos2 == new Vector3(-1.5f, 2f, 1f)))
            return true;
        else if ((pos1 == new Vector3(-5.5f, -1.5f, 1f)) & (pos2 == new Vector3(-3.5f, -2f, 1f)))
            return true;
        else if ((pos1 == new Vector3(-3.5f, -2f, 1f)) & (pos2 == new Vector3(-5.5f, -1.5f, 1f) | pos2 == new Vector3(2.5f, 0.5f, 1f)))
            return true;
        return false;
    }
}