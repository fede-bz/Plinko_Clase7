using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlinkoGameManager : MonoBehaviour
{
    public static PlinkoGameManager instancia;

    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoCirculos;
    public GameObject panelGameOver; // Panel que aparece al terminar

    private int puntosTotales = 0;
    private int circulosActivos = 0;

    // Límite de círculos que puede spawnear el jugador
    public int circulosMaximos = 10;
    private int circulosSpawneados = 0;

    void Awake()
    {
        instancia = this;
    }

    public void AgregarPuntos(int cantidad)
    {
        puntosTotales += cantidad;
        textoPuntos.text = "Puntos: " + puntosTotales;
    }

    public void CirculoSpawneado()
    {
        circulosActivos++;
        circulosSpawneados++;
        textoCirculos.text = "Tiros: " + circulosSpawneados + "/" + circulosMaximos;
    }

    public void CirculoDestruido()
    {
        circulosActivos--;

        // Si se gastaron todos los tiros y no quedan círculos activos
        if (circulosSpawneados >= circulosMaximos && circulosActivos <= 0)
        {
            MostrarGameOver();
        }
    }

    void MostrarGameOver()
    {
        panelGameOver.SetActive(true);
    }

    // Indica si el jugador todavía puede spawnear
    public bool PuedeSpawnear()
    {
        return circulosSpawneados < circulosMaximos;
    }

    // Reinicia la escena completa
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}