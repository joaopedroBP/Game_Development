using UnityEngine;

public class Enemy_Controll : MonoBehaviour
{
    public Transform ball;
    public float speed = 0.0001f;
    public float MeioCampo = 0f;
    private Vector2 start_position = new Vector2(0f, 5.5f);
    private Rigidbody2D rb2d;
    private Vector2 moveDirection;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if(ball){
            Vector3 direction = (ball.position - transform.position).normalized;
            float angulo = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
            rb2d.rotation = angulo;
            moveDirection = direction;
        }

        if (rb2d.position.y < MeioCampo)
        {
            rb2d.position = new Vector2(rb2d.position.x, MeioCampo);
        }
    }

    void FixedUpdate(){
        if(ball){
            rb2d.linearVelocity = (new Vector2(moveDirection.x,moveDirection.y) * speed)/10;
        }
    }

    public void ResetEnemy()
    {
        rb2d.position = start_position;
        rb2d.linearVelocity = Vector2.zero;
    }
}
