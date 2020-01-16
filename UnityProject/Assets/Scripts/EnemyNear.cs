using System.Collections;

using UnityEngine;

public class EnemyNear : Enemy
{
    //override  複寫:複寫父類別帶有virtual的成員
    protected override void Attack()
    {
        //父類別原有的程式
        base.Attack();

        StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(data.attackDelay);
        RaycastHit hit;  //區域變數 碰撞資訊:用來存放射線打到的物件;

        //物理.射線(起點,方向,碰撞資訊,長度)
        //out 參數修飾詞:保存方法的資訊在區域變數內
        if (Physics.Raycast(transform.position + Vector3.up * data.attackY, transform.forward, out hit, data.attackLength))
        {
            hit.collider.GetComponent<Player>().Hit(data.damage);
        }
        
    }

    //繪製圖示，僅在場景顯示給開發者觀看
    private void OnDrawGizmos()
    {
        //圖示顏色
        Gizmos.color = Color.red;

        //前方Z transform.forward
        //右方X transform.right
        //上方Y transform.up
        //繪製射線(起點,方向*長度)
        Gizmos.DrawRay(transform.position + Vector3.up * data.attackY, transform.forward * data.attackLength);
        
        
    }
}
