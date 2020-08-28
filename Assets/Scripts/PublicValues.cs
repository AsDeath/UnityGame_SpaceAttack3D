using UnityEngine;
using UnityEngine.UI;

public class PublicValues : MonoBehaviour
{
    public int score = 0;
    public Text t_score, t_score1;
    public Text t_MaxScore;
    

    public int quantityAmmo = 1;
    public float speedEnemyShip = 2f;
    public float speedQuaternionEnemyShip = 3f;

    public int regen = 1;
    public int defence_player = 1;
    public int damage_level_player = 10;
    public int speedBulletPlayer = 1;
    public int addSpeedPlayer = 0;

    public int level = 0;
    public int damage_asteroid = 10;

    public int damage_level_enemy = 0;
    public int defence_enemy = 0;
    public int speedBulletEnemy = 1;

    public int quantityDestroyEnemy = 0;
    public float loadUltimate = 0;

    public int speedBullet = 50;
    public int speedBullet1 = 45;
    public int speedBullet2 = 40;
    public int speedBullet3 = 35;
    public int speedBullet4 = 30;

    public float fireDelta = 0.3F;
    public float nextFire = 0.3F;
    public float fireDelta1 = 0.8f;
    public float nextFire1 = 0.8f;
    public float fireDelta2 = 1.2f;
    public float nextFire2 = 1.2f;
    public float fireDelta3 = 1.5f;
    public float nextFire3 = 1.5f;
    public float fireDelta4 = 2f;
    public float nextFire4 = 2f;

    public Transform bullet;
    public Transform bullet1;
    public Transform bullet2;
    public Transform bullet3;
    public Transform bullet4;
    public bool playerOrEnemy;
    public bool button_ultimate = false;
    public bool pressedUltButton = false;
    public bool diePlayer = false;

    public Transform enemy1;
    public Transform enemy2;
    public Transform enemy3;
    public Transform enemy4;
    public Transform enemy5;
    public Transform enemy6;
    public Transform enemy7;
    public Transform enemy8;
    public Transform enemy9;
    public Transform enemy10;
    public Transform enemy11;
    public Transform enemy12;
    public Transform enemy13;

    public bool isPause = false;
    public ParticleSystem levelUp;
    private int defaultQuantity = 5, maxLevel = 8, quantityShip = 0;
    void Start()
    {
        for(int i = 0; i<5; i++)
        {
            int k = Random.Range(1, 5);
            if (k == 1) Instantiate(enemy1);
            if (k == 2) Instantiate(enemy2);
            if (k == 3) Instantiate(enemy3);
            if (k == 4) Instantiate(enemy4);
            if (k == 5) Instantiate(enemy5);
        }
    }
    void FixedUpdate()
    {
        loadUltimate += Time.deltaTime;
        if (loadUltimate >= 15) button_ultimate = true;
        if(quantityDestroyEnemy == defaultQuantity + level)
        {
            Instantiate(levelUp, transform.position, transform.rotation);
            level += 1;

            int boostPlyer = Random.Range(1, 5);
            if (boostPlyer == 1) regen += 1;
            if (boostPlyer == 2) defence_player += 1;
            if (boostPlyer == 3) damage_level_player += 1;
            if (boostPlyer == 4) speedBulletPlayer += 1;
            if (boostPlyer == 5) addSpeedPlayer += 1;

            int boostEnemy = Random.Range(1, 3);
            if (boostEnemy == 1) damage_level_enemy += 1;
            if (boostEnemy == 2) defence_enemy += 1;
            if (boostEnemy == 3) speedBulletEnemy += 1;

            quantityShip = defaultQuantity + level;
            if (level > maxLevel) quantityShip = maxLevel;
            for (int i = 0; i<quantityShip; i++)
            {
                int k = Random.Range(1, quantityShip);
                if (k == 1) Instantiate(enemy1);
                if (k == 2) Instantiate(enemy2);
                if (k == 3) Instantiate(enemy3);
                if (k == 4) Instantiate(enemy4);
                if (k == 5) Instantiate(enemy5);
                if (k == 6) Instantiate(enemy6);
                if (k == 7) Instantiate(enemy7);
                if (k == 8) Instantiate(enemy8);
                if (k == 9) Instantiate(enemy9);
                if (k == 10) Instantiate(enemy10);
                if (k == 11) Instantiate(enemy11);
                if (k == 12) Instantiate(enemy12);
                if (k == 13) Instantiate(enemy13);
            }
            quantityDestroyEnemy = 0;
        }
        if (score > Save.MaxScore) Save.MaxScore = score;
        t_score.text = t_score1.text = "Score: " + score;
        t_MaxScore.text = "Max Score: " + Save.MaxScore;
    }
}