using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruenoGenerator : MonoBehaviour
{

    public GameObject trueno;
    private int i = 0;
    private GameObject truenoNuevo;
    private Camera nubeVoladora;

    void Start()
    {
        nubeVoladora = Camera.main;
    }
    public void Update()
    {

        if (i > 150)
        {
            truenoNuevo = Instantiate(trueno);
            i = 0;
            // Debug.Log(nubeVoladora.rect.yMax);
            // truenoNuevo.transform.position = new Vector3(nubeVoladora.transform.position.x-Random.Range(-7,7),nubeVoladora.transform.position.y+6, 0);
            var randomPosition = new Vector3(Random.Range(-6f, 16f), 5.2f, 0);
            truenoNuevo.transform.position = randomPosition;
            print(randomPosition.x);
        }
        i++;

    }
    // Start is called before the first frame update

}
