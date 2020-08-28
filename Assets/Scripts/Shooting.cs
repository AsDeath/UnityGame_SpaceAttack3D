using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Transform bullet;
    public Transform pivot_1;
    public Transform pivot_2;

    public Transform pivotUltimate_1;
    public Transform pivotUltimate_2;
    public Transform pivotUltimate_3;
    public Transform pivotUltimate_4;
    public Transform pivotUltimate_5;

    private AudioSource ShootSound;

    private float myTime = 0.0F, ultimateTime = 0f;
    private ShootButton sh_but;
    PublicValues val;
    private float fireDelta, nextFire;
    void Start()
    {
        ShootSound = GetComponent<AudioSource>();
        sh_but = GameObject.FindGameObjectWithTag("Shooting").GetComponent<ShootButton>();
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
        bullet = val.bullet;
        val.playerOrEnemy = true;
        fireDelta = val.fireDelta;
        nextFire = val.nextFire;
    }
    void FixedUpdate()
    {
        myTime = myTime + Time.deltaTime;
        if (val.pressedUltButton == true)
        {
            ultimateTime += Time.deltaTime;
            if (myTime > nextFire)
            {
                nextFire = fireDelta;
                Instantiate(bullet, pivot_1.position, pivot_1.rotation);
                Instantiate(bullet, pivot_2.position, pivot_2.rotation);
                Instantiate(bullet, pivotUltimate_1.position, pivotUltimate_1.rotation);
                Instantiate(bullet, pivotUltimate_2.position, pivotUltimate_2.rotation);
                Instantiate(bullet, pivotUltimate_3.position, pivotUltimate_3.rotation);
                Instantiate(bullet, pivotUltimate_4.position, pivotUltimate_4.rotation);
                Instantiate(bullet, pivotUltimate_5.position, pivotUltimate_5.rotation);
                ShootSound.Play();
                myTime = 0.0F;
            }
            if (ultimateTime >= 10)
            {
                val.pressedUltButton = false;
                val.button_ultimate = false;
                ultimateTime = 0f;
                val.loadUltimate = 0f;
            }
        } else
        {
            if (sh_but.GetShootOn() == 1 && myTime > nextFire)
            {
                nextFire = fireDelta;
                Instantiate(bullet, pivot_1.position, pivot_1.rotation);
                Instantiate(bullet, pivot_2.position, pivot_2.rotation);
                ShootSound.Play();
                myTime = 0.0F;
            }
        }
    }
}
