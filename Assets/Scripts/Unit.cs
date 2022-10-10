using TMPro.Examples;
using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    [SerializeField]
    private UnitTypesEnum _unitType;
    [SerializeField]
    private float health;
    [SerializeField]
    private float movementSpeed;
    private Rigidbody2D rb;
    private Vector2 selfMovement;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 direction = this.target.position - this.transform.position;
        direction.Normalize();
        selfMovement = direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(this.transform.position, this.target.position);
    }

    void FixedUpdate()
    {
        moveSelf();
    }

    void moveSelf()
    {
        rb.MovePosition((Vector2)this.transform.position + (this.selfMovement * this.movementSpeed * Time.deltaTime));

        if (Vector3.Distance(this.transform.position, this.target.position) <= Constants.Unit.MinimumSafeDistance)
        {
            if(Turret.instance != null)
            {
                Turret.instance.ReceiveDamage(attack: 1);
            }
            this.ReceiveDamage(attack: this.health);
        }
    }

    public void ReceiveDamage(float attack)
    {
        this.health -= attack;
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
            switch (_unitType)
            {
                case UnitTypesEnum.Basic_1:
                    LevelManager.instance.Coins += Constants.Unit.Basic_1.CoinYield;
                    break;
                case UnitTypesEnum.Speedster_1:
                    LevelManager.instance.Coins += Constants.Unit.Speedster_1.CoinYield;
                    break;
                case UnitTypesEnum.Tank_1:
                    LevelManager.instance.Coins += Constants.Unit.Tank_1.CoinYield;
                    break;
            }
        }
    }

    private float SpawnDelay
    {
        get
        {
            switch (_unitType)
            {
                case UnitTypesEnum.Basic_1:
                    return Constants.Unit.Basic_1.SpawnSoundEffectDelay;
                case UnitTypesEnum.Speedster_1:
                    return Constants.Unit.Speedster_1.SpawnSoundEffectDelay;
                case UnitTypesEnum.Tank_1:
                    return Constants.Unit.Tank_1.SpawnSoundEffectDelay;
                default:
                    return 0f;
            }
        }
    }

    private void OnBecameVisible()
    {
        AudioManager.instance.PlaySoundEffect(SoundEffectsEnum.ENEMY_SPAWN, SpawnDelay);
    }
}
