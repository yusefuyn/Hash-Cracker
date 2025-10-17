using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YK_47_Hash_Cracker.Create.Hash
{
    public class Manager
    {
        private static ConcurrentDictionary<Enumerators.HashType.Type, ThreadLocal<HashAlgorithm>> hashPool
            = new ConcurrentDictionary<Enumerators.HashType.Type, ThreadLocal<HashAlgorithm>>();

        private static HashAlgorithm GetThreadLocalHash(Enumerators.HashType.Type type)
        {
            return hashPool.GetOrAdd(type, t => new ThreadLocal<HashAlgorithm>(() =>
            {
                switch (t)
                {
                    case Enumerators.HashType.Type.MD5: return MD5.Create();
                    case Enumerators.HashType.Type.SHA1: return SHA1.Create();
                    case Enumerators.HashType.Type.SHA256: return SHA256.Create();
                    case Enumerators.HashType.Type.SHA384: return SHA384.Create();
                    case Enumerators.HashType.Type.SHA512: return SHA512.Create();
                    default: return null;
                }
            })).Value;
        }

        public string Hash(Enumerators.HashType.Type type, string Value)
        {
            if (Value == null) return "";
            if (Value.Length > 5_000_000) throw new ArgumentException("Girdi çok büyük.");

            try
            {
                // SHA3 familyası özel; bunları thread-local da yapabilirsiniz fakat örnek basit tutulsun:
                if (type == Enumerators.HashType.Type.SHA3256 ||
                    type == Enumerators.HashType.Type.SHA3384 ||
                    type == Enumerators.HashType.Type.SHA3512 ||
                    type == Enumerators.HashType.Type.SHAKE128 ||
                    type == Enumerators.HashType.Type.SHAKE256)
                {
                    // Mevcut uygulamanızla aynıdır (isterseniz bunları da ThreadLocal hale getirebiliriz)
                    // ... mevcut Waher kodu ...
                }

                // Managed algoritmalar için ArrayPool kullanarak byte[] alalım
                var algo = GetThreadLocalHash(type);
                if (algo == null) return "";

                // char -> byte dönüşüm için pool kullan
                int maxBytes = Encoding.ASCII.GetByteCount(Value);
                byte[] buffer = ArrayPool<byte>.Shared.Rent(maxBytes);
                try
                {
                    int written = Encoding.ASCII.GetBytes(Value, 0, Value.Length, buffer, 0);
                    // ComputeHash overload'u (buffer, index, count) yoksa CreateHash için yeni byte[] kopyalamak gerekebilir.
                    // Ancak many HashAlgorithm implementations have ComputeHash(Stream) or ComputeHash(byte[],int,int).
                    byte[] result = algo.ComputeHash(buffer, 0, written);
                    return stringAppend(result);
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(buffer, clearArray: true);
                }
            }
            catch (Exception ex)
            {
                // log vs.
                return "";
            }
        }
        private string stringAppend(byte[] ar)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ar.Length; i++)
            {
                sb.Append(ar[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
