using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerVisualizer : MonoBehaviour
{
    public Color gizmoColor = Color.red; // トリガーの色

    void OnDrawGizmos()
    {
        // 現在のGizmosの色を保存
        Color previousColor = Gizmos.color;

        // Gizmosの色を設定
        Gizmos.color = gizmoColor;

        // Collider2Dの取得
        Collider2D collider = GetComponent<Collider2D>();

        // Collider2DのタイプによってGizmosの描画を行う
        if (collider is BoxCollider2D)
        {
            BoxCollider2D box = (BoxCollider2D)collider;
            Gizmos.DrawWireCube(box.bounds.center, box.bounds.size);
        }
        else if (collider is CircleCollider2D)
        {
            CircleCollider2D circle = (CircleCollider2D)collider;
            Gizmos.DrawWireSphere(circle.bounds.center, circle.radius);
        }

        // Gizmosの色を元に戻す
        Gizmos.color = previousColor;
    }

    public Color lineColor = Color.red;
    public float lineWidth = 0.1f;
    private LineRenderer lineRenderer;
    private Collider2D collider;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        collider = GetComponent<Collider2D>();

        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;

        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        if (collider is BoxCollider2D)
        {
            BoxCollider2D box = (BoxCollider2D)collider;
            Vector3[] points = new Vector3[5];
            points[0] = new Vector3(-box.size.x, -box.size.y) * 0.5f;
            points[1] = new Vector3(box.size.x, -box.size.y) * 0.5f;
            points[2] = new Vector3(box.size.x, box.size.y) * 0.5f;
            points[3] = new Vector3(-box.size.x, box.size.y) * 0.5f;
            points[4] = points[0];
            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points);
        }
        else if (collider is CircleCollider2D)
        {
            CircleCollider2D circle = (CircleCollider2D)collider;
            int segments = 360;
            Vector3[] points = new Vector3[segments + 1];
            for (int i = 0; i <= segments; i++)
            {
                float angle = i * 2.0f * Mathf.PI / segments;
                points[i] = new Vector3(Mathf.Cos(angle) * circle.radius, Mathf.Sin(angle) * circle.radius, 0);
            }
            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points);
        }
        else if (collider is PolygonCollider2D)
        {
            PolygonCollider2D polygon = (PolygonCollider2D)collider;
            Vector2[] points2D = polygon.points;
            Vector3[] points = new Vector3[points2D.Length + 1];
            for (int i = 0; i < points2D.Length; i++)
            {
                points[i] = points2D[i];
            }
            points[points2D.Length] = points[0]; // Loop back to the start
            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points);
        }
    }
}