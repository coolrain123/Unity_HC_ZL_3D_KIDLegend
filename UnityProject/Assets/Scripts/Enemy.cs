using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [Header("怪物資料")]
    public EnemyData data;       //腳本化物件:所有實體物件共用

    private float hp;          //欄位:物件獨立使用
    private Animator ani;
    private NavMeshAgent nav;  //導覽網格代理器
    private GameObject player;
    private float timer;       //計時器
    private float atkRange;
    private HpValueManager hpValueManager;


    private void Start()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

        player = GameObject.Find("鼠王");


        hp = data.HP;
        nav.speed = data.speed;         
        nav.stoppingDistance = data.stopDistance;
        hpValueManager = GetComponentInChildren<HpValueManager>();  //子物件的元件
    }

    private void Update()
    {
        Move();
    }
    //全折疊 Ctrl + M + O
    //全展開 Ctrl + M + L

    /// <summary>
    /// 等待
    /// </summary>
    private void wait()
    {
        ani.SetBool("跑步開關", false);

        timer += Time.deltaTime;  //計時器累加

        if (timer >= data.cd)
        {
            Attack();
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        if (ani.GetBool("死亡開關")) return;
        Vector3 posTarget = player.transform.position;
        posTarget.y = transform.position.y;
        transform.LookAt(posTarget);
        nav.destination = posTarget;
        ani.SetBool("跑步開關", true);

        if (nav.remainingDistance < data.stopDistance)  // 剩餘距離 < 資料.停止距離
        {
            wait();
        }
        else
        {
            ani.SetBool("跑步開關", true);
        }
        
    }

    /// <summary>
    /// 攻擊
    /// </summary>

    //protected 保護:允許子類別存取，禁止外部類別存取
    //virtual   隱藏:允許子類別存取
    protected virtual void Attack()
    {
        ani.SetTrigger("攻擊觸發");
        timer = 0;  //計時器歸0
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">玩家給予的傷害值</param>
    public void Hit(float damage)
    {
        if (ani.GetBool("死亡開關")) return;
        hp -= damage;
        hpValueManager.SetHp(hp, data.HpMax);
        StartCoroutine(hpValueManager.ShowValue(damage, "-", Color.white));
        if (hp < 0)
        {
            Die();
        }
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void  Die()
    {
        
        ani.SetBool("死亡開關", true);      //死亡動畫
        nav.isStopped = true;
        Destroy(this);
        Destroy(GetComponent<CapsuleCollider>());
        CreateCoin();
    }

    [Header("金幣")]
    public GameObject coin;
    private void CreateCoin()
    {
        //(int) 可強制讓浮點數轉為整數，去除小數點
        int r = (int)Random.Range(data.coinRange.x, data.coinRange.y);

        for (int i = 0; i < r; i++)
        {
            Instantiate(coin, transform.position + transform.up * 2, transform.rotation);
        }
        
    }
    
}
