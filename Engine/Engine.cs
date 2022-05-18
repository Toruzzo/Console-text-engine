using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pix.Engine {


    abstract class Engine {

        public static Camera camera;
        public Drawer drawer;
        Display display;
        Thread windowThread;
        private static Vector2 windowSize;

        public static Vector2 WindowSize { get { return windowSize; } }
        public Engine(Vector2 _windowSize) {

            windowSize = _windowSize;
            drawer = new Drawer(windowSize.X, windowSize.Y);
            display = new Display(windowSize.X, windowSize.Y);
            windowThread = new Thread(Loop);
            windowThread.Start();
        }

        void Loop() {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Start();
            while (windowThread.IsAlive) {
                drawer.Reset();
                //new Thread(Update).Start();
                Update();
                display.Draw(drawer.Res);
                Thread.Sleep(1);
            }

        }

        public virtual void Start() { }
        public virtual void Update() { }
        
    }

    struct Camera {

        public Vector3 position;
        public Vector3 rotation;

        public Vector3 Forward {
            get { return new Vector3(1, 1, 1).RotateX(rotation.X, position).RotateY(rotation.Y, position).RotateZ(rotation.Z, position); }
        }

        public Camera(Vector3 position, Vector3 rotation) {
            this.position = position;
            this.rotation = rotation;
        }
    }

}
