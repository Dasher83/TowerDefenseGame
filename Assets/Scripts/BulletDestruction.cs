using UnityEngine;

public class BulletDestruction : MonoBehaviour
{
    private float _damageOnImpact;

    public float DamageOnImpact { 
        get {
            if( _damageOnImpact < 0)
            {
                _damageOnImpact = 0;
            }
            return _damageOnImpact; 
        } 
        set {
            if( value < 0)
            {
                _damageOnImpact = 0;
                return;
            }
            _damageOnImpact = value; 
        } 
    }
    
    void Update()
    {
        Destroy(this.gameObject, Constants.Bullet.TimeOut);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Unit>().ReceiveDamage(DamageOnImpact);
        Destroy(gameObject);
    }
}
