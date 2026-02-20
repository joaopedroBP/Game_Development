using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    public float speed = 30.0f;
    private Vector2 start_position = new Vector2(0f, -5.5f);
    public float MeioCampo = 0f;

    private Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto player
    }

    // Update is called once per frame

    void checkValidPos(){
        if(rb2d.position.y > MeioCampo){
            rb2d.position = new Vector2(rb2d.position.x,MeioCampo);
        }
        else if(rb2d.position.y < -7.5f ){
            rb2d.position = new Vector2(rb2d.position.x,-7.5f);
        }else if(rb2d.position.x < -4.5f){
            rb2d.position = new Vector2(-4.5f,rb2d.position.y);
        }else if(rb2d.position.x > 4.5f){
            rb2d.position = new Vector2(4.5f,rb2d.position.y);
        }

    }
    void Update()
    {

        checkValidPos();

        Vector3 playerPos = transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = mousePos - playerPos;
        dir.Normalize();

        Vector3 speedVec = dir * speed;

        var vel = rb2d.linearVelocity;
        vel.x = speedVec.x;
        vel.y = speedVec.y;
        rb2d.linearVelocity = vel; 

    }

    public void ResetPlayer(){
        transform.position = start_position;
    }
}
