using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalPlane : MonoBehaviour
{
    //9 possible positions for rotational plane
    public int currentPositionRotationlaPlane = 6;

    //cube size
    private float size;

    //all the cubes
    private Transform[] cubeTransforms;
    private int numCubes;
    private GameObject cubeParent;

    //shows rotational plane
    private Transform rotationalPlane;

    //transoforms of the cubes which are going to moved according to the rotational plane
    public Transform[] switchTransforms;

    //random shuffle sequence: x = currentPositionRotationlaPlane, y = direction
    public Vector2Int[] randomSequence;

    //rotational plane position: 
    public class Position
    {
        public Vector3 pos;
        public Vector3 rotation;

        public Position(Vector3 pos, Vector3 rotation)
        {
            this.pos = pos;
            this.rotation = rotation;
        }
    }

    //possible positions
    private Position[] positions;


    private void Start()
    {
        switchTransforms = new Transform[9];

        //get parent gameobject
        cubeParent = transform.parent.gameObject;

        //get size of cube
        size = cubeParent.transform.GetChild(1).GetComponent<MeshGenerator>().size;
        size *= 2;

        //get rotational display
        rotationalPlane = transform.GetChild(0).transform;

        CreatePositions();
        GetCubeTransforms();
    }


    //shuffle positions
    public void ShuffleCube(int numMoves)
    {
        //random Sequence
        randomSequence = new Vector2Int[25];
        for (int i = 0; i < randomSequence.Length; i++)
        {
            //rotation plane
            randomSequence[i].x = Random.Range(0, 8);

            //direction
            int direction = Random.Range(0, 1);
            if (direction == 0)
                direction = -1;
            randomSequence[i].y = direction;
        }

        //apply sequence
        StartCoroutine(ApplySequence(0.001f));
    }

    //play shuffeld moves in reverse order
    public void SolveCube()
    {
        StartCoroutine(SolveSequence(0.1f));
    }

    private IEnumerator ApplySequence(float duration)
    {
        for (int i = 0; i < randomSequence.Length; i++)
        {
            currentPositionRotationlaPlane = randomSequence[i].x;
            ApplyPosition();

            RotateCubes(randomSequence[i].y);

            yield return new WaitForSeconds(duration);
        } 
    }

    private IEnumerator SolveSequence(float duration)
    {
        for (int i = randomSequence.Length -1; i >= 0; i--)
        {
            currentPositionRotationlaPlane = randomSequence[i].x;
            ApplyPosition();

            RotateCubes(randomSequence[i].y * -1);
            yield return new WaitForSeconds(duration);
        }
    }


    //store all cube transforms
    private void GetCubeTransforms()
    {
        //get cubes
        numCubes = cubeParent.transform.childCount - 1;
        cubeTransforms = new Transform[numCubes];

        for (int i = 0; i < numCubes; i++)
        {
            cubeTransforms[i] = transform.parent.GetChild(i + 1);
        }
    }

    //set positions for the rotationlal plane
    private  void CreatePositions()
    {
        positions = new Position[9];

        //y axis
        Vector3 rotation = new Vector3(0, 0, 0);
        positions[0] = new Position(new Vector3(0, -size, 0), rotation);
        positions[1] = new Position(new Vector3(0, 0, 0), rotation);
        positions[2] = new Position(new Vector3(0, size, 0), rotation);

        //x axis
        rotation = new Vector3(0, 0, 90);
        positions[3] = new Position(new Vector3(-size, 0, 0), rotation);
        positions[4] = new Position(new Vector3(0, 0, 0), rotation);
        positions[5] = new Position(new Vector3(size, 0, 0), rotation);


        //z axis
        rotation = new Vector3(90, 0, 0);
        positions[6] = new Position(new Vector3(0, 0, -size), rotation);
        positions[7] = new Position(new Vector3(0, 0, 0), rotation);
        positions[8] = new Position(new Vector3(0, 0, size), rotation);
    }

    //applay positions to plane
    private void ApplyPosition()
    {

        rotationalPlane.position = positions[currentPositionRotationlaPlane].pos;
        rotationalPlane.eulerAngles = positions[currentPositionRotationlaPlane].rotation;

        AddCubesToSwitchTransform();
    }


    private void AddCubesToSwitchTransform()
    {
        int cubecount = 0;

        //set switchTransforms in correspondence to current position
        switch (currentPositionRotationlaPlane)
        {
            //y axis
            case 0:
                foreach (Transform cubeTransform in cubeTransforms)
                {
                    if (cubeTransform.position.y == rotationalPlane.position.y)
                    {
                        switchTransforms[cubecount] = cubeTransform;
                        cubecount++;
                    }
                }
                break;
            case 1:
                foreach (Transform cubeTransform in cubeTransforms)
                {
                    if (cubeTransform.position.y == rotationalPlane.position.y)
                    {
                        switchTransforms[cubecount] = cubeTransform;
                        cubecount++;
                    }
                }
                break;
            case 2:
                foreach (Transform cubeTransform in cubeTransforms)
                {
                    if (cubeTransform.position.y == rotationalPlane.position.y)
                    {
                        switchTransforms[cubecount] = cubeTransform;
                        cubecount++;
                    }
                }
                break;

            //x-axis
            case 3:
                foreach (Transform cubeTransform in cubeTransforms)
                {
                    if (cubeTransform.position.x == rotationalPlane.position.x)
                    {
                        switchTransforms[cubecount] = cubeTransform;
                        cubecount++;
                    }
                }
                break;
            case 4:
                foreach (Transform cubeTransform in cubeTransforms)
                {
                    if (cubeTransform.position.x == rotationalPlane.position.x)
                    {
                        switchTransforms[cubecount] = cubeTransform;
                        cubecount++;
                    }
                }
                break;
            case 5:
                foreach (Transform cubeTransform in cubeTransforms)
                {
                    if (cubeTransform.position.x == rotationalPlane.position.x)
                    {
                        switchTransforms[cubecount] = cubeTransform;
                        cubecount++;
                    }
                }
                break;

            //z-axis
            case 6:
                foreach (Transform cubeTransform in cubeTransforms)
                {
                    if (cubeTransform.position.z == rotationalPlane.position.z)
                    {
                        switchTransforms[cubecount] = cubeTransform;
                        cubecount++;
                    }
                }
                break;
            case 7:
                foreach (Transform cubeTransform in cubeTransforms)
                {
                    if (cubeTransform.position.z == rotationalPlane.position.z)
                    {
                        switchTransforms[cubecount] = cubeTransform;
                        cubecount++;
                    }
                }
                break;
            case 8:
                foreach (Transform cubeTransform in cubeTransforms)
                {
                    if (cubeTransform.position.z == rotationalPlane.position.z)
                    {
                        switchTransforms[cubecount] = cubeTransform;
                        cubecount++;
                    }
                }
                break;
        }
    }


    private void RotateCubes(int direction)
    {
        direction *= 90;
        float xNew;
        float yNew;
        float zNew;

        switch (currentPositionRotationlaPlane)
        {

            //y axis
            case 0:
            case 1:
            case 2:
                {
                    for (int i = 0; i < 9; i++)
                    {
                        Transform cube = switchTransforms[i];

                        //get xyz
                        float x = cube.position.x;
                        float y = cube.position.y;
                        float z = cube.position.z;

                        //set xyz
                        if (direction == -90)
                        {
                            xNew = (2 / 3 * size) - z;
                            yNew = y;
                            zNew = x;
                        }
                        else
                        {
                            xNew = z;
                            yNew = y;
                            zNew = (2 / 3 * size) - x;
                        }

                        Vector3 newPos = new Vector3(xNew, yNew, zNew);
                        cube.position = newPos;

                        cube.Rotate(0, direction, 0, Space.World);
                    }
                }
                break;

            //x axis
            case 3:
            case 4:
            case 5:
                {
                    for (int i = 0; i < 9; i++)
                    {
                        Transform cube = switchTransforms[i];

                        //get xyz
                        float x = cube.position.x;
                        float y = cube.position.y;
                        float z = cube.position.z;

                        //set xyz
                        if (direction == -90)
                        {
                            xNew = x;
                            yNew = z;
                            zNew = (2 / 3 * size) - y;
                        }
                        else
                        {
                            xNew = x;
                            yNew = (2 / 3 * size) - z;
                            zNew = y;
                        }
     
                        Vector3 newPos = new Vector3(xNew, yNew, zNew);
                        cube.position = newPos;

                        cube.Rotate(direction, 0, 0, Space.World);
                    }
                }
                break;

            //z axis
            case 6:
            case 7:
            case 8:
                {
                    for (int i = 0; i < 9; i++)
                    {
                        Transform cube = switchTransforms[i];

                        //get xyz
                        float x = cube.position.x;
                        float y = cube.position.y;
                        float z = cube.position.z;

                        //set xyz
                        if (direction == -90)
                        {
                            xNew = y;
                            yNew = (2 / 3 * size) - x;
                            zNew = z;
                        }
                        else
                        {
                            xNew = (2 / 3 * size) - y;
                            yNew = x;
                            zNew = z;
                        }

                        Vector3 newPos = new Vector3(xNew, yNew, zNew);
                        cube.position = newPos;
        
                        cube.Rotate(0, 0, direction, Space.World);
                    }
                }
                break;
        }
    }


    private void Update()
    {
        //loop through positions
        if (Input.GetKeyDown("up"))
        {
            currentPositionRotationlaPlane++;
            currentPositionRotationlaPlane %= positions.Length;
            ApplyPosition();
        }
        else if (Input.GetKeyDown("down"))
        {
            if (currentPositionRotationlaPlane == 0)
            {
                currentPositionRotationlaPlane = positions.Length - 1;
            }
            else
            {
                currentPositionRotationlaPlane--;
            }
            ApplyPosition();
        }
        else if (Input.GetKeyDown("left"))
        {
            RotateCubes(1);
        }

        else if (Input.GetKeyDown("right"))
        {
            RotateCubes(-1);
        }
    }



}
