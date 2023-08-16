using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
 
    public GameObject pozitifCisimPrefab; // Pozitif yüklü cisim prefabý
    public GameObject negatifCisimPrefab; // Negatif yüklü cisim prefabý

    public int minCisimSayisi = 13; // Minimum oluþturulacak cisim sayýsý
    public int maxCisimSayisi = 20; // Maksimum oluþturulacak cisim sayýsý

    public float minGap = 7.5f; // Minimum boþluk (Z ekseninde)
    public float maxGap = 10f; // Maksimum boþluk (Z ekseninde)

    public GameObject menupanel;

    private void Start()
    {
        Time.timeScale = 0f;
        int cisimSayisi = Random.Range(minCisimSayisi, maxCisimSayisi + 1); // Cisim sayýsýný rastgele belirle
        float currentZ = -9f; // Baþlangýç Z koordinatý

        for (int i = 0; i < cisimSayisi; i++)
        {
            float x = Random.Range(-4f, 4f); // X pozisyonunu rastgele belirle
            float zGap = Random.Range(minGap, maxGap); // Z boþluðunu rastgele belirle
            Vector3 position = new Vector3(x, 0.5f, currentZ + zGap); // Cismin pozisyonunu oluþtur

            Quaternion rotation = Quaternion.identity; // Rastgele döndürme yok

            // Rastgele bir þansla pozitif veya negatif yüklü cisim oluþtur
            if (Random.Range(0f, 1f) < 0.4f)
            {
                Instantiate(pozitifCisimPrefab, position, rotation);
            }
            else
            {
                Instantiate(negatifCisimPrefab, position, rotation);
            }

            currentZ += zGap; // Z pozisyonunu güncelle
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
