using UnityEngine;

public class GemGenerator : MonoBehaviour {
    public GameObject gemPrefab;
    public int boardWidth = 8;
    public int boardHeight = 10;
    public float slideSpeed = 1f;

    private Gem[,] gems;

    void Start() {
        GenerateGems();
    }

    void GenerateGems() {
        gems = new Gem[boardWidth, boardHeight];

        for (int x = 0; x < boardWidth; x++) {
            for (int y = 0; y < boardHeight; y++) {
                Vector2 gemPosition = new Vector2(x, -1);

                // Create and place the gem at the bottom of the screen
                GameObject gem = Instantiate(gemPrefab, new Vector2(x, -1), Quaternion.identity);
                gems[x, y] = gem.GetComponent<Gem>();
                gems[x, y].SetPosition(gemPosition);

                // Slide the gem up to its correct position
                gems[x, y].SlideToPosition(gemPosition + new Vector2(0, y), slideSpeed);
            }
        }
    }
}