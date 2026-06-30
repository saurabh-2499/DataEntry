using Microsoft.VisualBasic;
using System.Security.Cryptography;
using System.Text;
using System;


public class SFix
{
    public object RandomString(int intValue)
    {
        object  value = null;
        int i , r ;
        VBMath.Randomize();
        for (i = 0; i <= intValue; i++)
        {
            r = Convert.ToInt16(VBMath.Rnd() * 62);
            if (r < 10)
            {
                r = r + 48;
            }
            else if (r < 36)
            {
                r = (r - 10) + 65;
            }
            else
            {
                r = (r - 10 - 26) + 97;
            }
            if (value == null)
                value = Convert.ToChar(r);
            else
                value = value.ToString () + Convert.ToChar (r);
        }
        return value;
    }

    public object RandomString4Chars(int intValue)
    {
        object value = null;
        int i, r = 0, p;
        VBMath.Randomize();
        Random rdm = new Random();
        for (i = 0; i <= intValue; i++)
        {
           // p = rdm.Next(1, 2);
           // if (p == 1)
                //r = Convert.ToInt32(rdm.Next(65, 90));
           // else if (p == 2)
                r = Convert.ToInt32(rdm.Next(97, 122));
            
            if (value == null)
                value = Convert.ToChar(r);
            else
                value = value.ToString() + Convert.ToChar(r);
        }
        return value;
    }

    //Public Function md5Enc(ByVal passwdEnc As String) As Byte() 
    // 'Encrypt the password 
    // Dim md5Hasher As New MD5CryptoServiceProvider() 
    // Dim hashedBytes As Byte() 
    // Dim encoder As New UTF8Encoding() 
    // hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(passwdEnc)) 
    // Return hashedBytes 
    //End Function 

    public string md5en(string pass)
    {

        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        UTF8Encoding textencoder = new UTF8Encoding();

        md5.ComputeHash(textencoder.GetBytes(pass));

        byte[] hash = md5.Hash;
        StringBuilder buff = new StringBuilder();
       // byte hashByte = 0;
        foreach (byte hashByte in hash)
        {
            buff.Append(string.Format("{0:X2}", hashByte));
        }

        return buff.ToString().ToLower();
    }


    public string sha1(string pass)
    {
        //create new instance of md5
        SHA1 sha1 = SHA1.Create();
        UTF8Encoding textencoder = new UTF8Encoding();

        //convert the input text to array of bytes
        byte[] hashData = sha1.ComputeHash(textencoder.GetBytes(pass));

        //create new instance of StringBuilder to save hashed data
        StringBuilder buff = new StringBuilder();     

        foreach (byte hashByte in hashData)
        {
            buff.Append(string.Format("{0:X2}", hashByte));
        }

        return buff.ToString().ToLower();
    }
}