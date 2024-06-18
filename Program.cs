using System.Security.Cryptography;

namespace GenKeyIV
{
    internal class Program
    {
        // 32バイトの鍵を生成
        private static byte[] GetKey()
        {
            byte[] key = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        // 16バイトの初期化ベクトルを生成 
        private static byte[] GetIV()
        {
            byte[] iv = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(iv);
            }
            return iv;
        }

        /// <summary>
        /// Mainメソッド
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        static void Main(string[] args)
        {
            byte[] key = GetKey();
            Console.Write("Key: ");
            DisplayByteArray(key);

            Console.Write("IV: ");
            byte[] iv = GetIV();
            DisplayByteArray(iv);
        }

        /// <summary>
        /// バイト配列を表示する
        /// </summary>
        /// <param name="bytes"></param>
        static void DisplayByteArray(byte[] bytes)
        {
            Console.Write("{ ");
            foreach (byte b in bytes)
            {
                Console.Write($"0x{b:X2},");
            }
            Console.WriteLine(" }");
            Console.WriteLine();
        }
    }
}
