using System.Collections.Generic;

namespace System
{
    public static class GameFlags
    {
        // Adds a flag to the set of game flags.
        private static HashSet<string> flags = new HashSet<string>();

        public static void SetFlag(string key)
        {
            if (!flags.Contains(key)) 
                flags.Add(key);
        }
        
        public static bool HasFlag(string key)
        {
            return flags.Contains(key);
        }
        
        public static void ClearFlag(string key)
        {
            if (flags.Contains(key)) 
                flags.Remove(key);
        }
        
        // Khi bat dau game moi, tat ca flag se duoc xoa => New Game
        public static void ClearAllFlags()
        {
            flags.Clear();
        }
    }
}