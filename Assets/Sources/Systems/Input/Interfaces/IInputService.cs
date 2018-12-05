using UnityEngine;
using System.Collections.Generic;
public interface IInputService{
    Dictionary<int, Vector2?> mouseDown { get; }
    //是否持续按下某键
    bool IsKey(int key);
    //屏幕触点数
    int GetTouchcount();
    //是否按下某键
    bool IsKeyDown(int key);
    //获得鼠标位置
    Vector2 GetMousePosition(int touch);
    //鼠标是否在ui上
    bool IsOverUI(float x, float y);
}
