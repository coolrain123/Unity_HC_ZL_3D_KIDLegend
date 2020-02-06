using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("怪物資料")]
    public EnemyData data;

    private Animator ani;
    private NavMeshAgent nav;  //導覽網格代理器
    private GameObject player;
    private float timer;       //計時器

    private float atkRange; 

    private void Start()
    {
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

        player = GameObject.Find("鼠王");

        nav.speed = data.speed;         
        nav.stoppingDistance = data.stopDistance;
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
    private void Hurt(float damage)
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    void Die()
    {
        ani.SetBool("死亡開關", true);      //死亡動畫
        
    }

    
}
