using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YK_47_Hash_Cracker.Create.Hash
{
    public class Manager
    {
        public string Hash(Enumerators.HashType.Type type, string Value)
        {
            HashAlgorithm hashObj = null;

            switch (type)
            {
                case Enumerators.HashType.Type.MD5:
                    hashObj = new MD5CryptoServiceProvider();
                    break;
                case Enumerators.HashType.Type.SHA1:
                    hashObj = new SHA1CryptoServiceProvider();
                    break;
                case Enumerators.HashType.Type.SHA256:
                    hashObj = new SHA256CryptoServiceProvider();
                    break;
                case Enumerators.HashType.Type.SHA384:
                    hashObj = new SHA384CryptoServiceProvider();
                    break;
                case Enumerators.HashType.Type.SHA512:
                    hashObj = new SHA512CryptoServiceProvider();
                    break;
                case Enumerators.HashType.Type.SHA3256:
                    try
                    {
                        Waher.Security.SHA3.SHA3_256 sha256 = new Waher.Security.SHA3.SHA3_256();
                        return stringAppend(sha256.ComputeFixed(Encoding.ASCII.GetBytes(Value)));
                    }
                    catch (Exception ex)
                    {
                        if (ex.ToString() == "Expected array of 200 bytes.")
                            MessageBox.Show("Değer SHA3256 Algoritmasına göre yeterli uzunlukta değil! Online convert sayfaları bayt doldurma yapmaktadır.");
                        return "";
                    }
                case Enumerators.HashType.Type.SHA3384:
                    try
                    {
                        Waher.Security.SHA3.SHA3_384 sha384 = new Waher.Security.SHA3.SHA3_384();
                        return stringAppend(sha384.ComputeFixed(Encoding.ASCII.GetBytes(Value)));
                    }
                    catch (Exception ex)
                    {
                        if (ex.ToString() == "Expected array of 200 bytes.")
                            MessageBox.Show("Değer SHA3384 Algoritmasına göre yeterli uzunlukta değil! Online convert sayfaları bayt doldurma yapmaktadır.");
                        return "";
                    }
                case Enumerators.HashType.Type.SHA3512:
                    try
                    {
                        Waher.Security.SHA3.SHA3_512 sha512 = new Waher.Security.SHA3.SHA3_512();
                        return stringAppend(sha512.ComputeFixed(Encoding.ASCII.GetBytes(Value)));
                    }
                    catch (Exception ex) {
                        if (ex.ToString() == "Expected array of 200 bytes.")
                            MessageBox.Show("Değer SHA3512 Algoritmasına göre yeterli uzunlukta değil! Online convert sayfaları bayt doldurma yapmaktadır.");
                        return "";
                    }
                case Enumerators.HashType.Type.SHAKE128:
                    try
                    {
                        Waher.Security.SHA3.SHAKE128 shake128 = new Waher.Security.SHA3.SHAKE128(Value.Length);
                        return stringAppend(shake128.ComputeFixed(Encoding.ASCII.GetBytes(Value)));
                    }
                    catch (Exception ex)
                    {
                        if (ex.ToString() == "Expected array of 200 bytes.")
                            MessageBox.Show("Değer SHAKE128 Algoritmasına göre yeterli uzunlukta değil! Online convert sayfaları bayt doldurma yapmaktadır.");
                        return "";
                    }

                case Enumerators.HashType.Type.SHAKE256:
                    try
                    {
                        Waher.Security.SHA3.SHAKE256 shake256 = new Waher.Security.SHA3.SHAKE256(Value.Length);
                        return stringAppend(shake256.ComputeFixed(Encoding.ASCII.GetBytes(Value)));
                    }
                    catch (Exception ex)
                    {
                        if (ex.ToString() == "Expected array of 200 bytes.")
                            MessageBox.Show("Değer SHAKE256 Algoritmasına göre yeterli uzunlukta değil! Online convert sayfaları bayt doldurma yapmaktadır.");
                        return "";
                    }

                default:
                    break;
            }


            byte[] testArray = hashObj.ComputeHash(Encoding.ASCII.GetBytes(Value));
            return stringAppend(testArray);
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
