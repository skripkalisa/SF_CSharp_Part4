using System.Security.Cryptography;
using System.Text;

namespace CSBlog.Services;
public class Cryptography
{

  public string HashSHA256(string value)
  {
    var crypt =  SHA256.Create();
    var hash = new StringBuilder();
    byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value));
    foreach (byte theByte in crypto)
    {
      hash.Append(theByte.ToString("x2"));
    }
    return hash.ToString();
  }

  public byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
  {
    // Check arguments.
    if (plainText == null || plainText.Length <= 0)
      throw new ArgumentNullException(nameof(plainText));
    if (key == null || key.Length <= 0)
      throw new ArgumentNullException(nameof(key));
    if (iv == null || iv.Length <= 0)
      throw new ArgumentNullException(nameof(iv));
    byte[] encrypted;

    // Create an Aes object
    // with the specified key and IV.
    using Aes aesAlg = Aes.Create();
    aesAlg.Key = key;
    aesAlg.IV = iv;
    aesAlg.Padding = PaddingMode.Zeros;
    // Create an encryptor to perform the stream transform.
    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

    // Create the streams used for encryption.
    using MemoryStream msEncrypt = new MemoryStream();
    using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
    using (BinaryWriter swEncrypt = new BinaryWriter(csEncrypt))
    {
      //Write all data to the stream.
      swEncrypt.Write(plainText);
    }
    encrypted = msEncrypt.ToArray();

    // Return the encrypted bytes from the memory stream.
    return encrypted;
  }
    public string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
  {
    // Check arguments.
    if (cipherText == null || cipherText.Length <= 0)
      throw new ArgumentNullException(nameof(cipherText));
    if (key == null || key.Length <= 0)
      throw new ArgumentNullException(nameof(key));
    if (iv == null || iv.Length <= 0)
      throw new ArgumentNullException(nameof(iv));

    // Declare the string used to hold
    // the decrypted text.

    // Create an Aes object
    // with the specified key and IV.
    using Aes aesAlg = Aes.Create();
    aesAlg.Key = key;
    aesAlg.IV = iv;
    aesAlg.Padding = PaddingMode.Zeros;
    // Create a decryptor to perform the stream transform.
    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                
    // Create the streams used for decryption.
    using MemoryStream msDecrypt = new MemoryStream(cipherText);
    using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
    using StreamReader srDecrypt = new StreamReader(csDecrypt);
    // Read the decrypted bytes from the decrypting stream
    // and place them in a string.
    var plaintext = srDecrypt.ReadToEnd();
    string output = plaintext.Substring(plaintext.IndexOf('{'));
    return output;
  }
  
  
}