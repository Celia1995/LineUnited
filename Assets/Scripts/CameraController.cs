using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Tablero _tablero;
    [Range(0F, 2F)]
    public float border = 0F;

    private Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();

        if (!camera.orthographic)
            camera.orthographic = true;

        if (!_tablero)
            _tablero = FindObjectOfType<Tablero>();
    }

    private void Update()
    {
        Focus();
    }

    public void Focus()
    {
        Vector2 board = _tablero.Tamanyo;

        float o = Screen.height > Screen.width ? (float)Screen.height / Screen.width : 1F;

        camera.orthographicSize = (board.y + _tablero.anchoBorde * 2F + border * 2F) * 0.5f * o;

        Vector3 center = new Vector3(-_tablero.tamCelda * 0.5f + board.x * 0.5f, _tablero.tamCelda * 0.5f - board.y * 0.5f, -1F);

        camera.transform.position = _tablero.transform.position + center;
    }
}
