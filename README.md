Unity Version 2023.2.18f1 Update Version -> 6000.0.0f1

    private void Awake()
    {
        Debug.Log("Awake was called!");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start was called");
    }

    // Called 50 times per second // In general nu este folosit mai deloc
    private void FixedUpdate()
    {
        Debug.Log("Fixed update was called");
    }

    // Update is called once per frame // 240 FPS - Called 240 times per second
    void Update()
    {
        Debug.Log("Update was called");
    }

Payer:
	Rigidbody2D:
		- Constraints > Freeze Rotation Z: Check
        - Collision Detection: Continuous
		- Interpolate: Interpolate
Imagini:
	Sprite Mode = Multiple
	Pixel Per Unit = 16
	Filter Mode = Point (no filter)
	Compression = None

	Open Sprite Mode Editor > Slice > Type > Grid By Cell Size > Pixel Size > X: 32, Y: 32
	
Animator:
	Has exit Time: Uncheck
	Transition Duration (s): 0

Ground:
    RigitBody2D > Body Type: Static
    Tilemap Collider 2D > Composite Operation: Merge
    Composite Collider 2D > Geometry Type: Polygons