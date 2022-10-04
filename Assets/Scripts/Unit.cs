﻿using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    [SerializeField]
    private UnitTypesEnum unitType;
    [SerializeField]
    private float health = 1;
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
        this.health -= Mathf.FloorToInt(attack);
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
            CoinCounter coinCounter = GameObject.FindGameObjectWithTag(Constants.Tags.Wallet).GetComponent<CoinCounter>();
            coinCounter.AddCoins(10);
            switch (this.unitType)
            {
                case UnitTypesEnum.Basic_1:
                    // No special event for now
                    break;
            }
        }
    }
}
