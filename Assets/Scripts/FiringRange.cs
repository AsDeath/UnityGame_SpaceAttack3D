using UnityEngine;
using UnityEngine.Rendering;

public class FiringRange : MonoBehaviour
{
    private int speed;
    Vector3 lastPos;
    private Transform t_player;
    PublicValues val;
    void Start()
    {
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
        if (gameObject.tag == "Bullet") speed = val.speedBullet;
        if (gameObject.tag == "Bullet1") speed = val.speedBullet1;
        if (gameObject.tag == "Bullet2") speed = val.speedBullet2;
        if (gameObject.tag == "Bullet3") speed = val.speedBullet3;
        if (gameObject.tag == "Bullet4") speed = val.speedBullet4;
        if (val.playerOrEnemy)
        {
            t_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            speed = speed * val.speedBulletPlayer;
        } else
        {
            t_player = val.enemy1;
            speed = speed * val.speedBulletEnemy;
        }
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RaycastHit hit;
        if(Physics.Linecast(lastPos, transform.position, out hit) || (transform.position.x > (t_player.position.x + 500)) || (transform.position.x < (t_player.position.x - 500)) || (transform.position.y > (t_player.position.y + 500)) || (transform.position.y < (t_player.position.y - 500)) || (transform.position.z > (t_player.position.z + 500)) || (transform.position.z < (t_player.position.z - 500)))
        {
                Destroy(gameObject);
        }
        lastPos = transform.position;
    }
}
