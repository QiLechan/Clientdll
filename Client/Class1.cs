namespace Client;

using System;
using System.Collections;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;

public class Class1
{
    private static Hashtable certificateErrors = new Hashtable();
    public static bool ValidateServerCertificate(
          object sender,
          X509Certificate certificate,
          X509Chain chain,
          SslPolicyErrors sslPolicyErrors)
    {
       if (sslPolicyErrors == SslPolicyErrors.None)
            return true;
        Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
        return false;
    }
    public static void Connect()
    {
        TcpClient client = new TcpClient();
        SslStream sslStream= new SslStream(
            client.GetStream(),
            false,
            new RemoteCertificateValidationCallback(ValidateServerCertificate),
            null);
        
    }
}
