using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    [Header("Fire")]
    [SerializeField] bool shootForward;
    [SerializeField] float speed = 2f;

    [Header("Rotation")]
    [SerializeField] Transform rotationCenter;
    [SerializeField] float angularSpeed, rotationRadius;
    private Vector3 direction;
    private float posX, posY, angle = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootForward = true;
        }
        
        if (shootForward)
            transform.position += direction * speed * Time.deltaTime;
        else
        {
            posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
            posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
            transform.position = new Vector2(posX, posY);
            angle = angle + Time.deltaTime * angularSpeed;

            direction = new Vector2(posX, posY);
        }

        Debug.DrawRay(transform.position, new Vector2(posX, posY), Color.red);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Object")
            collision.gameObject.SetActive(false);

        if(collision.transform.name == "Border")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
