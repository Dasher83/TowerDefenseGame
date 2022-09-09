using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    [SerializeField]
    private UnitTypesEnum unitType = UnitTypesEnum.Level1;
    [SerializeField]
    private float health = 1;
    [SerializeField]
    private float movementSpeed = Constants.Unit.DefaultMovementSpeed;
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
            Turret.instance.ReceiveDamage(attack: 1);
            this.ReceiveDamage(attack: this.health);
        }
    }

    public void ReceiveDamage(float attack)
    {
        this.health -= Mathf.FloorToInt(attack);
        Destroy(this.gameObject);
        switch (this.unitType)
        {
            case UnitTypesEnum.Level1:
                // No special event for now
                break;
        }
    }
}
