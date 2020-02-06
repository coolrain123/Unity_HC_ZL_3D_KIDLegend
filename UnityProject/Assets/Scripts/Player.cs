using UnityEngine;



public class Player : MonoBehaviour
{
    [Header("速度"), Range(0, 1500)]
    public float speed = 1.5f;
    [Header("玩家資料"), Range(0, 1500)]
    public PlayerData data;

    private Rigidbody rig;
    private FixedJoystick joystick;
    private Animator ani;            // 動畫控制器元件
    private Transform target;
    private LevelManager levelManager;
    private HpValueManager hpValueManager;
    


    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();  // 動畫控制器 = 取得元件<動畫控制器>()

        joystick = GameObject.Find("虛擬搖桿").GetComponent<FixedJoystick>();
        target = GameObject.Find("目標").transform;

        levelManager = FindObjectOfType<LevelManager>(); //FindObjectOfType  透過類型尋找物件(限制:場景上只有一個)

        hpValueManager = GetComponentInChildren<HpValueManager>();  //子物件的元件
    }

    // 固定更新：一秒執行 50 次 - 處理物理行為
    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = joystick.Vertical;
        float h = joystick.Horizontal;

        rig.AddForce(h * speed, 0, v * speed);

        ani.SetBool("跑步開關", v != 0 || h != 0);  // 動畫控制器.設定布林值("參數名稱"，布林值)

        Vector3 pos = transform.position;
        target.position = new Vector3(pos.x + h, 0.3f, pos.z + v);
        
        Vector3 postarget = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(postarget);


        //camera.position = Vector3.Lerp(camera.position, target.position, 0.3f * Time.deltaTime);

    }

    public void Hit(float damage)
    {
        if (ani.GetBool("死亡開關")) return;
        data.HP -= damage;
        hpValueManager.SetHp(data.HP, data.HpMax);
        StartCoroutine(hpValueManager.ShowValue(damage, "-", Color.white));
        if (data.HP < 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "傳送區域")
        {
            StartCoroutine(levelManager.NextLevel());
        }
    }

    private void Die()
    {
        ani.SetBool("死亡開關", true);      //死亡動畫
        enabled = false;                    //關閉此腳本(this可省略)

        StartCoroutine(levelManager.ShowRevival());
    }
}
