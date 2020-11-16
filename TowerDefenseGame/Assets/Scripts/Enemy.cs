
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int cost = 50;
    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = WayPoints.points[0];
    }

    public void TakeDamage(int amount, Bullet bullet)
    {
        health -= amount;
        
        if(health <= 0)
        {
            Die(bullet);
        }
        
    }

    void Die(Bullet bullet)
    {
        PlayerStats.Money += cost + bullet.upgradeMoneyForEnemy;
        //Debug.Log("Enemy cost: " + cost + "\nUpgrade cost: " + bullet.upgradeMoneyForEnemy);
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavePointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

}
