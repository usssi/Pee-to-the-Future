using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class runnerController : MonoBehaviour
{
    public Transform spawnFichas;
    public Transform despawnFichas;

    public GameObject[] fichas;
    public List<GameObject> fichasSpawneadas = new List<GameObject>();

    public GameObject[] bolas;
    public List<GameObject> bolasSpawneadas = new List<GameObject>();

    public TextMeshProUGUI textoScore;
    public TextMeshProUGUI textHighScore;
    public int highScore;
    public TextMeshProUGUI finalScore;

    public float respawnTime;
    public float timePlusser;

    public float lerpSpeed = 1f;
    private float timeElapsed = 0f;

    public int valorBolasVerdesPuntos;
    public int puntuacion;
    public float rotateSpeedController;

    public bool isDead;

    // Start is called before the first frame update
    void Awake()
    {
        if (bolasSpawneadas.Count > 0)
        {
            foreach (var item in bolasSpawneadas.ToList())
            {
                bolasSpawneadas.Remove(item);
                Destroy(item);
            }
        }
        if (fichasSpawneadas.Count > 0)
        {
            foreach (var item in fichasSpawneadas.ToList())
            {
                fichasSpawneadas.Remove(item);
                Destroy(item);
            }
        }
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Update()
    {
        HighscoreController();
    }

    void LateUpdate()
    {
        if (!isDead)
        {
            if (Time.timeSinceLevelLoad > respawnTime)
            {
                respawnTime += timePlusser;
                RandomSelectFichaOBola();
                MedidorDeDificultad();
            }

            if (fichasSpawneadas.Count > 0)
            {
                foreach (var ficha in fichasSpawneadas.ToList())
                {
                    ficha.GetComponent<objectGameplayRunnerMover>().canMove = true;
                    ficha.GetComponent<objectGameplayRunnerMover>().spawnPoint = spawnFichas;
                    ficha.GetComponent<objectGameplayRunnerMover>().despawnPoint = despawnFichas;
                    ficha.GetComponent<objectGameplayRunnerMover>().lerpSpeed = lerpSpeed;
                }
            }

            if (bolasSpawneadas.Count > 0)
            {
                foreach (var bola in bolasSpawneadas.ToList())
                {
                    bola.GetComponent<objectGameplayRunnerMover>().canMove = true;
                    bola.GetComponent<objectGameplayRunnerMover>().spawnPoint = spawnFichas;
                    bola.GetComponent<objectGameplayRunnerMover>().despawnPoint = despawnFichas;
                    bola.GetComponent<objectGameplayRunnerMover>().lerpSpeed = lerpSpeed;
                }
            }
            textoScore.text = "Score: " + puntuacion;
            textoScore.color = Color.green;
            finalScore.text = "YOUR SCORE: " + puntuacion;
            textHighScore.text = "HIGHSCORE: " + highScore;
        }
        else
        {
            if (bolasSpawneadas.Count > 0)
            {
                foreach (var item in bolasSpawneadas.ToList())
                {
                    bolasSpawneadas.Remove(item);
                    Destroy(item);
                }
            }
            if (fichasSpawneadas.Count > 0)
            {
                foreach (var item in fichasSpawneadas.ToList())
                {
                    fichasSpawneadas.Remove(item);
                    Destroy(item);
                }
            }

            textoScore.text = "Game over";
            textoScore.color = Color.red;
        }


    }

    public void KillPlayer()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void SpawnFichita()
    {
        int i = Random.Range(0, fichas.Length);

        GameObject fichaToSpawn = Instantiate(fichas[i]);
        Transform child = fichaToSpawn.transform;
        Transform parent = transform;
        child.SetParent(parent);

        float xX = fichaToSpawn.transform.position.x;
        Vector3 newPosition = new Vector3(xX, spawnFichas.transform.position.y, spawnFichas.transform.position.z);
        fichaToSpawn.transform.position = newPosition;

        fichaToSpawn.transform.localRotation = spawnFichas.transform.localRotation;

        fichasSpawneadas.Add(fichaToSpawn);
    }

    void SpawnPuntos()
    {
        int i = Random.Range(0, bolas.Length);

        GameObject bolaToSpawn = Instantiate(bolas[i]);
        Transform child = bolaToSpawn.transform;
        Transform parent = transform;
        child.SetParent(parent);

        float xX = bolaToSpawn.transform.position.x;
        Vector3 newPosition = new Vector3(xX, spawnFichas.transform.position.y, spawnFichas.transform.position.z);
        bolaToSpawn.transform.position = newPosition;

        bolaToSpawn.transform.localRotation = spawnFichas.transform.localRotation;

        bolasSpawneadas.Add(bolaToSpawn);
    }

    void RandomSelectFichaOBola()
    {
        int i = Random.Range(0, 99);

        if (i>=41)
        {
            SpawnFichita();

        }
        else if (i<=40)
        {
            SpawnPuntos();
        }
    }

    void MedidorDeDificultad()
    {
        if (puntuacion>=500 && puntuacion<1500)
        {
            timePlusser -= 0.05f;
            lerpSpeed -= 0.1f;
        }
        if (puntuacion>=0)
        {
            if (fichasSpawneadas.Count > 1500)
            {
                foreach (var ficha in fichasSpawneadas.ToList())
                {
                    if (ficha.GetComponent<objectGameplayRunnerMover>().canRotate)
                    {
                        ficha.GetComponent<objectGameplayRunnerMover>().rotateSpeed = rotateSpeedController;
                    }
                }
            }
        }
    }

    void HighscoreController()
    {
        if (puntuacion>highScore)
        {
            highScore = puntuacion;
            PlayerPrefs.SetInt("HighScore", highScore);

        }
    }
}
