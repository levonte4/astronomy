using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class CoreMech : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public bool LevelCompleted = false;
    public CompleteScene complete;
    public bool CorrectlyConnected = false;
    public Material mat;
    public int Time = 0;
    public bool LineDrawn = false;
    public Sprite yellowStar;
    public Sprite whiteStar;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerPrefs.SetInt("IsFirstLaunch", 1);
        PlayerPrefs.Save();
    }

    void Update()
    {
        if (!gameObject.TryGetComponent(out LineRenderer x))
        {
            LineRenderer line = gameObject.AddComponent<LineRenderer>();
            line.material = mat;
            line.startColor = new Color(1f, 0.945f, 0.463f, 1);
            line.endColor = new Color(1f, 0.945f, 0.463f, 1);
            line.startWidth = 0.15f;
            line.endWidth = 0.15f;
            line.positionCount = 2;
        }
        else
        {
            LineRenderer line = GetComponent<LineRenderer>();
            var pos1 = line.GetPosition(0);
            var pos2 = line.GetPosition(1);
            var delta = 0.3;
            if (Input.touchCount > 0)
            {
                if ((Math.Abs(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x - (pos1.x + pos2.x) / 2) < delta) &
                (Math.Abs(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y - (pos1.y + pos2.y) / 2) < delta))
                {
                    Time++;
                    if (Time > 30)
                    {
                        Destroy(line);
                        LineDrawn = false;
                        CorrectlyConnected = false;
                        spriteRenderer.sprite = whiteStar;
                    }
                }
                if (Input.GetMouseButtonUp(0))
                    Time = 0;
            }
            //For PC's
            //var pointerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //var delta = 0.3;
            //if ((Math.Abs(pointerPos.x - (pos1.x + pos2.x) / 2) < delta) &
            //    (Math.Abs(pointerPos.y - (pos1.y + pos2.y) / 2) < delta) &
            //    Input.GetMouseButton(0))
            //{
            //    Time++;
            //    if (Time > 30)
            //    {
            //        Destroy(line);
            //        LineDrawn = false;
            //        CorrectlyConnected = false;
            //        spriteRenderer.sprite = whiteStar;
            //    }
            //}
            //if (Input.GetMouseButtonUp(0))
            //    Time = 0;
        }
        if (complete.Completed)
        {
            Destroy(this.gameObject);
            LevelCompleted = true;
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
            spriteRenderer.sprite = yellowStar;
            if (!IsLineCorrect(pos1, pos2))
            {
                line.startColor = Color.red;
                line.endColor = Color.red;
            }
            else
                CorrectlyConnected = true;
        }
        else if (!LineDrawn)
        {
            LineRenderer line = GetComponent<LineRenderer>();
            Destroy(line);
            LineDrawn = false;
            spriteRenderer.sprite = whiteStar;
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