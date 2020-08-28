using UnityEngine.UI;
using UnityEngine;

public class AnimationCamera : MonoBehaviour
{
    
    public int player_hp = 100;
    public Text hp_text;
    public Text damage_text;
    public Text defence_text;
    public Text speedShip_text;
    public ParticleSystem player_explosion;

    private Vector2 v_rot_ship;
    private float max = 20f, min = -20f, rotZ = 20f, sens = 0.8f, regenTime;
    private Joystick j_joystick;
    private Quaternion originalRotation, newRotationY, newRotationX, newRotationZ;


    PublicValues val;
    void Start()
    {
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
        j_joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        hp_text.text = player_hp + "%";
        damage_text.text = val.damage_level_player+" ";
        defence_text.text = val.defence_player + " ";
        speedShip_text.text = val.addSpeedPlayer + 1 + " ";
        regenTime += Time.deltaTime;
        if (player_hp < 100 && regenTime >= 3)
        {
            player_hp += val.regen;
            regenTime = 0;
        }
        v_rot_ship = j_joystick.GetWorldDelta();
        v_rot_ship.x = Mathf.Clamp(v_rot_ship.x, min, max);
        v_rot_ship.y = Mathf.Clamp(v_rot_ship.y, min, max);
        if (v_rot_ship.x > 0 && v_rot_ship.y > 0)
        {
            if (v_rot_ship.x > 10) rotZ = 20f;
        }
        if (v_rot_ship.x <= 0 && v_rot_ship.y < 0)
        {
            if (v_rot_ship.x < -10) rotZ = -20f;        }
        if (v_rot_ship.x >= 0 && v_rot_ship.y < 0)
        {
            if (v_rot_ship.x > 10) rotZ = 20f;        }
        if (v_rot_ship.x < 0 && v_rot_ship.y > 0)
        {
            if (v_rot_ship.x < -10) rotZ = -20f;
        }
        if (j_joystick.GetCheckJoystick())
        {
            newRotationX = Quaternion.AngleAxis(v_rot_ship.y * sens, Vector3.right);
            newRotationY = Quaternion.AngleAxis(-v_rot_ship.x * sens, Vector3.up);
            newRotationZ = Quaternion.AngleAxis(rotZ * sens, Vector3.forward);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, originalRotation * newRotationX * newRotationY * newRotationZ, 3 * Time.deltaTime);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, originalRotation, 3 * Time.deltaTime);
        }

    }
    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Asteroid") DamagePlayer(val.damage_asteroid);
        if (myCollision.gameObject.tag == "Bullet") DamagePlayer(2 + val.damage_level_enemy - val.defence_player);
        if (myCollision.gameObject.tag == "Bullet1") DamagePlayer(5 + val.damage_level_enemy - val.defence_player);
        if (myCollision.gameObject.tag == "Bullet2") DamagePlayer(7 + val.damage_level_enemy - val.defence_player);
        if (myCollision.gameObject.tag == "Bullet3") DamagePlayer(10 + val.damage_level_enemy - val.defence_player);
        if (myCollision.gameObject.tag == "Bullet4") DamagePlayer(15 + val.damage_level_enemy - val.defence_player);
        if (myCollision.gameObject.tag == "BombShip") DamagePlayer(30 + val.damage_level_enemy - val.defence_player);
        if (myCollision.gameObject.tag == "Planet") DamagePlayer(player_hp);
    }

    void DamagePlayer (int p_damage)
    {
        player_hp -= p_damage;
        if (player_hp <= 0)
        {
            hp_text.text = "0%";
            Instantiate(player_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            val.diePlayer = true;
        }
    }
}