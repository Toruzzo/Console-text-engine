using System;
using Pix.Engine;



namespace Pix {

    class Program : Engine.Engine{
        int off = 0;
        int x = 50;
        int y = 50;
        static Vector2[] points = { new Vector2(0, 0), new Vector2(0, 10), new Vector2(10, 10), new Vector2(10, 0) };
        Shape rect = new Shape(points, new Vector2(30, 30), 0f, 1f, false);

        Vector3[] tpoints = { new Vector3(0, 0, 0), new Vector3(50, 50, 0), new Vector3(0, 50, 0)};
        Triangle t;
        Triangle t2;
        Triangle t3;

       

        Cube c;
        public Program() : base(new Vector2(300, 300)) {
           
        }

        public override void Start() {
            
            c = new Cube(Vector3.zero, new Vector3(0, 45, 0), false, .1f, ConsoleColor.DarkGreen);
            c.UpdateCube();
        }

        public override void Update() {

            c.rotation.Y += .001f;
            c.rotation.X += .001f;
            c.rotation.Z += .001f;

            c.UpdateCube();
            drawer.AddCube(c);
        }

        static void Main(string[] args) {

            Program p = new Program(); 
        }
    }
}
