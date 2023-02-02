/*
 * This script creates a canvas object on the current game object and sets the render mode to world space, 
 * sets the canvas' camera to the main camera, sets the plane distance of the canvas, and adds a canvas raycast target component to the game object. 
 * The purpose of this script is to make the canvas object to be able to display in 3D space.
 * This script was created when the change of the scene was managed loading new scenes. This fact led to several problems loading canvas,
 * so we made this script for consistency purpopes. Right now, use this approach or keep the components in the canvas would make no differeces.
 */

using UnityEngine;
using NRKernal;

public class CanvaCameraLoader : MonoBehaviour
{
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        // Add a canvas component to the current game object
        canvas = gameObject.AddComponent<Canvas>();
        // Set the render mode of the canvas to World Space
        canvas.renderMode = RenderMode.WorldSpace;
        // Set the canvas' camera to the main camera
        canvas.worldCamera = Camera.main;
        // Set the distance of the canvas plane from the camera
        canvas.planeDistance = 1;
        // Add a canvas raycast target component to the game object
        gameObject.AddComponent<CanvasRaycastTarget>();
    }
}
