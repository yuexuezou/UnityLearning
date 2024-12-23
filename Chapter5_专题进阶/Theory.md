# 第五章：专题进阶

## 1. AI系统
### 1.1 寻路系统
```csharp
public class PathfindingAgent : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    // 设置目标点并寻路
    public void SetDestination(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();
        if (NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path))
        {
            agent.SetPath(path);
        }
    }
    
    // 动态避障
    void Update()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            // 路径完成后的行为
        }
    }
}
```

### 1.2 行为树
- 行为节点
- 选择器
- 序列器
- 条件节点

### 1.3 状态机
```csharp
public class AIStateMachine
{
    private Dictionary<string, AIState> states = new Dictionary<string, AIState>();
    private AIState currentState;
    
    // 添加状态
    public void AddState(string stateName, AIState state)
    {
        states[stateName] = state;
    }
    
    // 切换状态
    public void ChangeState(string newStateName)
    {
        if (currentState != null)
            currentState.Exit();
            
        currentState = states[newStateName];
        currentState.Enter();
    }
    
    // 更新状态
    public void Update()
    {
        if (currentState != null)
            currentState.Update();
    }
}
```

## 2. 网络游戏开发
### 2.1 网络基础
- TCP vs UDP
- 客户端-服务器架构
- P2P架构

### 2.2 Unity网络框架
```csharp
public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // 连接到Photon服务器
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster()
    {
        // 连接成功后加入房间
        PhotonNetwork.JoinRandomRoom();
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // 如果没有可用房间，创建新房间
        PhotonNetwork.CreateRoom(null);
    }
    
    // 网络同步示例
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 发送数据
            stream.SendNext(transform.position);
        }
        else
        {
            // 接收数据
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
```

### 2.3 网络同步
- 状态同步
- 帧同步
- 预测回滚

## 3. AR/VR开发
### 3.1 AR Foundation
```csharp
public class ARController : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }
    
    // AR平面检测
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    // 在检测到的平面上放置AR内容
                    Pose hitPose = hits[0].pose;
                    Instantiate(arPrefab, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
```

### 3.2 VR交互
- VR输入系统
- 空间定位
- 手势识别

### 3.3 XR优化
```csharp
public class XROptimization : MonoBehaviour
{
    // VR性能优化
    void OptimizeForVR()
    {
        // 设置VR专用质量
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 90;
        
        // 优化渲染
        Camera.main.stereoSeparation = 0.064f;
        Camera.main.nearClipPlane = 0.01f;
    }
    
    // AR优化
    void OptimizeForAR()
    {
        // 设置AR相机参数
        ARSession.attemptUpdate = true;
        
        // 光照估计
        GetComponent<ARCameraManager>().requestedLightEstimation = LightEstimation.AmbientIntensity;
    }
}
```

## 4. 高级功能整合
### 4.1 AI与网络结合
- 网络AI同步
- 分布式AI计算
- 服务器端AI

### 4.2 AR/VR网络多人
- 空间同步
- 手势同步
- 场景共享

## 本章练习
1. 实现AI寻路系统
2. 开发多人网络游戏
3. 创建AR/VR应用

## 实践项目
创建一个综合性项目：
1. 多人在线AR游戏
2. AI控制的NPC系统
3. 网络同步系统
4. 性能优化方案 