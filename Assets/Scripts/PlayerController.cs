using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public Text HPText;

    private int HP = 3;
    private Rigidbody playerRigidbody;
    private string[] HPtexts = { "XXX", "OXX", "OOX", "OOO" };

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.linearVelocity = newVelocity;
    }

    public void Hit()
    {
        if (HP <= 0)
            return;

        HP -= 1;
        HPText.text = HPtexts[HP];

        if (HP == 0)
            Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindFirstObjectByType<GameManager>();
        gameManager.EndGame();
    }
}
