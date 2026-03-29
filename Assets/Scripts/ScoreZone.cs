using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public int puntos = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Circulo"))
        {
            CircleController cc = other.GetComponent<CircleController>();
            if (cc == null || cc.fueReclamado) return;

            // Mostramos qué zona detectó la bolita
            Debug.Log("Zona que detectó: " + gameObject.name + " puntos: " + puntos);

            cc.fueReclamado = true;
            PlinkoGameManager.instancia.AgregarPuntos(puntos);
            PlinkoGameManager.instancia.CirculoDestruido();
            Destroy(other.gameObject);
        }
    }
}