using TMPro;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    public GameObject enemyCollider;
    public GameObject enemyTrigger;

    private float x_pos;
    private float z_pos;

    private float score;
    public TMP_Text scoreText;

    private void Start()
    {
        score = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "enemy")
        {
            Debug.Log("Enemy killed - with collider!");
            Destroy(collision.collider.gameObject);

            x_pos = Random.Range(-9.8f, 9.8f);
            z_pos = Random.Range(-9.8f, 9.8f);

            GameObject _newEnemy = GameObject.Instantiate(enemyCollider);
            _newEnemy.transform.position = new Vector3(x_pos, 0.6f, z_pos);

            score++;
            scoreText.text = score.ToString();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
            Debug.Log("Enemy killed - with Trigger collider!");

        x_pos = Random.Range(-9.8f, 9.8f);
        z_pos = Random.Range(-9.8f, 9.8f);

        GameObject _newEnemy = GameObject.Instantiate(enemyTrigger);
        _newEnemy.transform.position = new Vector3(x_pos, 0.6f, z_pos);

        if(score>0)
            score--;
        scoreText.text = score.ToString();
    }
}
