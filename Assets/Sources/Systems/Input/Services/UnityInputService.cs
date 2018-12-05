using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnityInputService : IInputService
{
    private Dictionary<int,Vector2?> mouseDowns = new Dictionary<int, Vector2?>(5);
    public Dictionary<int, Vector2?> mouseDown
    {
        get
        {
            var pos = Input.mousePosition;
            var x = pos.x;
            var y = pos.y;
#if UNITY_EDITOR || !(UNITY_ANDROID || UNITY_IPHONE)
            if (Input.GetMouseButtonDown(0))
            {
                if (mouseDown.ContainsKey(0))
                {
                    mouseDown[0] = new Vector2(x, y);
                }
                else
                {
                    mouseDown.Add(0, new Vector2(x, y));
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (mouseDown.ContainsKey(1))
                {
                    mouseDown[1] = new Vector2(x, y);
                }
                else
                {
                    mouseDown.Add(1, new Vector2(x, y));
                }
            }
            if (Input.GetMouseButtonDown(2))
            {
                if (mouseDown.ContainsKey(2))
                {
                    mouseDown[2] = new Vector2(x, y);
                }
                else
                {
                    mouseDown.Add(2, new Vector2(x, y));
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (mouseDown.ContainsKey(0))
                {
                    mouseDown[0] = null;
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                if (mouseDown.ContainsKey(1))
                {
                    mouseDown[1] = null;
                }
            }
            if (Input.GetMouseButtonUp(2))
            {
                if (mouseDown.ContainsKey(2))
                {
                    mouseDown[2] = null;
                }
            }
#else        
        if(Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                var touch = Input.GetTouch(i);
                var k = touch.fingerId;
                var pos2 = touch.position;
                if (touch.phase == TouchPhase.Moved)
                {                    
                    if (mouseDown.ContainsKey(k))
                    {
                        mouseDown[k] = new Vector2(pos2.x, pos2.y);
                    }
                    else
                    {
                        mouseDown.Add(k, new Vector2(pos2.x, pos2.y));
                    }
                }
                else if (touch.phase == TouchPhase.Began)
                {
                    if (mouseDown.ContainsKey(k))
                    {
                        mouseDown[k] = new Vector2(pos2.x, pos2.y);
                    }
                    else
                    {
                        mouseDown.Add(k, new Vector2(pos2.x, pos2.y));
                    }
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    if (mouseDown.ContainsKey(k))
                    {
                        mouseDown[k] = null;
                    }
                    else
                    {
                        mouseDown.Add(k, null);
                    }
                }
            }
        }
#endif
            return mouseDowns;
        }
    }

    public bool IsKey(int key)
    {
#if UNITY_EDITOR || !(UNITY_ANDROID || UNITY_IPHONE)
        if (key > 5)
        {
            return Input.GetKey((KeyCode)key);
        }
#endif
        return mouseDowns.ContainsKey(key) && mouseDowns[key] != null;
    }

    public int GetTouchcount()
    {
        return Input.touchCount;
    }

    public bool IsKeyDown(int key)
    {
        return Input.GetKeyDown((KeyCode)key);
    }

    public Vector2 GetMousePosition(int touch)
    {
        Vector3 pos = Vector2.zero;
#if UNITY_EDITOR || !(UNITY_ANDROID || UNITY_IPHONE)
        pos = Input.mousePosition;
#else
        for (int i = 0; i < Input.touchCount; i++)
        {
            var t = Input.GetTouch(i);
            var k = t.fingerId;
            if (t.fingerId == touch)
            {
                pos = t.position;
            }
        }
#endif
        return new Vector2(pos.x, pos.y);
    }

    private PointerEventData eventData;
    public bool IsOverUI(float x, float y)
    {
        eventData.position = new Vector2(x, y);
        List<RaycastResult> raycastResults = ListPool<RaycastResult>.Pop();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        var b = raycastResults.Count > 0;
        ListPool<RaycastResult>.Push(raycastResults);
        return b;
    }
}
