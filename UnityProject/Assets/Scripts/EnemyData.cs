using UnityEngine;

[CreateAssetMenu(fileName ="怪物資料",menuName ="Coolrain/怪物資料")]
//ScriptableObject() 腳本化物件 :將腳本的資料存放在專案內(不需掛在物件上)
public class EnemyData : ScriptableObject
{
    [Header("移動速度"), Range(0, 10)]
    public float speed;
    [Header("攻擊力"), Range(100, 1000)]
    public float damage;
    [Header("血量"), Range(100, 5000)]
    public float hp;
    [Header("冷卻時間"), Range(1, 10)]
    public float cd;
    [Header("停止距離"), Range(0.5f, 1000)]
    public float stopDistance;

    [Header("近距離單位")]
    public float attackLength;
    public float attackY;
    public float attackDelay;










    //[Header("費用"), Range(1, 10)]
    //public float cost;


    //[Header("技術")]
    //public bool 技;
    //public bool 術;

}


