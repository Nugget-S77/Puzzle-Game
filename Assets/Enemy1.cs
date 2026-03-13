using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy1
{
    
    public float speed = 2f;
    private bool canWalk = false;

    void Update()
    {
        if (canWalk)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void StartWalking()
    {
        canWalk = true;
    }


public class RoomTrigger : MonoBehaviour
{
    public Enemy1 enemy;   // Enemy ที่จะให้เดิน

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.StartWalking();   // เรียกให้ Enemy เริ่มเดิน
        }
    }
}
}

