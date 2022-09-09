using UnityEngine;

public class FixedBullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, Constants.Bullet.TimeOut);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Unit>().ReceiveDamage(1);
        Destroy(gameObject);
    }
}
