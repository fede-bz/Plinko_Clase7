using UnityEngine;

public class CircleController : MonoBehaviour
{
    // Para evitar que el círculo sume puntos en dos zonas a la vez
    public bool fueReclamado = false;

    // Fuerza aplicada al presionar A o D (ajustable desde el Inspector)
    public float fuerzaLateral = 5f;

    // Fuerza con la que salen los dos círculos al hacer Split
    public float fuerzaSplit = 3f;

    // El prefab del círculo (para poder instanciar los hijos en el Split)
    public GameObject circuloPrefab;

    // Referencia al Rigidbody2D de este objeto
    private Rigidbody2D rb;

    // Para que cada círculo solo pueda hacer Split una vez
    private bool yaHizoSplit = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // A: empuja el círculo hacia la izquierda
        if (Input.GetKeyDown(KeyCode.A))
            rb.AddForce(Vector2.left * fuerzaLateral, ForceMode2D.Impulse);

        // D: empuja el círculo hacia la derecha
        if (Input.GetKeyDown(KeyCode.D))
            rb.AddForce(Vector2.right * fuerzaLateral, ForceMode2D.Impulse);

        // Space: divide el círculo en dos (solo una vez por círculo)
        if (Input.GetKeyDown(KeyCode.Space) && !yaHizoSplit)
        {
            yaHizoSplit = true;
            HacerSplit();
        }
    }

    void HacerSplit()
    {
        // Instanciamos dos círculos en la misma posición que este
        GameObject hijoIzq = Instantiate(circuloPrefab, transform.position, Quaternion.identity);
        GameObject hijoDer = Instantiate(circuloPrefab, transform.position, Quaternion.identity);

        // Les damos impulso en direcciones opuestas
        hijoIzq.GetComponent<Rigidbody2D>().AddForce(Vector2.left * fuerzaSplit, ForceMode2D.Impulse);
        hijoDer.GetComponent<Rigidbody2D>().AddForce(Vector2.right * fuerzaSplit, ForceMode2D.Impulse);

        // Marcamos los hijos para que no puedan hacer Split de nuevo
        hijoIzq.GetComponent<CircleController>().yaHizoSplit = true;
        hijoDer.GetComponent<CircleController>().yaHizoSplit = true;

        // Avisamos al GameManager: se crearon 2 nuevos y se destruyó 1
        PlinkoGameManager.instancia.CirculoSpawneado();
        PlinkoGameManager.instancia.CirculoSpawneado();
        PlinkoGameManager.instancia.CirculoDestruido();

        // Destruimos el círculo original
        Destroy(gameObject);
    }
}