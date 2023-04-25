using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sumarScoreBolas : MonoBehaviour
{
    private runnerController runner;
    private int pointUp;
    public GameObject textMEsh;
    public bool isSpecial;

    // Start is called before the first frame update
    void Start()
    {
        runner = FindObjectOfType<runnerController>();
        if (isSpecial)
        {
            pointUp = runner.valorBolasVerdesPuntos*2;

        }
        else
        {
            pointUp = runner.valorBolasVerdesPuntos;

        }
        textMEsh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("pis contra bola verde");
        runner.puntuacion += pointUp;
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;

        gameObject.GetComponent<objectGameplayRunnerMover>().canMove = false;
        DisplayText();
    }

    void DisplayText()
    {
        if (isSpecial)
        {
            FindObjectOfType<AudioManager>().Play("coin2", 1f);

        }
        else
        {
            FindObjectOfType<AudioManager>().Play("coin", 1);

        }

        textMEsh.GetComponent<TextMesh>().text = "+" + pointUp;
        textMEsh.SetActive(true);
        textMEsh.transform.parent = null;
        Invoke("DisableWHoleOBject", 1.2f);
        gameObject.SetActive(false);

    }

    void DisableWHoleOBject()
    {
        textMEsh.SetActive(false);
    }
}
