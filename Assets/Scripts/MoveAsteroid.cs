using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    private Vector3 moveVector_ast;
    float speedMove = 3f;
    void Start()
    {
        moveVector_ast = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
    }

    void FixedUpdate()
    {
        if (transform.position.x > 980 || transform.position.x < -980)
        {
            moveVector_ast.x = -moveVector_ast.x;
        }
        if(transform.position.y > 980 || transform.position.y < -980)
        {
            moveVector_ast.y = -moveVector_ast.y;
        }
        if (transform.position.z > 980 || transform.position.z < -980)
        {
            moveVector_ast.z = -moveVector_ast.z ;
        }
        transform.Translate(moveVector_ast.normalized * Time.deltaTime * speedMove);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "MainCamera")
        {
            /*
            Quaternion x_angle = Quaternion.AngleAxis(transform.position.x * Time.deltaTime * speedMove, Vector3.up);
            Quaternion y_angle = Quaternion.AngleAxis(transform.position.y * Time.deltaTime * speedMove, Vector3.right);
            Quaternion z_angle = Quaternion.AngleAxis(transform.position.z * Time.deltaTime * speedMove, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, x_angle * y_angle * z_angle, Time.deltaTime * speedMove);
            
            moveVector_ast.x = -moveVector_ast.x + Random.Range(-45, 45);
            moveVector_ast.y = -moveVector_ast.y + Random.Range(-45, 45);
            moveVector_ast.z = -moveVector_ast.z + Random.Range(-45, 45);
            */
        }
    }
    
}
