using System.Collections;
using UnityEngine;

public class EnemyFar : Enemy
{
    [Header("子彈")]
    public GameObject bullet;

    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(CreateBullets());
        
    }

    private IEnumerator CreateBullets()
    {
        yield return new WaitForSeconds(data.attackDelay + 0.6f);

        bulletPos = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;  //子彈生成位置
        GameObject temp =  Instantiate(bullet, bulletPos, transform.rotation);
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletPower);                   //子彈推力
        temp.AddComponent<Bullet>();                        //增加元件<泛式>
        temp.GetComponent<Bullet>().damage = data.damage;   //取得元件<泛式> = 怪物.攻擊力
        temp.GetComponent<Bullet>().player = false;
    }

    private Vector3 bulletPos;  //子彈生成位置(三維向量  Vector3)

    private void OnDrawGizmos()
    {        
        Gizmos.color = Color.red;
        bulletPos =  transform.position + transform.forward * data.attackZ + transform.up * data.attackY;
        Gizmos.DrawSphere(bulletPos, 0.1f);
    }


}
