using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TruenoScript : MonoBehaviour
{
    [Header("Fall Speed")]
    public float speed = 3f;

    // private GameObject[] targets;
    // private GameObject target;

    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        // targets = GameObject.FindGameObjectsWithTag("Ground");
        // target = targets[Random.Range(0, targets.Length)];
        Destroy(this.gameObject, 15);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, -10, 0), step);
    }
}
