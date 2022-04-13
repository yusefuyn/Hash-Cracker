using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YK_47_Hash_Cracker.Create.Hash.Enumerators
{
    static public class HashType
    {
        public enum Type
        {
            MD2,
            MD4,
            MD5,
            SHA1,
            SHA224,
            SHA256,
            SHA384,
            SHA512,
            SHA3256,
            SHA3384,
            SHA3512,
            KECCAK224,
            KECCAK256,
            KECCAK384,
            KECCAK512,
            SHAKE128,
            SHAKE256
        }
    }
}
