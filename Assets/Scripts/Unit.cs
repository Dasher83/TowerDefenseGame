using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string label = "Unit-Level1";
    public float health = 1;
    public float movementSpeed = 100f;
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

        if (Vector3.Distance(this.transform.position, this.target.position) <= 0.22f)
        {
            this.target.GetComponent<Turret>().currentLives--;
            Destroy(this.gameObject);
        }
    }
}
