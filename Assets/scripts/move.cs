using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class move : MonoBehaviour
{

    Rigidbody rg;
    bool sol;
    bool sag;
    float hiz = 20.0f;

    public int Score;
    public static int  highScore;
    public GameObject finishpanel;
    public TextMeshProUGUI higihscoretext,scoretext;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        Score = 0;
        finishpanel.SetActive(false);

    }

    void Update()
    {
        transform.Translate(0, 0, hiz * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            // A tuþuna basýldýðýnda sola hareket et
            transform.Translate(Vector3.left * hiz * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // D tuþuna basýldýðýnda saða hareket et
            transform.Translate(Vector3.right * hiz * Time.deltaTime);
        }

        if(Score<0)
        {
            Time.timeScale = 0;
        }
        if (Score > highScore)
        {
            highScore = Score;
        }
        higihscoretext.text = highScore.ToString();
        scoretext.text ="Score : "+ Score.ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="pozitif")
        {
            Score++;
            Destroy(other.gameObject); // Carptýðýnýz pozitif nesneyi yok et
        }
        if (other.gameObject.tag=="negatif")
        {
            Score--;
            Destroy(other.gameObject); // Carptýðýnýz pozitif nesneyi yok et
        }
        if (other.gameObject.tag == "finish")
        {
            Time.timeScale = 0;
            finishpanel.SetActive(true);
        }
    }
}
