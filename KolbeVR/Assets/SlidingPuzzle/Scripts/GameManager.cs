using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform gameTransform, piecePrefab;

    private int emptyLocation;
    private int size;
    private bool shuffling = false;

   
    private RaycastHit2D hit;
    private List<Transform> pieces;
    private void Start()
    {
        pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);
        
    }
    private void Update()
    {
      
        //On click send out a ray to see if you click a place
        if (Input.GetMouseButtonDown(0))
        {
             hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); // Somewhere in this line or something before it causes the issue
            if (hit)
            {
                // Go through the list, the index tells us the position
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i] == hit.transform)
                        //Check each direction to see if valid move
                        //We break out on success so we don't carry on and snap back again
                    {
                        if (SwapIfValid(i, -size, size)) { break; }
                        if (SwapIfValid(i, +size, size)) { break; }
                        if (SwapIfValid(i, -1, 0)) { break; }
                        if (SwapIfValid(i, +1, size - 1)) { break; }
                    }
                }
            }

        }

        //Check for completion

        if (!shuffling && CheckCompletion())
        {
            shuffling = true;
            StartCoroutine(WaitShuffle(0.5f));
        }
    }
    void CreateGamePieces(float gapThickness)
    {
        // width of each title
        float width = 1 / (float)size;

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);
                //pieces will be in a game board going from -1 to 1.
                piece.localPosition = new Vector3(-1 + (2 * width * col) + width, + 1 - (2 * width * row) - width, 0);

                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row*size)+col}";
                //We want an empty space in the bottom right
                if ((row == size -1 )&& (col ==size-1)) 
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                {
                    //We want to map the UV coordinates appropriately, they are 0-->1.
                    float gap = gapThickness / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    // UV coord order: (0,1),(1,1),(0,0),(1,0)
                    uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
                    uv[3] = new Vector2((width * (col+1)) - gap, 1 - ((width * row) + gap));
                    // Assign the UVs to teh mesh
                    mesh.uv = uv;
                }
                
            }
        }
    }
    //Colcheck is used to stop horizontal moves wrapping
   public bool SwapIfValid(int i, int offset, int colCheck)
    {
        if ((i%size) !=colCheck && ((i+offset) == emptyLocation))
        {
            //swap them in gamestate
            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
            //swap their transforms
            (pieces[i].localPosition, pieces[i + offset].localPosition) = (pieces[i + offset].localPosition, pieces[i].localPosition);

            emptyLocation = i;
            return true;
        }

        return false;
    }

    //we name the pieces in order so we can use this check completion
    private bool CheckCompletion()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].name != $"{i}")
            {
                return false;
            }
        }
        return true;
    }
    private IEnumerator WaitShuffle(float duration)
    {
        yield return new WaitForSeconds(duration);
        Shuffle();
        shuffling = false;
    }

    //Brute force shuffling for simplicity

    void Shuffle()
    {
        int count = 0;
        int last = 0;
        while(count<(size*size*size))
        {
            // pick a random location
            int rnd = Random.Range(0, size *size);
            // forbid undoing the last move.
            if (rnd == last)
            {
                continue;
                
            }
            last = emptyLocation;
            // try surrounding spaces for valid moves

            if (SwapIfValid(rnd, -size, size))
            {
                count++;
            }
            else if (SwapIfValid(rnd, +size, size))
            {
                count++;
            }
            else if (SwapIfValid(rnd, -1, 0))
            {
                count++;
            }
            else if (SwapIfValid(rnd, +1, size - 1))
            {
                count++;
            }
        }
       
    }
}
