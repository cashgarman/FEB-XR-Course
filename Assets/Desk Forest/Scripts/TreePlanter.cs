using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreePlanter : MonoBehaviour
{
    public Transform placeholderTree;
    public Mesh[] treeMeshes;
    public Forest forest;

    private void Start()
    {
        // Randomize the current tree
        RandomizeTree();
    }

    public void RandomizeTree()
    {
        // Grab a random tree mesh from the list of meshes
        placeholderTree.GetComponent<MeshFilter>().mesh = treeMeshes[Random.Range(0, treeMeshes.Length)];
    }

    public void PlantTree()
    {
        // Make a clone of the placeholder tree
        Transform newTree = Instantiate(placeholderTree, placeholderTree.position, placeholderTree.rotation);
        newTree.SetParent(null, true);

        // Add the new tree's animator to the forest's tree animator list
        Animator newTreeAnimator = newTree.GetComponent<Animator>();
        forest.treeAnimators.Add(newTreeAnimator);
        newTreeAnimator.enabled = forest.raining;

        // Randomize the current tree
        RandomizeTree();
    }
}
