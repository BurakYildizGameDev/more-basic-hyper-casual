using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
 
    public GameObject pozitifCisimPrefab; // Pozitif y�kl� cisim prefab�
    public GameObject negatifCisimPrefab; // Negatif y�kl� cisim prefab�

    public int minCisimSayisi = 13; // Minimum olu�turulacak cisim say�s�
    public int maxCisimSayisi = 20; // Maksimum olu�turulacak cisim say�s�

    public float minGap = 7.5f; // Minimum bo�luk (Z ekseninde)
    public float maxGap = 10f; // Maksimum bo�luk (Z ekseninde)

    public GameObject menupanel;

    private void Start()
    {
        Time.timeScale = 0f;
        int cisimSayisi = Random.Range(minCisimSayisi, maxCisimSayisi + 1); // Cisim say�s�n� rastgele belirle
        float currentZ = -9f; // Ba�lang�� Z koordinat�

        for (int i = 0; i < cisimSayisi; i++)
        {
            float x = Random.Range(-4f, 4f); // X pozisyonunu rastgele belirle
            float zGap = Random.Range(minGap, maxGap); // Z bo�lu�unu rastgele belirle
            Vector3 position = new Vector3(x, 0.5f, currentZ + zGap); // Cismin pozisyonunu olu�tur

            Quaternion rotation = Quaternion.identity; // Rastgele d�nd�rme yok

            // Rastgele bir �ansla pozitif veya negatif y�kl� cisim olu�tur
            if (Random.Range(0f, 1f) < 0.4f)
            {
                Instantiate(pozitifCisimPrefab, position, rotation);
            }
            else
            {
                Instantiate(negatifCisimPrefab, position, rotation);
            }

            currentZ += zGap; // Z pozisyonunu g�ncelle
        }
        menupanel.SetActive(true);
    }
   
    public void homebutton()
    {
        menupanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void playbutton()
    {
        menupanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void nextlevelbuttonbutton()
    {
        menupanel.SetActive(false);
        SceneManager.LoadScene(0);
        menupanel.SetActive(false);
        Time .timeScale = 1f;
    }
    public void quitbutton()
    {
        Application.Quit();
    }
}
