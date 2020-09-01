using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform pivot_1;
    public Transform pivot_2;
    public Transform pivot_3;

    public Transform pivot_4;
    public Transform pivot_5;
    public Transform pivot_6;
    public Transform pivot_7;

    Transform bullet1;
    Transform bullet2;
    private float myTime1 = 0.0F, myTime2 = 0.0f;
    PublicValues val;
    private float fireDelta1, nextFire1, fireDelta2, nextFire2;
    public int q_ammo1;
    public int q_ammo2;
    void Start()
    {
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
        val.playerOrEnemy = false;
        int bl = Random.Range(0, 4);
        switch (bl)
        {
            case 0:
                bullet1 = val.bullet;
                fireDelta1 = val.fireDelta;
                nextFire1 = val.nextFire;
                break;
            case 1:
                bullet1 = val.bullet1;
                fireDelta1 = val.fireDelta1;
                nextFire1 = val.nextFire1;
                break;
            case 2:
                bullet1 = val.bullet2;
                fireDelta1 = val.fireDelta2;
                nextFire1 = val.nextFire2;
                break;
            case 3:
                bullet1 = val.bullet3;
                fireDelta1 = val.fireDelta3;
                nextFire1 = val.nextFire3;
                break;
            case 4:
                bullet1 = val.bullet4;
                fireDelta1 = val.fireDelta4;
                nextFire1 = val.nextFire4;
                break;
        }
        bl = Random.Range(0, 4);
        switch (bl)
        {
            case 0:
                bullet2 = val.bullet;
                fireDelta2 = val.fireDelta;
                nextFire2 = val.nextFire;
                break;
            case 1:
                bullet2 = val.bullet1;
                fireDelta2 = val.fireDelta1;
                nextFire2 = val.nextFire1;
                break;
            case 2:
                bullet2 = val.bullet2;
                fireDelta2 = val.fireDelta2;
                nextFire2 = val.nextFire2;
                break;
            case 3:
                bullet2 = val.bullet3;
                fireDelta2 = val.fireDelta3;
                nextFire2 = val.nextFire3;
                break;
            case 4:
                bullet2 = val.bullet4;
                fireDelta2 = val.fireDelta4;
                nextFire2 = val.nextFire4;
                break;
        }
        q_ammo1 = Random.Range(1, q_ammo1);
        q_ammo2 = Random.Range(0, q_ammo2);
        
    }
    void FixedUpdate()
    {
        myTime1 = myTime1 + Time.deltaTime;
        myTime2 = myTime2 + Time.deltaTime;

        if (myTime1 > nextFire1)
        {
            nextFire1 = fireDelta1;
            if (q_ammo1 > 3)
            {
                Instantiate(bullet1, pivot_3.position, pivot_2.rotation);
                Instantiate(bullet1, pivot_2.position, pivot_2.rotation);
                Instantiate(bullet1, pivot_1.position, pivot_1.rotation);
            }
            if (q_ammo1 == 3)
            {
                Instantiate(bullet1, pivot_3.position, pivot_3.rotation);
                Instantiate(bullet1, pivot_1.position, pivot_1.rotation);
            }
            if (q_ammo1 == 2)
            {
                Instantiate(bullet1, pivot_1.position, pivot_1.rotation);
                Instantiate(bullet1, pivot_2.position, pivot_2.rotation);
            }
            if (q_ammo1 == 1) Instantiate(bullet1, pivot_1.position, pivot_1.rotation);

            myTime1 = 0.0F;
        }

        if(myTime2 > nextFire2)
        {
            nextFire2 = fireDelta2;
            if (q_ammo2 == 6)
            {
                Instantiate(bullet2, pivot_7.position, pivot_7.rotation);
                Instantiate(bullet2, pivot_6.position, pivot_6.rotation);
                Instantiate(bullet2, pivot_5.position, pivot_5.rotation);
                Instantiate(bullet2, pivot_4.position, pivot_4.rotation);
            }
            if (q_ammo2 == 5)
            {
                Instantiate(bullet2, pivot_7.position, pivot_7.rotation);
                Instantiate(bullet2, pivot_5.position, pivot_5.rotation);
                Instantiate(bullet2, pivot_4.position, pivot_4.rotation);
            }
            if (q_ammo2 == 4)
            {
                Instantiate(bullet2, pivot_6.position, pivot_6.rotation);
                Instantiate(bullet2, pivot_5.position, pivot_5.rotation);
                Instantiate(bullet2, pivot_4.position, pivot_4.rotation);
            }
            if (q_ammo2 == 3)
            {
                Instantiate(bullet2, pivot_5.position, pivot_5.rotation);
                Instantiate(bullet2, pivot_4.position, pivot_4.rotation);
            }
            if (q_ammo2 == 2) Instantiate(bullet2, pivot_5.position, pivot_5.rotation);
            if (q_ammo2 == 1) Instantiate(bullet2, pivot_4.position, pivot_4.rotation);

            myTime2 = 0.0F;
        }
    }
}