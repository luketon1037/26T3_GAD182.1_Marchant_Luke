using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        // 0 = Left Click, 1 = Right Click, 2 = Middle Click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log($"Raycast hit 3D object: {clickedObject.name}");

                // Optional: Check if it has a specific tag or component
                if (clickedObject.CompareTag("Interactable"))
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
