using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("怪物資料")]
    public EnemyData data;

    private Animator ani;
    private NavMeshAgent nav;  //導覽網格代理器
    private GameObject player;
    

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

        //if ()
        //{
        //    ani.SetBool("跑步開關", false);
        //    Attack();
        //}
        
    }
    //全折疊 Ctrl + M + O
    //全展開 Ctrl + M + L

    /// <summary>
    /// 等待
    /// </summary>
    void wait()
    {
    }

    /// <summary>
    /// 移動
    /// </summary>
    void Move()
    {
        Vector3 posTarget = player.transform.position;
        posTarget.y = transform.position.y;
        transform.LookAt(posTarget);
        nav.destination = posTarget;
        ani.SetBool("跑步開關", true);
        
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    void Attack()
    {

        ani.SetTrigger("攻擊觸發");

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">玩家給予的傷害值</param>
    void Hurt(float damage)
    {
    }

    /// <summary>
    /// 死亡
    /// </summary>
    void Die()
    {
    }

    
}
