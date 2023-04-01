using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupO : MonoBehaviour
{
    private float previousTime;
    public float fallTime = 1f;

    public bool level2 = false;

    public void ChangeLevel()
    {
        level2 = true;
    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);

            if (!Grid.insideBorder(v))
                return false;

            if (Grid.grid[(int)v.x, (int)v.y] != null &&
                Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        for (int y = 0; y < Grid.h; ++y)
            for (int x = 0; x < Grid.w; ++x)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(-1, 0, 0);
        }

        if (level2 == false)
        {
            if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 9 : fallTime / 3))
            {
                transform.position += new Vector3(0, -1, 0);
                previousTime = Time.time;

                if (isValidGridPos())
                    updateGrid();
                else
                {
                    transform.position += new Vector3(0, 1, 0);

                    Grid.deleteFullRows();

                    FindObjectOfType<Spawner>().spawnNext();

                    enabled = false;
                }
            }
        }
        else if (level2 == true)
        {
            if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 13 : fallTime / 4))
            {
                transform.position += new Vector3(0, -1, 0);
                previousTime = Time.time;

                if (isValidGridPos())
                    updateGrid();
                else
                {
                    transform.position += new Vector3(0, 1, 0);

                    Grid.deleteFullRows();

                    FindObjectOfType<Spawner>().spawnNext();

                    enabled = false;
                }
            }
        }
    }

    void Start()
    {
        if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            FindObjectOfType<UI>().Finish();
            Destroy(gameObject);
        }

        FindObjectOfType<Spawner>().NextBlock();
        FindObjectOfType<NextBlock>().Next();
    }
}
