using UnityEngine;
using System.Linq;  //引用 查詢 API ( Min、Max、Tolist

public class Player : MonoBehaviour
{
    [Header("速度"), Range(0, 1500)]
    public float speed = 1.5f;
    [Header("玩家資料"), Range(0, 1500)]
    public PlayerData data;
    [Header("子彈")]
    public GameObject bullet;

    private Rigidbody rig;
    private FixedJoystick joystick;
    private Animator ani;            // 動畫控制器元件
    private Transform target;
    private LevelManager levelManager;
    private HpValueManager hpValueManager;
    private Vector3 bulletPos;
    private float timer;
    private Enemy[] enemys;           //敵人陣列
    private float[] enemysDis;        //距離陣列

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

        if (v == 0 && h == 0) Attack();
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

    public void Revival()
    {
        enabled = true;
        ani.SetBool("死亡開關", false);
       
        data.HP = data.HpMax;
        hpValueManager.SetHp(data.HP, data.HpMax);
        levelManager.HideRevival();
        
    }

    private void Attack()
    {
        if (timer < data.cd)
        {
            timer += Time.deltaTime;
        }
        else
        {                 
            //1.取得敵人數
            enemys = FindObjectsOfType<Enemy>();

            if (enemys.Length ==0)  //如果沒敵人就跳出
            {
                levelManager.Pass();  //過關啟動
                return;
            }

            timer = 0;
            ani.SetTrigger("攻擊觸發");
            //2.取得敵人距離
            enemysDis = new float[enemys.Length];             //距離陣列= 新 浮點數陣列[數量]

            for (int i = 0; i < enemys.Length; i++)
            {
                enemysDis[i] = Vector3.Distance(transform.position, enemys[i].transform.position);   //三維向量.距離(A,B)
            }
            //3.找出最近與面向
            float min = enemysDis.Min();                     //距離陣列.最小值()
            //print("最近的距離" + min);       
            int index = enemysDis.ToList().IndexOf(min);     //距離陣列.轉為清單().取得的編號資料(資料)   清單才能使用取得編號
            //print("最近的編號" + index);
            Vector3 enemyPos = enemys[index].transform.position;
            enemyPos.y = transform.position.y;
            transform.LookAt(enemyPos);
               
            //生成子彈
            bulletPos = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;  //子彈生成位置
            Vector3 angle = transform.eulerAngles;                                                            //三維向量 玩家角度 = 
            Quaternion qua = Quaternion.Euler(angle.x + 180, angle.y, angle.z);                               //四元角度 = 四元.歐拉角
            GameObject temp = Instantiate(bullet, bulletPos, qua);              
            temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletPower);                    //子彈推力
            temp.AddComponent<Bullet>();                                                                      //增加元件<泛式>
            temp.GetComponent<Bullet>().damage = data.damage;                                                 //取得元件<泛式> = 怪物.攻擊力
            temp.GetComponent<Bullet>().player = true;
        }
        
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        bulletPos = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;
        Gizmos.DrawSphere(bulletPos, 0.1f);
    }


}
