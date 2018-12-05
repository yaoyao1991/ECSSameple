using System;
using UnityEngine;

public class UnityAppService : IAppService
{
    public float Width
    {
        get
        {
            return Screen.width;
        }
    }

    public float Height
    {
        get
        {
            return Screen.height;
        }
    }

    public int GetSingal
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    public void SetResolution(int w, int h)
    {
        Screen.SetResolution(w, h, true);
    }


    public float batteryLevel
    {
        get
        {
            return SystemInfo.batteryLevel;
        }
    }

    public int batteryStatus
    {
        get
        {
            return (int)SystemInfo.batteryStatus;
        }
    }

    public int platform
    {
        get
        {
            return Convert.ToInt32(Application.platform);
        }
    }

    public int targetFrame
    {
        get { return Application.targetFrameRate; }
        set { Application.targetFrameRate = value; }
    }

    public float fps
    {
        get
        {
            return 1 / Time.deltaTime;
        }
    }

    public float cmem
    {
        get
        {
            return UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong() * 1.0f / 1024;//c#内存k
        }
    }

    public float gcmem
    {
        get
        {
            return GC.GetTotalMemory(false) * 1.0f / 1024;//gc的托管内存
        }
    }

    public float totalmem
    {
        get
        {
            return UnityEngine.Profiling.Profiler.GetTotalReservedMemoryLong() * 1.0f / 1024;//总申请内存k 
        }
    }

    public string ip;
    public string serverip
    {
        set { ip = value; }
        get { return ip; }
    }

}
