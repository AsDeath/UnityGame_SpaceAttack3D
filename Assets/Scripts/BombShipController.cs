using UnityEngine;

public class BombShipController : MonoBehaviour
{
    public ParticleSystem enemy_explosion;
    public int themselfSpeed = 9;
    public int enemy_hp = 60;

    private Transform t_player;
    private Vector3 transformVector, moveV, newPosition;
    Vector3 goAway;

    private PublicValues val;
    float delay = 4f;
    float maxDistance = 800, dist1 = 800, dist2 = 900;
    Vector3 lastPos;
    void Start()
    {
        t_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
        
        newPosition = new Vector3(t_player.position.x + RandomSign() * Random.Range(100,200), t_player.position.y + RandomSign() * Random.Range(200, 400), t_player.position.z + RandomSign() * Random.Range(200, 400));
        if (t_player.position.x < -maxDistance) newPosition.x = Random.Range(-dist2, -dist1);
        if (t_player.position.x > maxDistance) newPosition.x = Random.Range(dist1, dist2);
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
        moveV = Vector3.forward;
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
        if (e_collision.gameObject.tag == "Player") DamageEnemy(enemy_hp + val.damage_level_player + val.defence_enemy);
        if (e_collision.gameObject.tag == "GravityPlanet")
        {
            goAway = (transform.position - e_collision.transform.position).normalized;
            transform.Translate((val.speedEnemyShip + themselfSpeed) * goAway * Time.deltaTime);
        }
    }

    void DamageEnemy(int e_damage)
    {
        val.score += 1;
        enemy_hp -= e_damage;
        if (enemy_hp <= 0)
        {
            Instantiate(enemy_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
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
