using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    // El prefab del círculo que vamos a instanciar
    public GameObject circuloPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Verificamos si el jugador todavía puede spawnear
            if (!PlinkoGameManager.instancia.PuedeSpawnear()) return;

            // Convertimos la posición del mouse a coordenadas del mundo
            Vector3 posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicion.z = 0f;

            Instantiate(circuloPrefab, posicion, Quaternion.identity);

            // Avisamos al GameManager que se spawneó un círculo
            PlinkoGameManager.instancia.CirculoSpawneado();
        }
    }
}