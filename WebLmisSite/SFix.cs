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
        int i, r;
        VBMath.Randomize();
        Random rdm = new Random();
        for (i = 0; i <= intValue; i++)
        {
            r = Convert.ToInt32(rdm.Next(65, 122));
            //r = Convert.ToInt16(VBMath.Rnd() * 62);
            //if (r < 10)
            //{
            //    r = r + 48;
            //}
            //else if (r < 36)
            //{
            //    r = (r - 10) + 65;
            //}
            //else
            //{
            //    r = (r - 10 - 26) + 97;
            //}
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
}