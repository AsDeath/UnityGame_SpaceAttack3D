using UnityEditor;
using UnityEngine;

public class MoveToTouchLook: MonoBehaviour
{
    public Transform t_obj;
    public ParticleSystem engineFire_partSyst;

    private Vector3 moveVector;
    private float speedMoveForward = 3;
    private float speedMoveBack = -2;
    private SpeedMoveUp moveUp;
    private SpeedMoveDown moveDown;
    private Joystick checkJ;
    private CharacterController ch_cam;
    PublicValues val;
    void Start()
    {
        //получаем тело нашего игрока
        val = GameObject.FindGameObjectWithTag("Player").GetComponent<PublicValues>();
        checkJ = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        moveUp = GameObject.FindGameObjectWithTag("Up").GetComponent<SpeedMoveUp>();
        moveDown = GameObject.FindGameObjectWithTag("Down").GetComponent<SpeedMoveDown>();
        ch_cam = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (checkJ.GetCheckJoystick())
        {
            transform.rotation = transform.rotation * checkJ.GetRotationY() * checkJ.GetRotationX();
        }
        if (moveDown.GetPressed())
        {
            CharacterMove(speedMoveBack - val.addSpeedPlayer);
        }
        if (moveUp.GetPressed())
        {
            engineFire_partSyst.Play();
            CharacterMove(speedMoveForward + val.addSpeedPlayer);
        }
        else
        {
            engineFire_partSyst.Stop();
        }
    }
    private void CharacterMove(float speedMove)
    {
        moveVector = Vector3.zero;
        moveVector = t_obj.position - transform.position;
        ch_cam.Move(moveVector * speedMove * Time.deltaTime);
    }
}

/*
        if (Input.touchCount == 1)
        {
            
            if (touch.phase == TouchPhase.Began)
            {
                this.worldStartPoint = GetWorldPoint(touch.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 worldDelta = GetWorldPoint(touch.position) - worldStartPoint;
                transform.Translate(-worldDelta.x, -worldDelta.y, 0);
            }
           
            
                //получаем угол на который мышь улетела от центра экрана по Y
                if (RootY) moveY -= Input.GetAxis("Vertical") * SenY; // -
                //получаем угол на который мышь улетела от центра экрана по Х
                if (RootX)
                {
                    moveX += Input.GetAxis("Horizontal") * SenX;
                }
                //ограничиваем угол поворота камеры чтобы она не вращалась под ноги 
                if (TestY) moveY = ClampAngle(moveY, MinMax_Y.x, MinMax_Y.y);
                //ограничиваем угол поворота камеры чтобы она не вращалась по оси X
                if (TestX)
                {
                    moveX = ClampAngle(moveX, MinMax_X.x, MinMax_X.y);
                }
                //поворачиваем тело персонажа по осям 
                MyPawnBody.transform.rotation = Quaternion.Euler(moveY, moveX, 0);

                CharacterMove();
            
            touch = Input.GetTouch(0);
        }
        */
