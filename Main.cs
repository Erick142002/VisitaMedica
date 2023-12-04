using MP09.UF01.P01.Seguretat.model.domain;

class MainClass
{
    public static void Main(string[] args)
    {
        UsuariController usuariController = new UsuariController();
        usuariController.AplicaSeguretatMD5();
        usuariController.AplicaSeguretatSHA256();
        usuariController.AplicaSeguretatAES();
    }
}
