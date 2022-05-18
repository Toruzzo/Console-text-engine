using System;

namespace Pix {
    static class Input {

        
        public static bool GetKey(ConsoleKey key){
            
            if (Console.KeyAvailable && Console.ReadKey().Key == new ConsoleKeyInfo((char)(int)key, key, false, false, false).Key) {
                //Console.Clear();
                return true; 
            } 
            else return false;
        }


        public static bool GetKeyUp(ConsoleKey key) {
            if (GetKey(key)) {
                if (!GetKey(key)) {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
