
public interface IAppService{
    float Width
    {
        get;
    }
    float Height
    {
        get;
    }
    //设置屏幕分辨率
    void SetResolution(int w, int h);
    //获取手机信号信息
    int GetSingal { get; }
    //获取手机电量
    float batteryLevel { get; }
    //获取手机充电状态
    int batteryStatus { get; }
    //平台enum值
    int platform { get; }
    //目标帧率属性
    int targetFrame { get; set; }
    //fps值
    float fps { get; }
    //c#占用内存k
    float cmem { get; }
    //gc的托管内存
    float gcmem { get; }
    //总申请内存
    float totalmem { get; }
    //服务器ip
    string serverip { get; }
}
