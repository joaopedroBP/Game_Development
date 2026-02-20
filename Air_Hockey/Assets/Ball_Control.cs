using UnityEngine;
using UnityEngine.UI;
public class Ball_Control : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public float startSpeed = 10f;
    public float maxSpeed = 25f;
    public float speedIncrease = 2f;
    public PlayerControl player;
    public Enemy_Controll enemy;
    public AudioSource source;
    public int pontosVermelho;
    public int pontosAzul;
    public Text TextoPontosVermelho;
    public Text TextoPontosAzul;


    void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20, -15));
        } else {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void Start () {
        speed = startSpeed;
        rb2d = GetComponent<Rigidbody2D>(); 
        source = GetComponent<AudioSource>();
        Invoke("GoBall", 2);    
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player") || coll.collider.CompareTag("Enemy")) {

            speed += speedIncrease;
            speed = Mathf.Clamp(speed, 0f, maxSpeed);

            Vector2 newDirection = rb2d.linearVelocity.normalized;
            rb2d.linearVelocity = newDirection * speed;
            source.Play();
        }
    }
    
    void ResetBall(){
        speed = startSpeed;
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void UpdateScore(){
        if (transform.position.y >= 7.7f){
            pontosAzul++;
           TextoPontosAzul.text = pontosAzul.ToString();
        }else{
            pontosVermelho++;
            TextoPontosVermelho.text = pontosVermelho.ToString();
        }
    }

    void RestartGame(){
        UpdateScore();
        ResetBall();
        player.ResetPlayer();
        enemy.ResetEnemy();
        Invoke("GoBall", 1);
    }

    void Update()
    {
        if (transform.position.y >= 7.7f || transform.position.y <= -7.7f){
            RestartGame();
        }        
    }


}
