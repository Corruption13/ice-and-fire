using UnityEngine;

using System.Collections.Generic;
/// <summary>
/// Creates shadow casters for 2D tilemaps
/// </summary>
[ExecuteInEditMode]
[DisallowMultipleComponent]
[RequireComponent(typeof(CompositeCollider2D))]
[AddComponentMenu("Rendering/2D/Shadow Caster 2D Tilemap")]
public class ShadowCaster2DTilemap : MonoBehaviour
{
    public CompositeCollider2D tilemapCollider;
    private GameObject shadowCasterContainer;
    public string ShadowCasterContainerName = "shadow_casters";
    public List<GameObject> shadowCasters = new List<GameObject>();
    private int previousPointCount;

    public void Start()
    {
        tilemapCollider = GetComponent<CompositeCollider2D>();
        shadowCasterContainer = GameObject.Find(ShadowCasterContainerName);

        if (!GameObject.Find(ShadowCasterContainerName))
        {
            shadowCasterContainer = new GameObject(ShadowCasterContainerName);
        }
        else
        {
            // Clear existing shadow casters
            if (Application.isPlaying)
            {
                foreach (Transform child in shadowCasterContainer.transform)
                {
                    Destroy(child.gameObject);
                }
            }
            else
            {
                while (shadowCasterContainer.transform.childCount != 0)
                {
                    DestroyImmediate(shadowCasterContainer.transform.GetChild(0).gameObject);
                }
            }
        }

        GenerateShadowCasters(false);
    }

    public void Update()
    {
        if (previousPointCount != tilemapCollider.pointCount)
        {
            GenerateShadowCasters(true);
        }
    }

    public void GenerateShadowCasters(bool clearExisting)
    {
        if (clearExisting)
        {
            // Clear existing shadow casters
            if (Application.isPlaying)
            {
                foreach (Transform child in shadowCasterContainer.transform)
                {
                    Destroy(child.gameObject);
                }
            }
            else
            {
                while (shadowCasterContainer.transform.childCount != 0)
                {
                    DestroyImmediate(shadowCasterContainer.transform.GetChild(0).gameObject);
                }
            }
        }

        previousPointCount = tilemapCollider.pointCount;

        for (int i = 0; i < tilemapCollider.pathCount; i++)
        {
            Vector2[] pathVertices = new Vector2[tilemapCollider.GetPathPointCount(i)];
            tilemapCollider.GetPath(i, pathVertices);
            GameObject shadowCaster = new GameObject(ShadowCasterContainerName + "_" + i);
            PolygonCollider2D shadowPolygon = (PolygonCollider2D)shadowCaster.AddComponent(typeof(PolygonCollider2D));
            shadowCaster.transform.parent = shadowCasterContainer.transform;
            shadowPolygon.points = pathVertices;
            shadowPolygon.enabled = false;
            UnityEngine.Rendering.Universal.ShadowCaster2D shadowCasterComponent = shadowCaster.AddComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>();
            shadowCasterComponent.selfShadows = true;
        }
    }
}