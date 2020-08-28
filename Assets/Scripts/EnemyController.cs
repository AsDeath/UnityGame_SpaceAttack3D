using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem enemy_explosion;
    public int themselfSpeed = 0;
    public int enemy_hp = 100;
    private Transform t_player;
    private Vector3 transformVector;

    private PublicValues val;
    Quaternion origRot;
    float delay = 4f;
    Vector3 v_p1, v_p2, v_p3, moveV, newPosition;
    float maxDistance = 800, dist1 = 800, dist2 = 900;
    void Start()
    {
        t_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
        origRot = transform.rotation;
        newPosition = new Vector3(t_player.position.x + RandomSign() * Random.Range(100, 200), t_player.position.y + RandomSign() * Random.Range(200, 400), t_player.position.z + RandomSign() * Random.Range(200, 400));
        if (t_player.position.x < -maxDistance) newPosition.x = Random.Range(-dist2,-dist1);
        if (t_player.position.x > maxDistance) newPosition.x = Random.Range(dist1,dist2);
        if (t_player.position.y < -maxDistance) newPosition.y = Random.Range(-dist2, -dist1);
        if (t_player.position.y > maxDistance) newPosition.y = Random.Range(dist1, dist2);
        if (t_player.position.z < -maxDistance) newPosition.z = Random.Range(-dist2, -dist1);
        if (t_player.position.z > maxDistance) newPosition.z = Random.Range(dist1, dist2);
        transform.position = newPosition;
        
    }

    void FixedUpdate()
    {
        delay = delay + Time.deltaTime;
        transformVector = t_player.position - transform.position;
        Quaternion rot_z = Quaternion.LookRotation(transformVector, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot_z, val.speedQuaternionEnemyShip * Time.deltaTime);
        
        if (((transform.position.x - t_player.position.x) > 70 || (transform.position.x - t_player.position.x) < -70) || ((transform.position.y - t_player.position.y) > 70 || (transform.position.y - t_player.position.y) < -70) || ((transform.position.z - t_player.position.z) > 70 || (transform.position.z - t_player.position.z) < -70))
            moveV = Vector3.forward;
        else
        {
            if (((transform.position.x - t_player.position.x) < 10 && (transform.position.x - t_player.position.x) > -10) || ((transform.position.y - t_player.position.y) < 10 && (transform.position.y - t_player.position.y) > -10) || ((transform.position.z - t_player.position.z) < 10 && (transform.position.z - t_player.position.z) > -10))
                moveV = Vector3.back;
            else
            {
                delay = delay + Time.deltaTime;
                if (delay >= 3)
                {
                    int p1 = Random.Range(1, 2);
                    int p2 = Random.Range(1, 2);
                    int p3 = Random.Range(1, 2);
                    if (p1 == 1) v_p1 = Vector3.forward;
                    else v_p1 = Vector3.back;
                    if (p2 == 1) v_p2 = Vector3.right;
                    else v_p2 = Vector3.left;
                    if (p3 == 1) v_p3 = Vector3.up;
                    else v_p3 = Vector3.down;
                    moveV = v_p3 + v_p2 + v_p1;
                    delay = 0;
                }
            }
        }
        
        transform.Translate((val.speedEnemyShip + themselfSpeed) * moveV * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision e_collision)
    {
        if (e_collision.gameObject.tag == "Asteroid") DamageEnemy(val.damage_asteroid - val.defence_enemy);
        if (e_collision.gameObject.tag == "Bullet") DamageEnemy(2 + val.damage_level_player - val.defence_enemy);
        if (e_collision.gameObject.tag == "Bullet1") DamageEnemy(5 + val.damage_level_player - val.defence_enemy);
        if (e_collision.gameObject.tag == "Bullet2") DamageEnemy(7 + val.damage_level_player - val.defence_enemy);
        if (e_collision.gameObject.tag == "Bullet3") DamageEnemy(10 + val.damage_level_player - val.defence_enemy);
        if (e_collision.gameObject.tag == "Bullet4") DamageEnemy(15 + val.damage_level_player - val.defence_enemy);
        if (e_collision.gameObject.tag == "Planet") DamageEnemy(enemy_hp + val.damage_level_player + val.defence_enemy);
    }

    void DamageEnemy(int e_damage)
    {
        val.score += 1;
        enemy_hp -= e_damage;
        if (enemy_hp <= 0)
        {
            Instantiate(enemy_explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            val.quantityDestroyEnemy += 1;
        }
    }

    int RandomSign()
    {
        int r = Random.Range(0, 2);
        if (r == 0) return -1;
        else return 1;
    }
}
